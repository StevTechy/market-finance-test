using Moq;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using System;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    /// <summary>
    /// These tests cover behaviour specific to Selective Invoice Discounts, checking that Company Data gets correctly mapped
    /// </summary>
    public class SelectiveInvoiceDiscountApplicationTests
    {
        SelectiveInvoiceDiscountApplication _application;

        public SelectiveInvoiceDiscountApplicationTests()
        {
            _application = new SelectiveInvoiceDiscountApplication(new Mock<ISelectInvoiceService>().Object)
            {
                CompanyData = new SellerCompanyData("Amazon", 111, "Mr Jeff Bezos", new DateTime(1994, 7, 5))
            };
        }

        [Fact]
        public void GetCompanyDataFromSellerCompanyData()
        {
            var companyData = _application.GetCompanyDataFromSellerCompanyData();

            Assert.Equal(_application.CompanyData.Number, companyData.CompanyNumber);
        }
    }
}
