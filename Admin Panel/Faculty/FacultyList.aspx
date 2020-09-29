<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="FacultyList.aspx.cs" Inherits="Admin_Panel_Faculty_FacultyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class ="container" style="padding-top : 50px">
    <div class="row">
        <div class="col-md-12">
            <h1>
                Faculty LIST </h1>
                <br />
              <h5>  <asp:Label ID="lblmsg" runat="server" ></asp:Label>
            </h5>
        </div>
         <asp:HyperLink runat="server" ID ="hlFacultyAdd" Text ="Add New Faculty" NavigateUrl ="~/Admin Panel/Faculty/FacultyAddEdit.aspx" CssClass ="btn btn-primary" /><br />
        <div class ="col-12" >
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
        </div>
    </div>
            <hr />
        <asp:GridView ID="gvFaculty" runat="server" AutoGenerateColumns="false" CssClass ="table table-bordered table-hover" OnRowCommand="gvFaculty_RowCommand">
            <Columns>
                <asp:TemplateField  HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID ="hlEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/Faculty/FacultyAddEdit.aspx?FacultyID="+Eval("FacultyID").ToString() %>'>Edit</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button Id="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("FacultyID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FacultyID" HeaderText ="ID" />
                <asp:BoundField DataField="FacultyName" HeaderText ="Name" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>