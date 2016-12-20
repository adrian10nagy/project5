
namespace Admin.Products
{
    using Business.Helpers;
    using Business.Managers;
    using DAL.Entities;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataGridView();
            }
        }

        protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProducts.EditIndex = e.NewEditIndex;
            BindDataGridView();
        }

        protected void grdProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)grdProducts.Rows[e.RowIndex];
            HiddenField cId = (HiddenField)gvRow.FindControl("Id");
            TextBox cName = (TextBox)gvRow.Cells[3].Controls[0];
            TextBox productTypeId = (TextBox)gvRow.Cells[4].Controls[0];

            var product = new Product
            {
                Id = cId.Value.ToInt(),
                ProductType = new ProductType { Id = productTypeId.Text.ToInt() },
                Name = cName.Text,
            };

            ProductsManager.Update(product);
            grdProducts.EditIndex = -1;
            BindDataGridView();
        }

        private void BindDataGridView()
        {
            var products = ProductsManager.GetAll();
            grdProducts.DataSource = products;
            grdProducts.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                ProductType = new ProductType { Id = txtProductType.Text.ToInt() },
                Name = txtName.Text,
            };

            ProductsManager.Insert(product);

            ResetFields();
            BindDataGridView();
        }

        private void ResetFields()
        {
            txtName.Text = string.Empty;
            txtProductType.Text = string.Empty;
        }
    }
}