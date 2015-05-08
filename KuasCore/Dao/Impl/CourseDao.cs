
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course Course)
        {
            string command = @"INSERT INTO Course (Course_ID, Course_Name, Course_Description) VALUES (@Course_ID, @Course_Name, @Course_Description);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Course_ID", DbType.String).Value = Course.Course_ID;
            parameters.Add("Course_Name", DbType.String).Value = Course.Course_Name;
            parameters.Add("Course_Description", DbType.String).Value = Course.Course_Description;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course Course)
        {
            string command = @"UPDATE Course SET Course_Name = @Course_Name, Course_Description = @Course_Description WHERE Course_ID = @Course_ID;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Course_ID", DbType.String).Value = Course.Course_ID;
            parameters.Add("Course_Name", DbType.String).Value = Course.Course_Name;
            parameters.Add("Course_Description", DbType.String).Value = Course.Course_Description;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteCourse(Course Course)
        {
            string command = @"DELETE FROM Course WHERE Course_ID = @Course_ID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Course_ID", DbType.String).Value = Course.Course_ID;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllCourses()
        {
            string command = @"SELECT * FROM Course ORDER BY Course_ID ASC";
            IList<Course> Courses = ExecuteQueryWithRowMapper(command);
            return Courses;
        }

        public Course GetCourseByCourse_ID(string id)
        {
            string command = @"SELECT * FROM Course WHERE Course_ID = @Course_ID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Course_ID", DbType.String).Value = id;

            IList<Course> Courses = ExecuteQueryWithRowMapper(command, parameters);
            if (Courses.Count > 0)
            {
                return Courses[0];
            }

            return null;
        }

    }
}
