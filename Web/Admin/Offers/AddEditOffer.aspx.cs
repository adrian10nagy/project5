namespace Admin.Offers
{
    using Business.Managers;
    using DAL.Entities;
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Helpers;

    public partial class AddEditOffer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var offerId = Request.QueryString["offerId"];
            if (!String.IsNullOrEmpty(offerId))
            {
                var id = 0;
                int.TryParse(offerId, out id);
                var offer = OffersManager.GetById(id);
                SetFields(offer);
            }

            if (!Page.IsPostBack)
            {
                // bind categories
                var categories = CategoriesManager.GetAll();
                var categoriesListItem = categories.Select(c => new ListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    }).ToArray();
                drpCategory.Items.AddRange(categoriesListItem);
                drpCategory.DataBind();

                // bnd companies
                var companies = CompaniesManager.GetAll();
                var companiesListItem = companies.Select(c => new ListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToArray();

                drpCompany.Items.AddRange(companiesListItem);
                drpCompany.DataBind();

                // bind OfferTypes
                var itemValues = System.Enum.GetValues(typeof(OfferType));
                var itemNames = System.Enum.GetNames(typeof(OfferType)).ToArray();
                for (int i = 0; i <= itemNames.Length - 1; i++)
                {
                    var item = new ListItem
                    {
                        Text = itemNames[i],
                        Value = itemValues.GetValue(i).ToString()
                    };
                    drpOfferType.Items.Add(item);
                }

                // bind products
                var products = ProductsManager.GetAll();
                var productsListItem = products.Select(c => new ListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToArray();
                drpProduct.Items.AddRange(productsListItem);
                drpProduct.DataBind();
            }
        }

        private void SetFields(Offer offer)
        {
            txtOfferTitle.Text = offer.Title;
            txtOfferDescription.Text = offer.Description;
            txtOfferPrice.Text = offer.Price.ToString();
            drpOfferType.SelectedValue = ((int)offer.OfferType).ToString();
            drpCompany.SelectedValue = offer.Company.Id.ToString();
            drpProduct.SelectedValue = offer.Product.Id.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var offer = new Offer
            {
                Id = txtOfferId.Text.ToInt(),
                Title = txtOfferTitle.Text,
                Description = txtOfferDescription.Text,
                Price = txtOfferPrice.Text.ToInt(),
                Company = new Company 
                {
                    Id = drpCompany.SelectedValue.ToInt()
                },
                Product = new Product
                {
                    Id = drpProduct.SelectedValue.ToInt()
                },
                OfferType = (OfferType)drpOfferType.SelectedValue.ToInt()
            };
            
            var offerId = Request.QueryString["offerId"];
            if (!String.IsNullOrEmpty(offerId))
            {
                OffersManager.Update(offer);
                lblStatus.Text = "Succesfully Updated";
            }
            else
            {
                OffersManager.Inset(offer);
            }
            ResetFields();
        }

        private void ResetFields()
        {
            txtOfferTitle.Text = string.Empty;
            txtOfferDescription.Text = string.Empty;
            txtOfferPrice.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Offers/ManageOffers");

        }
    }
}