using System;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService
    {
        public int SubmitApplicationFor<T>(ISellerApplication<T> application) where T : IProduct
        {
            return application.Submit() == ApplicationResultEnum.Success ? 1 : 0;
        }
    }
}
