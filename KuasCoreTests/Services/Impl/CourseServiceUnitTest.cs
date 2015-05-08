using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class CourseServiceUnitTest : AbstractDependencyInjectionSpringContextTests
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

        public ICourseService CourseService { get; set; }

        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course Course = new Course();
            Course.Course_ID = "012";
            Course.Course_Name = "單元測試";
            Course.Course_Description = "描述";
            CourseService.AddCourse(Course);

            Course dbEmpolyee = CourseService.GetCourseByCourse_ID(Course.Course_ID);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(Course.Course_ID, dbEmpolyee.Course_ID);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.Course_ID);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.Course_Name);
            Console.WriteLine("員工年齡為 = " + dbEmpolyee.Course_Description);

            CourseService.DeleteCourse(dbEmpolyee);
            dbEmpolyee = CourseService.GetCourseByCourse_ID(Course.Course_ID);
            Assert.IsNull(dbEmpolyee);
        }

        [TestMethod]
        public void TestCourseService_UpdateCourse()
        {
            // 取得資料
            Course Course = CourseService.GetCourseByCourse_ID("dennis_yen");
            Assert.IsNotNull(Course);

            // 更新資料
            Course.Course_Name = "單元測試";
            CourseService.UpdateCourse(Course);

            // 再次取得資料
            Course dbEmpolyee = CourseService.GetCourseByCourse_ID(Course.Course_ID);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(Course.Course_Name, dbEmpolyee.Course_Name);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.Course_ID);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.Course_Name);
            Console.WriteLine("員工年齡為 = " + dbEmpolyee.Course_Description);

            Console.WriteLine("================================");

            // 將資料改回來
            Course.Course_Name = "嚴志和";
            CourseService.UpdateCourse(Course);

            // 再次取得資料
            dbEmpolyee = CourseService.GetCourseByCourse_ID(Course.Course_ID);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(Course.Course_Name, dbEmpolyee.Course_Name);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.Course_ID);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.Course_Name);
            Console.WriteLine("員工年齡為 = " + dbEmpolyee.Course_Description);
        }


        [TestMethod]
        public void TestCourseService_DeleteCourse()
        {
            Course newEmpolyee = new Course();
            newEmpolyee.Course_ID = "032";
            newEmpolyee.Course_Name = "單元測試";
            newEmpolyee.Course_Description = "描述";
            CourseService.AddCourse(newEmpolyee);

            Course dbEmpolyee = CourseService.GetCourseByCourse_ID(newEmpolyee.Course_ID);
            Assert.IsNotNull(dbEmpolyee);

            CourseService.DeleteCourse(dbEmpolyee);
            dbEmpolyee = CourseService.GetCourseByCourse_ID(newEmpolyee.Course_ID);
            Assert.IsNull(dbEmpolyee);
        }

        [TestMethod]
        public void TestCourseService_GetCourseByCourse_ID()
        {
            Course Course = CourseService.GetCourseByCourse_ID("dennis_yen");
            Assert.IsNotNull(Course);

            Console.WriteLine("員工編號為 = " + Course.Course_ID);
            Console.WriteLine("員工姓名為 = " + Course.Course_Name);
            Console.WriteLine("員工年齡為 = " + Course.Course_Description);
        }

    }
}
