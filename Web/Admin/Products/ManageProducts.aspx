<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="Admin.Products.Manage" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
        <asp:GridView ID="grdProducts" runat="server"  DataKeyNames = "Id"
            AutoGenerateEditButton="True" AutoGenerateSelectButton="True" AutoGenerateColumns="False" OnRowEditing="grdProducts_RowEditing" OnRowUpdating="grdProducts_RowUpdating">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField Id="Id" runat="server" Value='<% #DataBinder.Eval(Container.DataItem, "Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="ProductType.Name" HeaderText="Product Type (Not for change)"/>
                <asp:BoundField DataField="ProductType.Id" HeaderText="Product Type ID"/>
            </Columns>
        </asp:GridView>
        Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" CssClass="field-validation-error" ErrorMessage="The Name field is required." />
        <br />

        Product Type: <asp:TextBox ID="txtProductType" runat="server">1</asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProductType" CssClass="field-validation-error" ErrorMessage="The Product Type field is required." />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
    </div>
</asp:Content>
