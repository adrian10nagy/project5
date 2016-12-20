namespace Admin.Offers
{
    using Business.Managers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
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
            Response.Redirect("AddEditOffer.aspx?offerId=" + e.NewEditIndex);
        }

        private void BindDataGridView()
        {
            var products = OffersManager.GetAll();
            grdOffers.DataSource = products;
            grdOffers.DataBind();
        }

    }
}