using demoWebFormTaskMukeshShelar.BLL;
using System;
using System.Data;

namespace demoWebFormTaskMukeshShelar
{
    public partial class UserDetails : System.Web.UI.Page
    {
        UserBusinessLogic businessLogic = new UserBusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] == null || Session["userguid"] == null)
                {
                    Response.Redirect("LoginSignUp.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                string guiduser = Request.QueryString["guid"];
                if (guiduser != null && guiduser != Session["userguid"].ToString())
                {
                    Response.Redirect("ServerResponse.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }
                string clickedUserId = Request.QueryString["ClickedUserId"]?.ToString();
                if (clickedUserId != null)
                {
                    PopulateUserDetails(clickedUserId);
                }
            }
        }
        private void PopulateUserDetails(string clickedUserId)
        {
            DataSet ds = businessLogic.fetchUserBasedOnUserId(clickedUserId);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow userRow = ds.Tables[0].Rows[0];
                uid.Text = clickedUserId;
                FirstName.Text = userRow["FirstName"].ToString();
                LastName.Text = userRow["LastName"].ToString();
                DateOfBirth.Text = Convert.ToDateTime(userRow["DOB"]).ToString("yyyy-MM-dd");
                Email.Text = userRow["Email"].ToString();
                MobileNumber.Text = userRow["MobileNumber"].ToString();
                MaritalStatus.SelectedValue = userRow["MaritalStatus"].ToString();
                Age.Text = userRow["Age"].ToString();
                Gender.Text = userRow["Gender"].ToString();
                Remarks.Text = userRow["Remarks"].ToString();
            }
        }

        public void Checkedbtnchange(object sender , EventArgs e)
        {
            if (Update.Checked)
            {
                save.Text = "Update";
            }
            else
            {
                save.Text = "Save";
            }
        }
        public void OnUpdateBtnClickSaveUserData(object sender, EventArgs e)
        {
            try
            {
                if (save.Text == "Update")
                {
                    string userId = uid.Text;
                    string firstname = FirstName.Text;
                    string lastname = LastName.Text;
                    string mobilenumber = MobileNumber.Text;
                    string email = Email.Text;
                    string gender = Gender.SelectedValue;
                    string maritalStatus = MaritalStatus.SelectedValue;
                    int age = int.Parse(Age.Text);
                    string remarks = Request.Form["Remarks"];
                    DateTime dobInput = Convert.ToDateTime(DateOfBirth.Text);

                    string result = businessLogic.updateUserData(userId, firstname, lastname, mobilenumber,
                         email, gender, maritalStatus, remarks, dobInput, age);

                    //if (result.Equals("User Updated Successfully"))
                    //{
                    //    ClientScript.RegisterStartupScript(this.GetType(), "confirm", "confirm('User Updated Successfully. Want to Proceed to UsersList Page ?')", true);
                    //}
                    Response.Redirect("~/UsersList.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured : " + ex.Message);
            }
        }
    }
}
