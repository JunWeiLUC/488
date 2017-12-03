<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome to log in page</h1>
        <div>
             <table id="table1">

                <tr>
                     <td style="text-align:right">Username</td>
                    <td>
                        <asp:textbox id="Username" runat="server" Text=""></asp:textbox>
 
                    </td>

                </tr>

                <tr>
                    <td style="text-align:right">Password</td>
                    <td>
                        <asp:textbox id="Password" runat="server" Text="" TextMode="Password"></asp:textbox>

                    </td>
                </tr>

     
           <tr>
               <td>
            <asp:Button ID="button1" runat="server" Text="Log in"  onclick="login_Click">
            </asp:Button>
                   </td>
               <td>
             <asp:CheckBox ID="CheckB" Text="Remeber Me" runat="server" />
          </td>
               </tr>
                 </table>
                
                   </div>


        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

      



        <br />
        <br />
        <br />

      
         <asp:HyperLink ID="toMainpage" runat="server"
	                   NavigateUrl="~/Default.aspx">
	                   Back to Main Page.
	        </asp:HyperLink>
        <br />
         <br />
         <br />
                 <asp:HyperLink ID="Registration" runat="server"
	                   NavigateUrl="~/Registration.aspx">
	                   Registration.
	        </asp:HyperLink>

    </form>
</body>
</html>


