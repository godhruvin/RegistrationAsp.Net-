using demoWebFormTaskMukeshShelar.BLL;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace demoWebFormTaskMukeshShelar
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        UserBusinessLogic businessLogic = new UserBusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStates();
            }

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
            string StateVal = ddlStates.SelectedValue;
            string CityVal = ddlCities.SelectedValue;
            DateTime dobInput = Convert.ToDateTime(DateOfBirth.Text);
            try
            {
                string result = businessLogic.RegisterUserData(userId, firstname, lastname, mobilenumber, email, gender, maritalStatus,
                                                            remarks ,dobInput, age, StateVal, CityVal , password);

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


