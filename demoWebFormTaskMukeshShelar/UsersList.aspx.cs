using demoWebFormTaskMukeshShelar.BLL;
using System;
using System.Web.UI.WebControls;

namespace demoWebFormTaskMukeshShelar
{
    public partial class UsersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null && Session["userguid"] == null)
            {
                Response.Redirect("LoginSignUp.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            string guiduser = Request.QueryString["guid"];
            if (guiduser != null && guiduser != Session["userguid"]?.ToString())
            {
                Response.Redirect("ServerResponse.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            fetchUsers(sender, e);
        }
        protected void fetchUsers(object sender, EventArgs e)
        {
            UserBusinessLogic businessLogic = new UserBusinessLogic();
            GridViewUsers.DataSource = businessLogic.GetUsers();
            GridViewUsers.DataBind();
        }
        protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells.RemoveAt(1);
            }

            else if (e.Row.RowIndex >= 0)
            {
                e.Row.Cells.RemoveAt(1);
            }
           
        }
        protected void lnkUserId_Click(object sender, EventArgs e)
        {
            string userId = Session["userId"]?.ToString();
            string guid = Request.QueryString["guid"];
            LinkButton linkButton = sender as LinkButton;
            if (linkButton != null)
            {
                string userIdVal = linkButton.Text;
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(guid))
                {
                    string url = $"UserDetails.aspx?userId={userId}&guid={guid}&ClickedUserId={userIdVal}";
                    Response.Redirect(url, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}