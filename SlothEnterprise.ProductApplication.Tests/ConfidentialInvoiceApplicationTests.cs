using Moq;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    /// <summary>
    /// These tests cover behaviour specific to Confidential Invoice Applications, checking that Company Data gets correctly mapped
    /// </summary>
    public class ConfidentialInvoiceApplicationTests
    {
        ConfidentialInvoiceApplication _application;

        public ConfidentialInvoiceApplicationTests()
        {
            _application = new ConfidentialInvoiceApplication(new Mock<IConfidentialInvoiceService>().Object)
            {
                CompanyData = new SellerCompanyData("Amazon", 111, "Mr Jeff Bezos", new DateTime(1994, 7, 5))
            };
        }

        [Fact]
        public void GetCompanyDataFromSellerCompanyData()
        {
            var companyData = _application.GetCompanyDataFromSellerCompanyData();

            Assert.Equal(_application.CompanyData.DirectorName, companyData.DirectorName);
            Assert.Equal(_application.CompanyData.Founded, companyData.CompanyFounded);
            Assert.Equal(_application.CompanyData.Name, companyData.CompanyName);
            Assert.Equal(_application.CompanyData.Number, companyData.CompanyNumber);
        }
    }
}
