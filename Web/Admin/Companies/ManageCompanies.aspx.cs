namespace Admin.Companies
{
    using Business.Managers;
    using DAL.Entities;
    using System;
    using System.Web.UI.WebControls;
    using Business.Helpers;

    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataGridView();
            }
        }

        private void BindDataGridView()
        {
            var companies = CompaniesManager.GetAll();
            grdCompanies.DataSource = companies;
            grdCompanies.DataBind();
        }

        protected void grdCompanies_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            grdCompanies.EditIndex = e.NewEditIndex;
            BindDataGridView();
        }

        protected void grdCompanies_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)grdCompanies.Rows[e.RowIndex];
            HiddenField cId = (HiddenField)gvRow.FindControl("Id");
            TextBox cName = (TextBox)gvRow.Cells[3].Controls[0];
            TextBox cEmail = (TextBox)gvRow.Cells[4].Controls[0];
            TextBox cPhone = (TextBox)gvRow.Cells[6].Controls[0];
            TextBox cIdCounty = (TextBox)gvRow.Cells[7].Controls[0];
            TextBox cAddress = (TextBox)gvRow.Cells[5].Controls[0];

            var company = new Company
            {
                Id = cId.Value.ToInt(),
                Email = cEmail.Text,
                Name = cName.Text,
                Phone = cPhone.Text,
                Id_County = cIdCounty.Text.ToInt(),
                JoinDate = DateTime.Now,
                Address = cAddress.Text
            };

            CompaniesManager.Update(company);
            grdCompanies.EditIndex = -1;
            BindDataGridView();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var company = new Company
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Id_County = txtCounty.Text.ToInt(),
                Phone = txtPhone.Text,
                JoinDate = DateTime.Now,
                Address = txtAddress.Text
            };

            CompaniesManager.Insert(company);

            ResetFields();
            BindDataGridView();
        }

        private void ResetFields()
        {
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCounty.Text = string.Empty;
        }
    }
}