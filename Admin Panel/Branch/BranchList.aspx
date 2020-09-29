<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="BranchList.aspx.cs" Inherits="Admin_Panel_Branch_BranchList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="container" style="padding-top : 50px">
    <div class="row">
        <div class="col-md-12">
            <h1>
                BRANCH LIST </h1>
                <br />
              <h5>  <asp:Label ID="lblmsg" runat="server" ></asp:Label>
            </h5>
        </div>
         <asp:HyperLink runat="server" ID ="hlBranchAdd" Text ="Add New Branch" NavigateUrl ="~/Admin Panel/Branch/BranchAddEdit.aspx" CssClass ="btn btn-primary" /><br />
        <div class ="col-12" >
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
        </div>
    </div>
            <hr />
        <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="false" CssClass ="table table-bordered table-hover" OnRowCommand="gvBranch_RowCommand">
            <Columns>
                <asp:TemplateField  HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID ="hlEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/Branch/BranchAddEdit.aspx?BranchID="+Eval("BranchID").ToString() %>'>Edit</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button Id="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("BranchID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BranchID" HeaderText ="ID" />
                <asp:BoundField DataField="BranchName" HeaderText ="Name" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>


                                    