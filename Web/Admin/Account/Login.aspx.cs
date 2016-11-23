namespace Admin.Account
{
    using Business.Managers;
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var email = UserName.Text; 
            var psw = Password.Text; 
            
            var user = UsersManager.ValidateLogin(email, psw);
            if (user != null)
            {
                Session["userId"] = user.Id;
                Session["userFirstName"] = user.FirstName;
                Session["userLastName"] = user.LastName;
                Session["userType"] = user.UserType;
                
                //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + "dsdasdasdsa";
                var returnURL = Request.QueryString["returnURL"];
                returnURL = "~/default.aspx";
                ViewState["returnURL"] = returnURL;
                Response.Redirect(ViewState["returnURL"].ToString());

            }
        }
    }
}