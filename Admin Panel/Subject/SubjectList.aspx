<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectList.aspx.cs" Inherits="Admin_Panel_Subject_SubjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class ="container" style="padding-top : 50px">
    <div class="row">
        <div class="col-md-12">
            <h1>
                Subject LIST </h1>
                <br />
              <h5>  <asp:Label ID="lblmsg" runat="server" ></asp:Label>
            </h5>
        </div>
         <asp:HyperLink runat="server" ID ="hlSubjectAdd" Text ="Add New Subject" NavigateUrl ="~/Admin Panel/Subject/SubjectAddEdit.aspx" CssClass ="btn btn-primary" /><br />
        <div class ="col-12" >
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
        </div>
    </div>
            <hr />
        <asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="false" CssClass ="table table-bordered table-hover" OnRowCommand="gvSubject_RowCommand">
            <Columns>
                <asp:TemplateField  HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID ="hlEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/Subject/SubjectAddEdit.aspx?SubjectID="+Eval("SubjectID").ToString() %>'>Edit</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button Id="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("SubjectID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SubjectID" HeaderText ="ID" />
                <asp:BoundField DataField="SubjectCode" HeaderText ="Code" />
                <asp:BoundField DataField="SubjectName" HeaderText ="Name" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>


                                    