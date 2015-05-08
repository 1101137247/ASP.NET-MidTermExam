using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class TxCourseService : ITxCourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void ExecuteTxMethod()
        {
            Course Course1 = new Course();
            Course1.Course_ID = "5";
            Course1.Course_Name = "國文";
            Course1.Course_Description = "Chinese";
            CourseDao.AddCourse(Course1);

            Course Course2 = new Course();
            Course2.Course_ID = "6";
            Course2.Course_Name = "英文";
            Course2.Course_Description = "English";
            CourseDao.AddCourse(Course2);

            Course dbCourse = CourseDao.GetCourseByCourse_ID("6");
            dbCourse.Course_Name = "微積分";
            CourseDao.UpdateCourse(dbCourse);

            throw new Exception("Get an exception");
        }

    }

}
