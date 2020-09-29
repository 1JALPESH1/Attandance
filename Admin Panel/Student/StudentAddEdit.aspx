<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAddEdit.aspx.cs" Inherits="Admin_Panel_Student_StudentAddEdit" %>

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
                <label for="txtStudentName" class="col-sm-2 col-form-label">Student Name</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="txtStudentName" CssClass="form-control" placeholder="Enter Student Name" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvStudentName" ControlToValidate="txtStudentName" Display="Dynamic" ErrorMessage="Enter Student Name" ForeColor="Red" ValidationGroup="Student" />
                </div>
            </div>
            <div class="form-group row">
                <label for="txtEnrollmentNo" class="col-sm-2 col-form-label">Enrollment Number</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtEnrollmentNo" CssClass="form-control" placeholder="Enter EnrollmentNo" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvEnrollmentNo" ControlToValidate="txtEnrollmentNo" Display="Dynamic" ErrorMessage="Enter EnrollmentNo" ForeColor="Red" ValidationGroup="Student" />
                </div>
                  <label for="txtBranchName" class="col-sm-2 col-form-label">Branch</label>
                <div class="col-sm-4">
                    <asp:DropDownList runat="server" ID="ddlBranch" CssClass="form-control" placeholder="Select Branch" AutoPostBack="True" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="rvfBranch" ControlToValidate="ddlBranch" Display="Dynamic" ErrorMessage="Select Branch" ForeColor="Red" ValidationGroup="Student" />
                </div>
                
            </div>

            <div class="form-group row">
                <label for="txtSemester" class="col-sm-2 col-form-label">Semester</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtSemester" CssClass="form-control" placeholder="Enter Semster" />
                    <asp:RequiredFieldValidator runat="server" ID="rvfSemester" ControlToValidate="txtSemester" Display="Dynamic" ErrorMessage="Enter Semester" ForeColor="Red" ValidationGroup="Student" />
                </div>
                <label for="txtBatchNo" class="col-sm-2 col-form-label">Batch No</label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtBatchNo" CssClass="form-control" placeholder="Enter Semster" />
                    <asp:RequiredFieldValidator runat="server" ID="rvfBatchNo" ControlToValidate="txtBatchNo" Display="Dynamic" ErrorMessage="Enter BatchNo" ForeColor="Red" ValidationGroup="Student" />
                </div>
                 
                
            </div>
             
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Label runat="server" CssClass="alert-success" ID="lblMessage" EnableViewState="false" ForeColor="#00CC00"/>
                
                </div>
                <div class="col-sm-2 pull-right">
                    <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Student" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin Panel/Student/StudentList.aspx" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
</asp:Content>

