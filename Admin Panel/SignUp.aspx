<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Admin_Panel_SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title><meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
     <link href="~/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/js/bootstrap.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server" >
         
     <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        <asp:Label runat="server" ID="lblPageHeader" Text="Registration Form" />
                    </h1>
                    <hr />
                    <asp:Label runat="server" ID="lblMessage"  EnableViewState="false" />
                </div>
                <br />
            </div>
            <br />
            <div class="form-group row">
                <label for="lblUserName" class="col-sm-2 col-form-label">User Name</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Enter User Name" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Enter User Name" CssClass="text-danger"  ForeColor="Red" ValidationGroup="User" />
                </div>
                <label for="lblFullName" class="col-sm-2 col-form-label">Full Name</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" placeholder="Enter Full Name" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvFullName" ControlToValidate="txtFullName" Display="Dynamic" ErrorMessage="Enter Full Name" CssClass="text-danger" ForeColor="Red" ValidationGroup="User" />
                </div>
            </div>
            <div class="form-group row">
                <label for="lblPassword" class="col-sm-2 col-form-label">Password</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Password" CssClass="text-danger" ValidationGroup="User" ForeColor="Red" />
                </div>
                <label for="txtMobileNo" class="col-md-2 col-form-label">Mobile No.</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" placeholder="Enter Mobile No." MaxLength="10" TextMode="Phone" />
                <asp:RequiredFieldValidator  runat="server"  ID="rvfMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile No." ForeColor="Red" ValidationGroup="User"/> 
                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Valid Mobile Number" ForeColor="Red" ValidationExpression="^([0-9]{10})$"></asp:RegularExpressionValidator>
            </div>
               
            </div>
         <div class="form-group row">
            <label for="txtAddress" class="col-md-2 col-form-label">Address</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="Enter Address" TextMode="MultiLine" Rows="3" />
                <asp:RequiredFieldValidator  runat="server"  ID="rfvAddress" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Enter Address" ForeColor="Red" ValidationGroup="User"/> 
            </div>
             
             <label for="txtEmailAddress" class="col-md-2 col-form-label">Email Address</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" placeholder="Enter Email Address" TextMode="Email" />
                <asp:RequiredFieldValidator  runat="server"  ID="rvfEmailAddress" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="User"/> 
                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
         </div>
       
            <div class="form-group row">
                <div class="col-sm-9"></div> 
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSignUp" ValidationGroup="User" Text="SignUp" CssClass="btn btn-primary pull-right" OnClick="btnSignUp_Click" ></asp:Button> &nbsp;
                <asp:HyperLink runat="server" ID="hlClear" Text="Clear" NavigateUrl="~/Admin Panel/SignUp.aspx" CssClass="btn btn-danger" />
                </div>
                <div class="col-md-12 ml-3 text-center" >
                    <i >Do have an account ?</i>
                    <asp:HyperLink runat="server" ID="hlLogin" NavigateUrl="~/Admin Panel/Login.aspx">
                            <i class="text-primary">Login</i>
                    </asp:HyperLink>
                </div>
            </div>
        </div>
        
     
    </form>
</body>
</html>
