using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Applications
{

    public interface ISellerApplication<T> where T : IProduct
    {
        T Product { get; set; }
        ISellerCompanyData CompanyData { get; set; }
        /// <summary>
        /// Submits the application of a given type to its corresponding service,
        /// </summary>
        /// <returns>An enumeration determining whether the submission was successful or failed</returns>
        ApplicationResultEnum Submit();
    }

    public interface IHasCompanyData
    {
        CompanyDataRequest GetCompanyDataFromSellerCompanyData();
    }

    public static class ApplicationResultExtensions
    {
        /// <summary>
        /// Converts an ApplicationResult into an enumeration value based on whether the application was successfully created
        /// </summary>
        /// <param name="result">The application result returned from the service handling an application submission</param>
        /// <returns>Enumeration value, Failed: 0, Success: 1</returns>
        public static ApplicationResultEnum GetReturnCodeFromApplicationResult(this IApplicationResult result)
        {
            if (result.Success && result.ApplicationId != null)
                return ApplicationResultEnum.Success;
            else return ApplicationResultEnum.Failed;
        }
    }

    public enum ApplicationResultEnum
    {
        Failed = 0,
        Success = 1
    }
}