using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class CompanyServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region Spring 單元測試必寫的內容
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyCourse_Namespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml"
                };
            }
        }
        #endregion
        public ICompanyService CompanyService { get; set; }

        [TestMethod]
        public void TestCompanyService_GetCompanyByCourse_ID()
        {
            Company company = CompanyService.GetCompanyByCourse_ID("GSS");
            Assert.IsNotNull(company);

            Console.WriteLine("公司代號為 = " + company.Course_ID);
            Console.WriteLine("公司名稱為 = " + company.Course_Name);
        }
    }
}
