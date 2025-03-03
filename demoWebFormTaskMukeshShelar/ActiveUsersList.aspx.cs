using demoWebFormTaskMukeshShelar.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoWebFormTaskMukeshShelar
{
    public partial class ActiveUsersList : System.Web.UI.Page
    {
        UserBusinessLogic businessLogic = new UserBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null && Session["userguid"] == null)
            {
                Response.Redirect("LoginSignUp.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            string guid = Request.QueryString["guid"];
            string guiduser = HttpUtility.UrlDecode(businessLogic.Decrypt(guid));

            if (guiduser != null && guiduser != Session["userguid"]?.ToString())
            {
                Response.Redirect("ServerResponse.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            DisplayActiveUsersList(sender, e);
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            activeUsersList.PageIndex = e.NewPageIndex;
            DisplayActiveUsersList(sender ,e); 
        }

        protected void DisplayActiveUsersList(object sender , EventArgs e)
        {
            try
            {
                DataTable activeUsers = businessLogic.GetActiveUsersList();
                activeUsersList.DataSource = activeUsers;
                activeUsersList.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured : " + ex.Message);
            }
        }
    }
}