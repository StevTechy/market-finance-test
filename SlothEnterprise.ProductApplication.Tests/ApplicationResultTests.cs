using Moq;
using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    /// <summary>
    /// These tests ensure the correct enum result is being returned after an Application has been submitted
    /// </summary>
    public class ApplicationResultTests
    {
        private IApplicationResult GetSuccessfulApplicationResult()
        {
            return Mock.Of<IApplicationResult>(a => a.ApplicationId == 1 && a.Success == true);
        }

        private IApplicationResult GetFailedApplicationResult()
        {
            return Mock.Of<IApplicationResult>(a => a.ApplicationId == 1 && a.Success == false);
        }

        private IApplicationResult GetApplicationResultWithNoApplicationId()
        {
            return Mock.Of<IApplicationResult>();
        }

        [Fact]
        public void GetReturnCodeFromApplicationResult()
        {
            var result = GetSuccessfulApplicationResult();
            Assert.Equal(ApplicationResultEnum.Success, GetSuccessfulApplicationResult().GetReturnCodeFromApplicationResult());
            Assert.Equal(ApplicationResultEnum.Failed, GetFailedApplicationResult().GetReturnCodeFromApplicationResult());
            Assert.Equal(ApplicationResultEnum.Failed, GetApplicationResultWithNoApplicationId().GetReturnCodeFromApplicationResult());
        }
    }
}
