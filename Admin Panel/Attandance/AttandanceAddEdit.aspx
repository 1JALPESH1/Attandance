<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/MasterPage.master" AutoEventWireup="true" CodeFile="AttandanceAddEdit.aspx.cs" Inherits="Admin_Panel_Attandance_AttandanceAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> <div class="container" style="padding-top: 50px;">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label runat="server" ID="lblPageHeader" />
                </h1><hr />
                
            </div><br />
        </div><br />
        
        <div class="form-group row">
            <label for="txtDate" class="col-md-2 col-form-label">Attandance Date</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtAttandanceDate" CssClass="form-control" TextMode="Date" placeholder="Enter Date" />
                <asp:RequiredFieldValidator  runat="server"  ID="rfvAttandanceDate" ControlToValidate="txtAttandanceDate" Display="Dynamic" ErrorMessage="Enter Date" ForeColor="Red" ValidationGroup="Attandance"/> 
            </div>
        
            <label for="txtSemester" class="col-md-2 col-form-label">Semester</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtSemester" CssClass="form-control" placeholder="Enter Semester" MaxLength="1" TextMode="Phone" />
                <asp:RequiredFieldValidator  runat="server"  ID="rvfSemester" ControlToValidate="txtSemester" Display="Dynamic" ErrorMessage="Enter Semester" ForeColor="Red" ValidationGroup="Attandance"/> 
                <asp:RegularExpressionValidator ID="revSemester" runat="server" ControlToValidate="txtSemester" Display="Dynamic" ErrorMessage="Enter Valid Semester" ForeColor="Red" ValidationExpression="^([0-8]{1})$"></asp:RegularExpressionValidator>
            </div>
        </div>
       
        <div class="form-group row">
            <label for="ddlFaculty" class="col-md-2 col-form-label">Faculty</label>
            <div class="col-md-4">
                <asp:dropDownList runat="server" ID="ddlFaculty" CssClass="form-control" placeholder="Select Faculty" AutoPostBack="True" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" >

                </asp:dropDownList>
                <asp:RequiredFieldValidator  runat="server"  ID="rvfFaculty" ControlToValidate="ddlFaculty" Display="Dynamic" ErrorMessage="Select Faculty" ForeColor="Red" ValidationGroup="Attandance"/> 
            </div>
            <label for="ddlBranch" class="col-md-2 col-form-label">Branch</label>
            <div class="col-md-4">
                <asp:dropDownList runat="server" ID="ddlBranch" CssClass="form-control" placeholder="Select Branch" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">

                </asp:dropDownList>
                <asp:RequiredFieldValidator  runat="server"  ID="rvfBranch" ControlToValidate="ddlBranch" Display="Dynamic" ErrorMessage="Select Branch" ForeColor="Red" ValidationGroup="Attandance"/> 
            </div>
            
        </div>
        <div class="form-group row">
            <label for="ddlSubject" class="col-md-2 col-form-label">Subject</label>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlSubject" CssClass="form-control" placeholder="Select Subject" AutoPostBack="True" ></asp:DropDownList>
                <asp:RequiredFieldValidator  runat="server"  ID="rvfSubject" ControlToValidate="ddlSubject" Display="Dynamic" ErrorMessage="Select Subject" ForeColor="Red" ValidationGroup="Attandance"/> 
            </div>
        </div>
      <div class="form-group row">
            <div class="col-md-10">
                <asp:Label runat="server" ID="lblNote"  EnableViewState="True" ForeColor="#00CC00" />
            </div>
            <div class="col-md-2">
            </div>
        </div>
          <div class="form-group row">  
            <label for="cblStudent" class="col-md-2 col-form-label">Student</label>
            <div class="col-md-4">
                <asp:CheckBoxList runat="server" ID="cblStudent"  placeholder="Select Student " SelectionMode="Multiple"  ValidationGroup="Attandance"  ></asp:CheckBoxList>
            </div> 
        </div>

        

        <div class="form-group row">
            <div class="col-md-5">
                <asp:Label runat="server" ID="lblMessage" CssClass="alert-success" EnableViewState="False" ForeColor="#00CC00" />
            </div>
            <div class="col-md-5">
                <asp:Label runat="server" ID="lbl2" CssClass="alert-success" EnableViewState="False" ForeColor="#00CC00" />
            </div>
           
            <div class="col-md-2 pull-right">
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Attandance" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />&nbsp;
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/Admin Panel/Attandance/AttandanceList.aspx"   CssClass="btn btn-danger"  />
            </div>

        </div>
     <div class="form-group row">
            <div class="col-md-6">
                <asp:Label runat="server" ID="lblPresentNumber"  EnableViewState="False"  />
            </div>
             <div class="col-md-6">
                <asp:Label runat="server" ID="lblAbsentNumber" EnableViewState="False"  />
            </div>

            

        </div>
    </div>
</asp:Content>

