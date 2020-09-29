<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="StudentList.aspx.cs" Inherits="Admin_Panel_Student_StudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="container" style="padding-top : 50px">
    <div class="row">
        <div class="col-md-12">
            <h1>
                Student List
            </h1>
              <h5>  <asp:Label ID="lblmsg" runat="server" ></asp:Label>
            </h5>
        </div>
         <asp:HyperLink runat="server" ID ="hlStudentAdd" Text ="Add New Student" NavigateUrl ="~/Admin Panel/Student/StudentAddEdit.aspx" CssClass ="btn btn-primary" /><br />
        <div class ="col-12" >
            <asp:Label ID="lblMessage" runat="server" EnableViewBranch="False"></asp:Label>
        </div>
    </div>
            <hr />
        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="false" CssClass ="table table-bordered table-hover" OnRowCommand="gvStudent_RowCommand">
            <Columns>
                <asp:TemplateField  HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID ="hlEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/Student/StudentAddEdit.aspx?StudentID="+Eval("StudentID").ToString() %>'>Edit</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button Id="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StudentID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StudentId" HeaderText="Student ID"/>
                <asp:BoundField DataField="EnrollmentNo" HeaderText="EnrollmentNo"/>
                <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                 <asp:BoundField DataField="Semester" HeaderText="Semester" />
                <asp:BoundField DataField="BatchNo" HeaderText="Batch No" />

            </Columns>
        </asp:GridView>
</div>
</asp:Content>

