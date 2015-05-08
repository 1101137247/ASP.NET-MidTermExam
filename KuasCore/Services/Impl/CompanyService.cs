using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class CompanyService : ICompanyService
    {

        public IList<Company> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();

            Company company1 = new Company();
            company1.Course_ID = "GSS";
            company1.Course_Name = "叡揚資訊";
            companies.Add(company1);

            Company company2 = new Company();
            company2.Course_ID = "KUAS";
            company2.Course_Name = "高雄應用科技大學";
            companies.Add(company2);

            return companies;
        }

        public Company GetCompanyByCourse_ID(string id)
        {

            Company company = null;
            
            if ("GSS".Equals(id))
            {
                company = new Company();
                company.Course_ID = "GSS";
                company.Course_Name = "叡揚資訊";
            }

            return company;
        }

    }

}
