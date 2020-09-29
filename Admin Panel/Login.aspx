<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Panel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/js/bootstrap.min.js"></script>
</head>
<body>
      <form id="form1" runat="server">
    <div class="container" style="padding-top : 50px">
        <div class ="row">
            <div class="col-md-12">
               <h1>
                   Login Form 
                <asp:Label runat="server" ID="lblPageHeader" />
            </h1><hr />
            </div>
        </div>
            <div class="form-group row">
                <label for="txtUserName" class="col-sm-2 col-from-label">User Name</label>
                <div class="col-sm-4">
                    <asp:TextBox runat ="server" ID="txtUserName" CssClass ="form-control" placeholder="Enter User Name" />
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server"  ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Enter User Name" ForeColor="Red" ValidationGroup="User"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="form-group row">
                <label for="txtPassword" class="col-sm-2 col-from-label">Password</label>
                <div class="col-sm-4">
                    <asp:TextBox runat ="server" ID="txtPassword" TextMode="Password" CssClass ="form-control" placeholder="Enter Password" />
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="User"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-4">
                     <asp:Label ID="lblMessage" runat="server" CssClass="alert-success" EnableViewState="False" ForeColor="#00CC00"></asp:Label>

                </div>
                <div class="col-sm-2 ">
                     <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="User" cssclass="btn btn-primary " OnClick="btnLogin_Click" /> &nbsp;

                     <asp:Button ID="btnClear" runat="server" Text="Clear" ValidationGroup="User" cssclass="btn btn-danger " /> &nbsp;
            </div>
                <div class="col-md-12 ml-3 ">
                    <i >Create new account ?</i>
                    <asp:HyperLink runat="server" ID="hlSignUp" NavigateUrl="~/Admin Panel/SignUp.aspx">
                            <i class="text-primary">SignUp</i>
                    </asp:HyperLink>
                </div>
    </div> 
        </form>
</body>
</html>
