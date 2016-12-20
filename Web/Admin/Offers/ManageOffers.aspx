<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageOffers.aspx.cs" Inherits="Admin.Offers.Manage" MasterPageFile="~/Site.Master" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <asp:GridView ID="grdOffers" runat="server" DataKeyNames="Id"
        AutoGenerateEditButton="True" AutoGenerateColumns="False" 
        OnRowEditing="grdProducts_RowEditing">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="Id" runat="server" Value='<% #DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Product.Name" HeaderText="Product Name" />
            <asp:BoundField DataField="Company.Name" HeaderText="Company Name" />
        </Columns>
    </asp:GridView>
</asp:Content>
