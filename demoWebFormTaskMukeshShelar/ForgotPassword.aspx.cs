using demoWebFormTaskMukeshShelar.BLL;
using System;


namespace demoWebFormTaskMukeshShelar
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BtnProceed_clickToForgotPassword(object sender, EventArgs e)
        {
            string email = Email.Text;
            string mobileNumber = MobileNumber.Text;
            string password = txtForgotPassword.Text;


            try
            {
                string response = userBusinessLogic.ValidateUserAndUpdatePassword(mobileNumber , email , password);

                if(response == "Password updated successfully")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('password updated successfully')",true);
                    Response.Redirect("~/LoginSignUp.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User Not Found...')",true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured : " + ex.Message);
            }
        }
    }
}