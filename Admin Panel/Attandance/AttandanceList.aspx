<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="AttandanceList.aspx.cs" Inherits="Admin_Panel_Attandance_AttandanceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="padding-top: 50px">
        <div class="row">
            <div class="col-md-12">
                <h1>Attandance List</h1>
                <h5>
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </h5>
                <br />
                <h4>
                    <asp:Label ID="lblUserSession" runat="server" CssClass="text-dark" EnableViewState="false"></asp:Label></h4>
            </div>
            <div class="col-md-12">
                <br />
                <asp:HyperLink ID="hlAttandanceAdd" runat="server" Text="Fill The Attandance" NavigateUrl="~/Admin Panel/Attandance/AttandanceAddEdit.aspx" CssClass="btn btn-primary" />
            </div>
        </div>
        <br />

        <div class="form-group row">
            <%--<label for="txtDate" class="col-md-2 col-form-label">Attandance Date</label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtAttandanceDate" CssClass="form-control" TextMode="Date" placeholder="Enter Date" />
                <asp:RequiredFieldValidator runat="server" ID="rfvAttandanceDate" ControlToValidate="txtAttandanceDate" Display="Dynamic" ErrorMessage="Enter Date" ForeColor="Red" ValidationGroup="Attandance" />
            </div>--%>
             <label for="ddlFaculty" class="col-md-2 col-form-label">Faculty</label>
            <div class="col-md-4">
                <asp:dropDownList runat="server" ID="ddlFaculty" CssClass="form-control" placeholder="Select Faculty" AutoPostBack="True"  >

                </asp:dropDownList>
                <asp:RequiredFieldValidator  runat="server"  ID="rvfFaculty" ControlToValidate="ddlFaculty" Display="Dynamic" ErrorMessage="Select Faculty" ForeColor="Red" ValidationGroup="Attandance"/> 
            </div>
            <div class="col-md-2">
                <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary pull-right" OnClick="btnSearch_Click" />&nbsp;

            </div>
        </div>
        <asp:Label runat="server" ID="lblMessage" CssClass="alert-danger" EnableViewState="false" />
        <hr />
        <div class="row">
            <div class="col-md-12">
                <br />
                <asp:GridView ID="gvAttandance" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-responsive table-responsive-sm" OnRowCommand="gvAttandance_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit Attandance">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/Attandance/AttandanceAddEdit.aspx?AttandanceID=" + Eval("AttandanceID").ToString().Trim() %>'>Edit</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete Attandance">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("AttandanceID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attandance List">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlAttandanceDetail" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin Panel/AttandanceDetail/AttandanceDetailList.aspx?AttandanceID=" + Eval("AttandanceID").ToString().Trim() %>'>View List</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AttandanceId" HeaderText="Attandance ID" />
                        <asp:BoundField DataField="AttandanceDate" HeaderText="Attancdance Date" />
                        <asp:BoundField DataField="Semester" HeaderText="Semester" />
                        <asp:BoundField DataField="SubjectName" HeaderText="Subject Name" />
                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                        <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name" />
                        <asp:BoundField DataField="Total" HeaderText="Total Student" />
                        <asp:BoundField DataField="Present" HeaderText="Present Student" />
                        <asp:BoundField DataField="Absent" HeaderText="Absent Student" />

                    </Columns>
                </asp:GridView>

                <br />
            </div>
        </div>
    </div>
</asp:Content>

