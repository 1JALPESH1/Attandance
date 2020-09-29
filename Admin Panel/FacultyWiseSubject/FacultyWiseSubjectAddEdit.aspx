<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="FacultyWiseSubjectAddEdit.aspx.cs" Inherits="Admin_Panel_FacultyWiseSubject_FacultyWiseSubjectAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        <b>
                            <asp:Label runat="server" ID="lblPageHeader" /></b>
                    </h1>
                    <hr />
                </div>
                <br />
            </div>
            <br />
            
                
            <div class="form-group row">
                <label for="txtFacultyName" class="col-sm-2 col-form-label">Faculty</label>
                <div class="col-sm-4">
                    <asp:DropDownList runat="server" ID="ddlFaculty" CssClass="form-control" placeholder="Select Faculty" AutoPostBack="True" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="rvfFaculty" ControlToValidate="ddlFaculty" Display="Dynamic" ErrorMessage="Select Faculty" ForeColor="Red" ValidationGroup="Faculty" />
                </div>
                <label for="txtSubjectName" class="col-sm-2 col-form-label">Subject</label>
                <div class="col-sm-4">
                    <asp:DropDownList runat="server" ID="ddlSubject" CssClass="form-control" placeholder="Select Subject" AutoPostBack="True"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="rvfSubject" ControlToValidate="ddlSubject" Display="Dynamic" ErrorMessage="Select Subject" ForeColor="Red" ValidationGroup="Faculty" />
                </div>
            </div>
            <div class="form-group row">
               <div class="col-sm-10">
                    <asp:Label ID="lblMessage" runat="server" CssClass="alert-success" EnableViewSubject="False" ForeColor="#00CC00"></asp:Label>
                </div>
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Faculty" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin Panel/FacultyWiseSubject/FacultyWiseSubjectList.aspx" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
</asp:Content>

