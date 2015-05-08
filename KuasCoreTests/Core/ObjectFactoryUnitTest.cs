using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Core;
using Spring.Context;
using Spring.Context.Support;
using KuasCore.Services;

namespace KuasCoreTests.Core
{
    [TestClass]
    public class ObjectFactoryUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyCourse_Namespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        [TestMethod]
        public void TestObjectFactory_GetApplicationContext()
        {

            // 利用 Spring Object Course_Name 來依賴尋找找出我們要的 Spring Object.
            IApplicationContext applicationContext = ObjectFactory.GetApplicationContext();
            ICourseService CourseService = (ICourseService)applicationContext["CourseService"];

            Course Course = CourseService.GetCourseByCourse_ID("1");
            Assert.IsNotNull(Course);

            Console.WriteLine("課程編號為 = " + Course.Course_ID);
            Console.WriteLine("課程名稱為 = " + Course.Course_Name);
            Console.WriteLine("課程描述為 = " + Course.Course_Description);

        }

        [TestMethod]
        public void TestObjectFactory_GetObject()
        {

            // 利用 Spring Object Course_Name 來依賴尋找找出我們要的 Spring Object.
            ICourseService CourseService = (ICourseService)ObjectFactory.GetObject("CourseService");

            Course Course = CourseService.GetCourseByCourse_ID("2");
            Assert.IsNotNull(Course);

            Console.WriteLine("課程編號為 = " + Course.Course_ID);
            Console.WriteLine("課程名稱為 = " + Course.Course_Name);
            Console.WriteLine("課程描述為 = " + Course.Course_Description);
        }

    }
}
