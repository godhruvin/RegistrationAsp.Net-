using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace demoWebFormTaskMukeshShelar
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Session["userId"] = null;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if(HttpContext.Current != null)
            {
            HttpContext.Current.Response.Redirect("~/LoginSignUp.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}