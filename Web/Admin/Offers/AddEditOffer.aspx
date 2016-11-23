<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditOffer.aspx.cs" Inherits="Admin.Offers.AddEditOffer" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
        <asp:Label ID="lblStatus" runat="server" CssClass="message-success"></asp:Label>
        <asp:HiddenField ID="offerId2" runat="server" />
        <asp:TextBox Visible="false" ID="txtOfferId" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblOfferTitle" runat="server" Text="Title"></asp:Label>
        <asp:TextBox  ID="txtOfferTitle" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOfferTitle" CssClass="field-validation-error" ErrorMessage="The Offer Title field is required." />
        <br />
        <br />
        <asp:Label ID="lblOfferDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtOfferDescription" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOfferDescription" CssClass="field-validation-error" ErrorMessage="The Description field is required." />
        <br />
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtOfferPrice" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOfferPrice" CssClass="field-validation-error" ErrorMessage="The Price field is required." />
        <br />
        <br />
        <asp:Label ID="lblOfferType" runat="server" Text="Offer Type"></asp:Label>
        <asp:DropDownList ID="drpOfferType" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblProduct" runat="server" Text="Product"></asp:Label>
        <asp:DropDownList ID="drpProduct" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
        <asp:DropDownList ID="drpCategory" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblCompany" runat="server" Text="Company"></asp:Label>
        <asp:DropDownList ID="drpCompany" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidateRequestMode="Disabled" OnClick="btnCancel_Click"/>
    </div>
</asp:Content>