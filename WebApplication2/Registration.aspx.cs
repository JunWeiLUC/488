using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Web.Security;
using System.Collections.Generic;

namespace WebApplication2
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static List<string> AccountList()
        {
            List<string> Accounts = new List<string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(HttpContext.Current.Server.MapPath("Accounts.xml"));
            var root = xmldoc.DocumentElement;
            var nodes = root.SelectNodes("Account");
            foreach (XmlNode node in nodes)
            {
                Accounts.Add(node.Attributes[0].Value);
            }
            return Accounts;
        }

        private string Usernamevalidation(string s)
        {
            string username = s;
            bool validUsername = username.All(c => Char.IsLetterOrDigit(c));
            string label = "";
            if (username.Length < 8 || username.Length > 12)
            {
                label = "Invalid username, must be between 8-12 characters!";
            }

            else if (!validUsername)
            {
                label = "Invalid username, must use letters or numbers!";
            }

            else
            {
                List<string> Accounts = AccountList();

                if (Accounts.Contains(username))
                {
                    label = "Username is already exist. Please choose another one!";
                }

                else
                {
                    label = "You can use this username.";
                }
            }

            return label;
        }

        private string PasswordValidation(string s)
        {
            string password = s;
            string label = "";
            bool validpassword = password.All(c => Char.IsLetterOrDigit(c) || c.Equals('!') || c.Equals('@') || c.Equals('#') || c.Equals('$') || c.Equals('%'));

            bool validpassword2 = password.Contains("!") || password.Contains("@") || password.Contains("#") || password.Contains("$") || password.Contains("%");

            if (password.Length < 6 || password.Length > 8)
            {
                label = "Invalid password, must be between 6-8 characters!";
            }

            else if (!validpassword)
            {
                label = "Invalid password, must use letters, numbers or special characters above!";
            }

            else if (!(password.Any(char.IsUpper) && password.Any(char.IsDigit)))
            {
                label = "Invalid password, must have at least one upper case letter and one number!";
            }

            else if (!validpassword2)
            {
                label = "Invalid password, must have at least one special character!";
            }

            else
                label = "OK";

            return label;


        }


        protected void validation_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            usernameVal.Text = "";
            usernameVal.Text = Usernamevalidation(username);

        }

        protected void creating_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string label = Usernamevalidation(username);
            int validation = 1;
            while (true)
            {
                if (label == "You can use this username.")
                {
                    creatingInfo.Text = "";
                }

                else
                {
                    creatingInfo.Text = label;
                    validation = 0;
                    break;
                }


                string password = Password.Text;
                label = PasswordValidation(password);
                if (label == "OK")
                {
                    creatingInfo.Text = label;
                }

                else
                {
                    creatingInfo.Text = label;
                    validation = 0;
                    break;
                }


                string rePassword = RePassowrd.Text;
                if (password != rePassword)
                {
                    creatingInfo.Text = "Password dosn't match!";
                    validation = 0;
                    break;
                }

                if (validation == 1)
                {
                    password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

                    string ausername = username;
                    string apassword = password;
                    string FirstName = FName.Text;
                    string LastName = LName.Text;

                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(HttpContext.Current.Server.MapPath("Accounts.xml"));
                    XmlElement Account = xdoc.CreateElement("Account");
                    Account.SetAttribute("username", ausername);
                    Account.SetAttribute("password", apassword);
                    Account.SetAttribute("FirstName", FirstName);
                    Account.SetAttribute("LastName", LastName);

                    xdoc.DocumentElement.AppendChild(Account);

                    xdoc.Save(HttpContext.Current.Server.MapPath("Accounts.xml"));

                    Server.Transfer("Login.aspx", true);
                }
            }
        }

    }
}