<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCompanies.aspx.cs" Inherits="Admin.Companies.Manage"  MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <ul>
            <li><a runat="server" href="~/Companies/AddEdit">Add new Company</a></li>
        </ul>
    </div>
    <div>
        <asp:GridView ID="grdCompanies" runat="server"  DataKeyNames = "Id"
            AutoGenerateEditButton="True" AutoGenerateSelectButton="True" AutoGenerateColumns="False"
            OnRowEditing="grdCompanies_RowEditing" OnRowUpdating="grdCompanies_RowUpdating" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField Id="Id" runat="server" Value='<% #DataBinder.Eval(Container.DataItem, "Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="False"/>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="Id_County" HeaderText="Id_County" />
            </Columns>
        </asp:GridView>
        Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" CssClass="field-validation-error" ErrorMessage="The Name field is required." />
        <br />
        Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="field-validation-error" ErrorMessage="The Email field is required." />
        <br />
        Address: <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress" CssClass="field-validation-error" ErrorMessage="The Address field is required." />
        <br />
        Phone: <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhone" CssClass="field-validation-error" ErrorMessage="The Phone field is required." />
        <br />
        IdCounty: <asp:TextBox ID="txtCounty" runat="server">1</asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCounty" CssClass="field-validation-error" ErrorMessage="The County field is required." />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
    </div>
</asp:Content>
