using Business.Managers;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Companies
{
    public partial class AddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var companyId = Request.QueryString["companyId"];
            var counties = LocationManager.GetAllCounties().ToArray();

            var x = counties.Select(c => new ListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToArray();

            drpCompanyCounty.Items.AddRange(x);
            drpCompanyCounty.DataBind();

            if(!String.IsNullOrEmpty(companyId))
            {
                var id = 0;
                int.TryParse(companyId, out id);
                var company = CompaniesManager.GetById(id);
                SetFields(company, counties);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Companies/ManageCompanies");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var companyPhone = txtCompanyPhone.Text;
            
            var companyId = 0;
            int.TryParse(txtCompanyId.Text.ToString(), out companyId);


            var countyid = 0;
            int.TryParse(drpCompanyCounty.SelectedValue.ToString(), out countyid);

            var company = new Company
            {
                Email = txtCompanyEmail.Text,
                Id_County = countyid,
                Phone = companyPhone,
                Name = txtCompanyName.Text,
                Id = companyId,
                JoinDate = DateTime.Now,
                Address = txtAddress.Text,
            };

            if (companyId == 0)
            {
                CompaniesManager.Insert(company);
            }
            else
            {
                CompaniesManager.Update(company);
            }

            ClearFields();
            lblStatus.Text = "Successfully Added";
        }

        private void ClearFields()
        {
            txtCompanyName.Text = string.Empty;
            txtCompanyEmail.Text = string.Empty;
            txtCompanyPhone.Text = string.Empty;
            txtCompanyId.Text = string.Empty;
            txtAddress.Text = string.Empty;
            drpCompanyCounty.SelectedIndex = -1;
            lblStatus.Text = string.Empty;
        }

        private void SetFields(Company company, County[] counties)
        {
            txtCompanyName.Text = company.Name;
            txtCompanyEmail.Text = company.Email;
            txtCompanyPhone.Text = company.Phone;
            txtCompanyId.Text = company.Id.ToString();
            txtAddress.Text = company.Address;
            drpCompanyCounty.SelectedIndex = company.Id_County;
        }


    }
}