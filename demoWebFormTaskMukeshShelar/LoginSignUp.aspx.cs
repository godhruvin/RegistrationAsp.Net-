using demoWebFormTaskMukeshShelar.BLL;
using System;

namespace demoWebFormTaskMukeshShelar
{
    public partial class LoginSignUp : System.Web.UI.Page
    {
        UserBusinessLogic businessLogic = new UserBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnLogin.Visible = true;
                btnSignIn.Visible = false;
            }
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();
            string userId = txtUserId.Text.Trim();
            int isActive = 0; // presently user inactive 

            try
            {
                bool isUserExists = businessLogic.UserLogin(userId, password);
              
                if (!isUserExists) // user not exist
                {
                    btnSignIn.Visible = true;
                    btnLogin.Visible = false;
                    lnkForgotPassword.Visible = false;
                    Session["isNewUser"] = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                                                        "showAlert(); toggleValidation(false);", true);
                }
                else // user already exists
                {
                    Session["userId"] = txtUserId.Text;
                    string guid = Guid.NewGuid().ToString();
                    Session["userguid"] = guid;
                    Session["isNewUser"] = false;
                    Console.WriteLine("session guid : " + Session["userguid"].ToString());
                    string redirectUrl = $"WelcomePage.aspx?userId={userId}&guid={guid}";
                    
                    isActive = 1;
                    businessLogic.StoreLoginInfo(userId, guid, Request.UrlReferrer?.ToString(), DateTime.Now, isActive);
                    Response.Redirect(redirectUrl, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured : " + ex.Message);
            }
        }

        protected void btnSignIn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationForm.aspx", false);
            //Context.ApplicationInstance.CompleteRequest();
        }
    }
}