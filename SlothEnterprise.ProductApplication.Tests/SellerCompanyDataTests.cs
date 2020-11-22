using SlothEnterprise.ProductApplication.Applications;
using System;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    /// <summary>
    /// These tests cover the setup of Company Data within an application, ensuring that data is being set correctly and validation is working
    /// </summary>
    public class SellerCompanyDataTests
    {
        /// <summary>
        /// Checks the validation set on Company Data initialization correctly throws exception if invalid
        /// </summary>
        [Fact]
        public void SetInvalidCompanyData()
        {
            Assert.Throws<Exception>(() => new SellerCompanyData("Company Name", 1, "Director Name", DateTime.Now.AddDays(1)));
        }

        /// <summary>
        /// Covers scenarios where full Company details are being provided
        /// </summary>
        [Fact]
        public void SetValidCompanyData()
        {
            var validCompanyData = new SellerCompanyData("Company Name", 1, "Director Name", new DateTime(2000, 1, 1));
            Assert.Equal("Company Name", validCompanyData.Name);
            Assert.Equal(1, validCompanyData.Number);
            Assert.Equal("Director Name", validCompanyData.DirectorName);
            Assert.Equal(new DateTime(2000, 1, 1), validCompanyData.Founded);
        }

        /// <summary>
        /// Covers scenarios where only a Company Number is being used
        /// </summary>
        [Fact]
        public void SetNumberOnlyCompanyData()
        {
            var validCompanyData = new SellerCompanyData(1);

            Assert.Equal(1, validCompanyData.Number);
        }
    }
}
