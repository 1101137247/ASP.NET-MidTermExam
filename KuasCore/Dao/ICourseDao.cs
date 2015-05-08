using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Dao
{
    public interface ICourseDao
    {

        void AddCourse(Course Course);

        void UpdateCourse(Course Course);

        void DeleteCourse(Course Course);

        IList<Course> GetAllCourses();

        Course GetCourseByCourse_ID(string Course_ID);

    }
}
