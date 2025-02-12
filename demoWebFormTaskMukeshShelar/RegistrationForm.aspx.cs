using demoWebFormTaskMukeshShelar.BLL;
using System;

namespace demoWebFormTaskMukeshShelar
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        UserBusinessLogic businessLogic = new UserBusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isNewUser"] != null && (bool)Session["isNewUser"] == false)
            {
                if (Session["userId"] == null && Session["userguid"] == null)
                {
                    Response.Redirect("LoginSignUp.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                string guiduser = Request.QueryString["guid"];
                if (guiduser != null && guiduser != Session["userguid"].ToString())
                {
                    Response.Redirect("ServerResponse.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
        protected void btnSave_DataInsert(object sender, EventArgs e)
        {
            string userId = uid.Text;
            string firstname = FirstName.Text;
            string lastname = LastName.Text;
            string mobilenumber = MobileNumber.Text;
            string email = Email.Text;
            string password = Password.Text;
            string gender = Gender.SelectedValue;
            string maritalStatus = MaritalStatus.SelectedValue;
            int age = int.Parse(Age.Text);
            string remarks = Request.Form["Remarks"];
            DateTime dobInput = Convert.ToDateTime(DateOfBirth.Text);
            try
            {
               
                string result = businessLogic.RegisterUserData(userId, firstname, lastname, mobilenumber, email, gender, maritalStatus,
                                                            remarks, dobInput, age, password);

                if (result.Equals("User Registered Successfully"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "confirm", "if(ShowConfirmMessage()) { window.location.href='LoginSignUp.aspx'; }", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowAlertMessage()", true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured : " + ex.Message);
            }
        }
    }
}


