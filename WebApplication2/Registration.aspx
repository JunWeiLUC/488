<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication2.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
              div.container {
                  position:absolute;width:100%;top:35%;text-align:center;
                  width:90%; 
                  margin:1%;
                    }
         table#table1 {
                 text-align:center; 
                  margin-left:auto; 
                  margin-right:auto; 
                  width:100px;
                    }
       
        .wrapper{position:absolute;width:100%;top:55%;text-align:center;}
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome to account registration!</h1>
        <div>
            <ul>
            <li>
                If you don't have account, you can create new account with your user name and set up password use sign up. 
            </li>
            <li>
                You can only use letters and numbers for your username, and it should be 8-12 characters long.
            </li>
            <li>
                For password, you can use letters, numbers, and special characters "!","@","#","$","%". 
            </li>
            <li>
                You need use at least one upper case letter, one number and one special character, and 6-8 character long.
            </li>
            </ul>
            
        </div>

       <div class="container" style="left: -10px; top: -2%">
         </div>

        <div class="wrapper">



                       <asp:Button ID="button1" runat="server" Text="Create Account"  onclick="creating_Click">
            </asp:Button>
 

         </div>
         <div>


         </div>
                 <div>


         </div>


            <table id="table1">

                <tr>
                     <td style="text-align:right">Username</td>
                    <td>
                        <asp:TextBox ID="Username" Text="" runat="server"></asp:TextBox>
                    </td>
                    <td>
                         <asp:button ID="usernamevalidation" Text="check if your username is available" runat="server" onclick="validation_Click"></asp:button>
                    </td>
                </tr>

                <tr>
                     <td style="text-align:right">First Name</td>
                    <td>
                        <asp:TextBox ID="FName" Text="" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                     <td style="text-align:right">Last Name</td>
                    <td>
                        <asp:TextBox ID="LName" Text="" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Password</td>
                     <td>
                        <asp:TextBox ID="Password" TextMode="Password" Text="" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Confirm Password</td>
                     <td>
                        <asp:TextBox ID="RePassowrd" TextMode="Password" Text="" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>


                <asp:Label ID="usernameVal" runat="server" Font-Bold="True"
	               Font-Size="Large" Text="" Visible="True">
	            </asp:Label>
 

                <br />

                <asp:Label ID="creatingInfo" runat="server" Font-Bold="True"
	               Font-Size="Large" Text="" Visible="True">
	            </asp:Label>
 

        <br />
        <br />

      
         <asp:HyperLink ID="toMainpage" runat="server"
	                   NavigateUrl="~/Default.aspx">
	                   Back to Main Page.
	        </asp:HyperLink>


    </form>
</body>
</html>


