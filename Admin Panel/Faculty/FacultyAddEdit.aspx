<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="FacultyAddEdit.aspx.cs" Inherits="Admin_Panel_Faculty_FacultyAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="padding-top : 50px">
        <div class ="row">
            <div class="col-md-12">
               <h1>
                <asp:Label runat="server" ID="lblPageHeader" />
            </h1><hr />
            </div>
        </div>
            <div class="form-group row">
                <label for="txtCityName" class="col-sm-2 col-from-label">Faculty Name</label>
                <div class="col-sm-10">
                    <asp:TextBox runat ="server" ID="txtFacultyName" CssClass ="form-control" placeholder="Enter Faculty Name" />
                    <asp:RequiredFieldValidator ID="rfvFacultyName" runat="server"  ControlToValidate="txtFacultyName" Display="Dynamic" ErrorMessage="Enter Faculty Name" ForeColor="Red" ValidationGroup="City"></asp:RequiredFieldValidator>
                </div>
            </div>
           
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Label ID="lblMessage" runat="server" CssClass="alert-success" EnableViewState="False" ForeColor="#00CC00"></asp:Label>
                </div>
                <div class="col-sm-2 pull-right">

                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="City" cssclass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                    <asp:HyperLink ID="hlCancel" runat="server" Text ="Cancel" CssClass ="btn btn-danger" NavigateUrl ="~/Admin Panel/Faculty/FacultyList.aspx" />

                </div>
            </div>
    </div> 
</asp:Content>

