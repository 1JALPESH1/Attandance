<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="AttandanceDetailList.aspx.cs" Inherits="Admin_Panel_AttandanceDetail_AttandanceDetailList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="padding-top: 50px">
        <div class="row">
            <div class="col-md-12">
                <h1>Attandance List</h1>
                 <h5>  <asp:Label ID="Label1" runat="server" ></asp:Label>
            </h5>
                <br />
                <h4><asp:Label ID="lblUserSession" runat="server" CssClass="text-dark" EnableViewState="false"></asp:Label></h4>
            </div>
           
        </div><br />
                <asp:Label runat="server" ID="lblMessage" CssClass="alert-danger" EnableViewState="false"  />


        <hr />
        <div class="row">
            <div class="col-md-12">
                <br />
                <asp:GridView ID="gvAttandanceDetail" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover " >
                    <Columns>
                        
                       <asp:BoundField DataField="AttandanceDate" HeaderText="Attancdance Date"/>
                        <asp:BoundField DataField="Semester" HeaderText="Semester"/>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                        <asp:BoundField DataField="PresentStatus" HeaderText="PresentStatus" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>
        </div>
     
</asp:Content>
