using demoWebFormTaskMukeshShelar.BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace demoWebFormTaskMukeshShelar
{
    public partial class UserDetails : System.Web.UI.Page
    {
        UserBusinessLogic businessLogic = new UserBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStates();
                if (Session["userId"] == null || Session["userguid"] == null)
                {
                    Response.Redirect("LoginSignUp.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                string guiduser = Request.QueryString["guid"];
                string decryptedguiduser = HttpUtility.UrlDecode(businessLogic.Decrypt(guiduser));

                if (guiduser != null && decryptedguiduser != Session["userguid"].ToString())
                {
                    Response.Redirect("ServerResponse.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }
                string clickedUserIdVal = Request.QueryString["ClickedUserId"]?.ToString();
                string clickedUserId = HttpUtility.UrlDecode(businessLogic.Decrypt(clickedUserIdVal));
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
                BindStates();
                ddlStates.SelectedValue = userRow["state"].ToString();
                BindCities(int.Parse(ddlStates.SelectedValue));
                ddlCities.SelectedValue = userRow["city"].ToString();
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
                    string clickedUserIdVal = Request.QueryString["ClickedUserId"]?.ToString();
                    string clickedUserId = HttpUtility.UrlDecode(businessLogic.Decrypt(clickedUserIdVal));
                    string userId = clickedUserId;
                    string newUserId = uid.Text;
                    string firstName = FirstName.Text;
                    string lastName = LastName.Text;
                    string mobileNumber = MobileNumber.Text;
                    string email = Email.Text;
                    string gender = Gender.SelectedValue;
                    string maritalStatus = MaritalStatus.SelectedValue;
                    int age = int.Parse(Age.Text);
                    string state = ddlStates.SelectedValue;
                    string city = ddlCities.SelectedValue;
                    string remarks = Request.Form["Remarks"];
                    DateTime dobInput = Convert.ToDateTime(DateOfBirth.Text);

                    string result = businessLogic.updateUserData(userId, newUserId,firstName, lastName, mobileNumber, email, gender, maritalStatus, remarks, dobInput, state , city,age);

                    if (result.Equals("User Updated Successfully"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "confirm", "confirm('User Updated Successfully. Want to Proceed to Users List Page?')", true);
                    }
                    else if (result.Equals("User ID does not exist"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "confirm", "confirm('User ID does not exist. Please check and try again.')", true);
                    }
                   
                    string guiduser = Request.QueryString["guid"];
                    string encrypteduserId = Request.QueryString["userId"]?.ToString();

                    string url = $"UsersList.aspx?userId={encrypteduserId}&guid={guiduser}&ClickedUserId={clickedUserIdVal}";
                    Response.Redirect(url, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured : " + ex.Message);
            }
        }

        protected void ddlStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int stateId = int.Parse(ddlStates.SelectedValue);
                if (stateId > 0)
                {
                    BindCities(stateId);
                }
                else
                {
                    ddlCities.Items.Clear();
                    ddlCities.Items.Insert(0, new ListItem("--Select City--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in state selection: " + ex.Message);
            }
        }

        private void BindStates()
        {
            try
            {
                DataTable dtStates = businessLogic.GetStates();
                ddlStates.DataSource = dtStates;
                ddlStates.DataTextField = "StateName";
                ddlStates.DataValueField = "StateID";
                ddlStates.DataBind();
                ddlStates.Items.Insert(0, new ListItem("--Select State--", "0"));
            }
            catch (Exception ex)
            {

                throw new Exception("Error binding states: " + ex.Message);
            }
        }

        private void BindCities(int stateId)
        {
            try
            {
                DataTable dtCities = businessLogic.GetCitiesByState(stateId);
                ddlCities.DataSource = dtCities;
                ddlCities.DataTextField = "CityName";
                ddlCities.DataValueField = "CityID";
                ddlCities.DataBind();
                ddlCities.Items.Insert(0, new ListItem("--Select City--", "0"));
            }
            catch (Exception ex)
            {
                throw new Exception("Error binding cities: " + ex.Message);
            }
        }
    }
}
