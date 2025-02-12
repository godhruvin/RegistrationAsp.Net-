using Aspose.Pdf.Devices;
using Aspose.Words;
using Aspose.Words.Saving;
using demoWebFormTaskMukeshShelar.BLL;
using System;
using System.IO;
using System.Web.ModelBinding;
using static demoWebFormTaskMukeshShelar.DLL.UserDataAccess;

namespace demoWebFormTaskMukeshShelar
{
    public partial class WelcomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkuserisActiveFieldStatusForSessionExpiry(sender, e);

            if (!IsPostBack)
            {
                FileUpload2.Attributes["onchange"] = "showfilename(this)";
            }

            string userId = Session["userId"]?.ToString();
            string userGuid = Session["userguid"]?.ToString();
            
            //checking userid and userguid is not null

            string guiduser = Request.QueryString["guid"]?.ToString();

            if (Response.IsRequestBeingRedirected)
            {
                return;
            }

            //if the guid and guid of user stores in session does not match 
            if (!string.IsNullOrEmpty(guiduser) && guiduser != userGuid)
            {
                Response.Redirect("ServerResponse.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            setUserIdHeader(sender, e);
        }

        // save the document and save into folder. 
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string uploadFolderPath = Server.MapPath("~/Documents");
                    if (!Directory.Exists(uploadFolderPath))
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }

                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    string filePath = Path.Combine(uploadFolderPath, fileName);

                    FileUpload1.SaveAs(filePath);
                    if (File.Exists(filePath))
                    {
                        string userId = Session["userId"]?.ToString();

                        if (!string.IsNullOrEmpty(userId))
                        {
                            UserBusinessLogic businessLogic = new UserBusinessLogic();
                            int result = businessLogic.insertDocument(userId, fileName);
                            if (result > 0)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File uploaded and record saved successfully!');", true);
                            }
                            else
                            {
                                lblUserIdInModalHeader.Text = Session["userId"].ToString();
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File uploaded, but database insertion failed.');", true);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured : " + ex.Message);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a file to upload.');", true);
            }
        }

        // convert the document into tif format and save into folder.
        protected void btnConvertDocumentTif_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                try
                {
                    string uploadFolderPath = Server.MapPath("~/TifDoc");
                    if (!Directory.Exists(uploadFolderPath))
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }

                    string fileName = Path.GetFileNameWithoutExtension(FileUpload2.FileName);
                    string fileExtension = Path.GetExtension(FileUpload2.FileName).ToLower();
                    string tifFilePath = Path.Combine(uploadFolderPath, fileName + ".tif");
                    string tempFilePath = Path.Combine(uploadFolderPath, FileUpload2.FileName);
                    FileUpload2.SaveAs(tempFilePath);

                    if (fileExtension == ".pdf")
                    {
                        using (Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(tempFilePath))
                        {
                            Resolution resolution = new Resolution(300);
                            TiffSettings tiffSettings = new TiffSettings
                            {
                                Compression = CompressionType.LZW,
                                Depth = ColorDepth.Default,
                                SkipBlankPages = true
                            };
                            TiffDevice tiffDevice = new TiffDevice(resolution, tiffSettings);
                            tiffDevice.Process(pdfDocument, tifFilePath);
                        }
                    }
                    else if (fileExtension == ".docx" || fileExtension == ".doc")
                    {
                        Aspose.Words.Document wordDocument = new Aspose.Words.Document(tempFilePath);
                        ImageSaveOptions options = new ImageSaveOptions(SaveFormat.Tiff)
                        {
                            TiffCompression = TiffCompression.Lzw,
                            Resolution = 300
                        };
                        wordDocument.Save(tifFilePath, options);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Unsupported file type. Only PDF and Word files can be converted.');", true);
                        File.Delete(tempFilePath);
                        return;
                    }

                    string userId = Session["userId"]?.ToString();
                    if (!string.IsNullOrEmpty(userId))
                    {
                        UserBusinessLogic businessLogic = new UserBusinessLogic();
                        int result = businessLogic.insertTifDocument(userId, fileName);

                        if (result > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('TIF document saved successfully!');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('TIF file saved, but database insertion failed.');", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occurred: " + ex.Message);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a file to upload.');", true);
            }
        }

        //redirecting to users list page
        protected void redirectToUsersListPage(object sender, EventArgs e)
        {
            try
            {
                string userId = Session["userId"]?.ToString();
                string guid = Session["userguid"]?.ToString();
                string redirectUrl = $"UsersList.aspx?userId={userId}&guid={guid}";
                Response.Redirect(redirectUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred : " + ex.Message);
            }
        }

        //set the name of user in the header of the modal 
        protected void setUserIdHeader(object sender, EventArgs e)
        {
            // Fetch userId from session
            string userId = Session["userId"]?.ToString();

            if (!string.IsNullOrEmpty(userId))
            {
                // Set userId in the header or display label
                lblUserIdInModalHeader.Text = $"Welcome, {userId}!";
                lblConvertUserIdInModalHeader.Text = $"Welcome, {userId}!";
            }
        }

        //check the status of isactive and expire session
        protected void checkuserisActiveFieldStatusForSessionExpiry(object sender, EventArgs e)
        {
            try
            {
                string userId = Session["userId"]?.ToString();
                string guiduser = Request.QueryString["guid"]?.ToString();

                bool isNewUser = Session["isNewUser"] != null && (bool)Session["isNewUser"];

                if (!isNewUser)
                {
                    // Validate the session using the GUID
                    UserBusinessLogic businessLogic = new UserBusinessLogic();
                    int isActiveStatus = businessLogic.IsSessionValid(guiduser);

                    if (isActiveStatus == 0)
                    {
                        // If the GUID is inactive, redirect this tab to login
                        redirectToLogin();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred in checkuserisActiveFieldStatusForSessionExpiry: " + ex.Message);
            }
        }

        //redirect to login page
        protected void redirectToLogin()
        {
            Response.Redirect("LoginSignUp.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
            return;
        }

    }
}
