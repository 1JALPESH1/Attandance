<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="FacultyWiseSubjectList.aspx.cs" Inherits="Admin_Panel_FacultyWiseSubject_FacultyWiseSubjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class ="container" style="padding-top : 50px">
    <div class="row">
        <div class="col-md-12">
            <h1>
                FACULTY WISE SUBJECT LIST
            </h1>
              <h5>  <asp:Label ID="lblmsg" runat="server" ></asp:Label>
            </h5>
        </div>
         <asp:HyperLink runat="server" ID ="hlFacultyWiseSubjectAdd" Text ="Add New Faculty Wise Subject" NavigateUrl ="~/Admin Panel/FacultyWiseSubject/FacultyWiseSubjectAddEdit.aspx" CssClass ="btn btn-primary" /><br />
        <div class ="col-12" >
            <asp:Label ID="lblMessage" runat="server" EnableViewSubject="False"></asp:Label>
        </div>
    </div>
            <hr />
        <asp:GridView ID="gvFacultyWiseSubject" runat="server" AutoGenerateColumns="false" CssClass ="table table-bordered table-hover" OnRowCommand="gvFacultyWiseSubject_RowCommand">
            <Columns>
                <asp:TemplateField  HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID ="hlEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/FacultyWiseSubject/FacultyWiseSubjectAddEdit.aspx?FacultyWiseSubjectID="+Eval("FacultyWiseSubjectID").ToString() %>'>Edit</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button Id="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("FacultyWiseSubjectID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FacultyWiseSubjectID" HeaderText="FacultyWiseSubject ID"/>
                <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name" />
                <asp:BoundField DataField="SubjectName" HeaderText="Subject Name" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>

