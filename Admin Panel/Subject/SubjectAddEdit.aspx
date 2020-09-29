<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectAddEdit.aspx.cs" Inherits="Admin_Panel_Subject_SubjectAddEdit" %>

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
                <label for="txtCityName" class="col-sm-2 col-from-label">Subject Name</label>
                <div class="col-sm-10">
                    <asp:TextBox runat ="server" ID="txtSubjectName" CssClass ="form-control" placeholder="Enter Subject Name" />
                    <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server"  ControlToValidate="txtSubjectName" Display="Dynamic" ErrorMessage="Enter Subject Name" ForeColor="Red" ValidationGroup="City"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="form-group row">
                <label for="txtCityName" class="col-sm-2 col-from-label">Subject Code</label>
                <div class="col-sm-10">
                    <asp:TextBox runat ="server" ID="txtSubjectCode" CssClass ="form-control" placeholder="Enter Subject Code" />
                    <asp:RequiredFieldValidator ID="rfvSubjectCode" runat="server" ControlToValidate="txtSubjectCode" Display="Dynamic" ErrorMessage="Enter Subject Code" ForeColor="Red" ValidationGroup="City"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Label ID="lblMessage" runat="server" CssClass="alert-success" EnableViewState="False" ForeColor="#00CC00"></asp:Label>
                </div>
                <div class="col-sm-2 pull-right">

                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="City" cssclass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                    <asp:HyperLink ID="hlCancel" runat="server" Text ="Cancel" CssClass ="btn btn-danger" NavigateUrl ="~/Admin Panel/Subject/SubjectList.aspx" />

                </div>
            </div>
    </div> 
</asp:Content>