using System;

namespace SlothEnterprise.ProductApplication.Applications
{
    public interface ISellerCompanyData
    {
        string Name { get; set; }
        int Number { get; set; }
        string DirectorName { get; set; }
        DateTime Founded { get; set; }
    }


    public class SellerCompanyData : ISellerCompanyData
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string DirectorName { get; set; }
        public DateTime Founded { get; set; }

        public SellerCompanyData(int number)
        {
            Number = number;
        }

        public SellerCompanyData(string name, int number, string directorName, DateTime founded)
        {
            Name = name;
            Number = number;
            DirectorName = directorName;
            if (founded > DateTime.Now) throw new Exception("Founded date cannot be a future date");
            Founded = founded;
        }
    }
}