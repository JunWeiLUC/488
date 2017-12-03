using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.Security;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private Dictionary<string, string> Users = new Dictionary<string, string>();

        private void AccountList()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(HttpContext.Current.Server.MapPath("Accounts.xml"));
            var root = xmldoc.DocumentElement;
            var nodes = root.SelectNodes("Account");
            foreach (XmlNode node in nodes)
            {
                string username = node.Attributes[0].Value;
                string password = node.Attributes[1].Value;
                Users.Add(username, password);

            }


        }


        protected void login_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string username = Username.Text;
                string password = Password.Text;
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

                AccountList();
                if (!Users.ContainsKey(username))
                {
                    Label1.Text = "Invalid username or password";
                }

                else if (password != Users[username])
                {
                    Label1.Text = "Invalid username or password";
                }

                else
                {
                    FormsAuthentication.RedirectFromLoginPage(username, CheckB.Checked);
                }

            }


        }
    }
}