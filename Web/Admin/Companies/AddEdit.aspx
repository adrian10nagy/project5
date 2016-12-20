<%@ Page Title="Add Or Edit company" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEdit.aspx.cs" Inherits="Admin.Companies.AddEdit" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
        <asp:Label ID="lblStatus" runat="server" CssClass="message-success"></asp:Label>
        <asp:HiddenField ID="companyId2" runat="server" />
        <asp:TextBox Visible="false" ID="txtCompanyId" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label>
        <asp:TextBox  ID="txtCompanyName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCompanyName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
        <br />
        <br />
        <asp:Label ID="lblCompanyEmail" runat="server" Text="Company Email"></asp:Label>
        <asp:TextBox ID="txtCompanyEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCompanyEmail" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
        <br />
        <br />
        <asp:Label ID="lblCompanyPhone" runat="server" Text="CompanyPhone"></asp:Label>
        <asp:TextBox ID="txtCompanyPhone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCompanyPhone" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
        <br />
        <br />
        <asp:Label ID="lblCompanyCounty" runat="server" Text="CompanyCounty"></asp:Label>
        <asp:DropDownList ID="drpCompanyCounty" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress" CssClass="field-validation-error" ErrorMessage="The Address field is required." />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" ValidateRequestMode="Disabled"/>
    </div>
</asp:Content>
