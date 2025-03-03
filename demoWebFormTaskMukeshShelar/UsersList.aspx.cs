using demoWebFormTaskMukeshShelar.BLL;
using System;
using System.Web;
using System.Web.UI.WebControls;

namespace demoWebFormTaskMukeshShelar
{
    public partial class UsersList : System.Web.UI.Page
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
            string encrypteduserid = Request.QueryString["userId"];
            string guiduser = HttpUtility.UrlDecode(businessLogic.Decrypt(guid));


            LinkButton linkButton = sender as LinkButton;
            if (linkButton != null)
            {
                string userIdVal = linkButton.Text;
                string encrypteduserIdVal = HttpUtility.UrlEncode(businessLogic.Encrypt(userIdVal));
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(guiduser))
                {
                    string url = $"UserDetails.aspx?userId={encrypteduserid}&guid={guid}&ClickedUserId={encrypteduserIdVal}";
                    Response.Redirect(url, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}