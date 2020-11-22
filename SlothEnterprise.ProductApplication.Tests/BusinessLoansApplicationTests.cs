using Moq;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using System;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    /// <summary>
    /// These tests cover behaviour specific to Business Loans, checking that Company Data and Loans Requests get correctly mapped
    /// </summary>
    public class BusinessLoansApplicationTests
    {
        BusinessLoansApplication _application;

        public BusinessLoansApplicationTests()
        {
            _application = new BusinessLoansApplication(new Mock<IBusinessLoansService>().Object)
            {
                CompanyData = new SellerCompanyData("Amazon", 111, "Mr Jeff Bezos", new DateTime(1994, 7, 5)),
                Product = new BusinessLoans()
                {
                    Id = 1,
                    InterestRatePerAnnum = 4,
                    LoanAmount = 2500000
                }
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

        [Fact]
        public void GetLoansRequestFromBusinessLoans()
        {
            var loansRequest = _application.GetLoansRequestFromBusinessLoans();

            Assert.Equal(_application.Product.InterestRatePerAnnum, loansRequest.InterestRatePerAnnum);
            Assert.Equal(_application.Product.LoanAmount, loansRequest.LoanAmount);
        }
    }
}
