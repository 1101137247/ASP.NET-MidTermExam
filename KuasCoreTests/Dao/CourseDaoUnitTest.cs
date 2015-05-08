using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{

    [TestClass]
    public class CourseDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容 
        
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyCourse_Namespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseDao CourseDao { get; set; }


        [TestMethod]
        public void TestCourseDao_AddCourse()
        {
            Course Course = new Course();
            Course.Course_ID = "321";
            Course.Course_Name = "單元測試";
            Course.Course_Description = "描述";
            CourseDao.AddCourse(Course);

            Course dbCourse = CourseDao.GetCourseByCourse_ID(Course.Course_ID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.Course_ID, dbCourse.Course_ID);

            Console.WriteLine("課程編號 = " + dbCourse.Course_ID);
            Console.WriteLine("課程名稱 = " + dbCourse.Course_Name);
            Console.WriteLine("課程描述 = " + dbCourse.Course_Description);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseByCourse_ID(Course.Course_ID);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_UpdateCourse()
        {
            // 取得資料
            Course Course = CourseDao.GetCourseByCourse_ID("dennis_yen");
            Assert.IsNotNull(Course);
            
            // 更新資料
            Course.Course_Name = "單元測試";
            CourseDao.UpdateCourse(Course);

            // 再次取得資料
            Course dbCourse = CourseDao.GetCourseByCourse_ID(Course.Course_ID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.Course_Name, dbCourse.Course_Name);

            Console.WriteLine("課程編號 = " + dbCourse.Course_ID);
            Console.WriteLine("課程名稱 = " + dbCourse.Course_Name);
            Console.WriteLine("課程描述 = " + dbCourse.Course_Description);

            Console.WriteLine("================================");

            // 將資料改回來
            Course.Course_Name = "C#";
            CourseDao.UpdateCourse(Course);

            // 再次取得資料
            dbCourse = CourseDao.GetCourseByCourse_ID(Course.Course_ID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.Course_Name, dbCourse.Course_Name);

            Console.WriteLine("課程編號 = " + dbCourse.Course_ID);
            Console.WriteLine("課程名稱 = " + dbCourse.Course_Name);
            Console.WriteLine("課程描述 = " + dbCourse.Course_Description);
        }


        [TestMethod]
        public void TestCourseDao_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.Course_ID = "023";
            newCourse.Course_Name = "單元測試";
            newCourse.Course_Description = "描述";
            CourseDao.AddCourse(newCourse);

            Course dbCourse = CourseDao.GetCourseByCourse_ID(newCourse.Course_ID);
            Assert.IsNotNull(dbCourse);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseByCourse_ID(newCourse.Course_ID);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_GetCourseByCourse_ID()
        {
            Course Course = CourseDao.GetCourseByCourse_ID("dennis_yen");
            Assert.IsNotNull(Course);
            Console.WriteLine("課程編號 = " + Course.Course_ID);
            Console.WriteLine("課程名稱 = " + Course.Course_Name);
            Console.WriteLine("課程描述 = " + Course.Course_Description);
        }

    }
}
