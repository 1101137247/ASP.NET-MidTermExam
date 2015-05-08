using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class CourseController : ApiController
    {

        public ICourseService CourseService { get; set; }

        [HttpPost]
        public Course AddCourse(Course Course)
        {
            CheckCourseIsNotNullThrowException(Course);

            try
            {
                CourseService.AddCourse(Course);
                return CourseService.GetCourseByCourse_ID(Course.Course_ID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Course UpdateCourse(Course Course)
        {
            CheckCourseIsNullThrowException(Course);

            try
            {
                CourseService.UpdateCourse(Course);
                return CourseService.GetCourseByCourse_ID(Course.Course_ID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteCourse(Course Course)
        {
            try
            {
                CourseService.DeleteCourse(Course);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Course> GetAllCourses()
        {
            return CourseService.GetAllCourses();
        }

        [HttpGet]
        [ActionName("byCourse_ID")]
        public Course GetCourseByCourse_ID(string id)
        {
            var Course = CourseService.GetCourseByCourse_ID(id);

            if (Course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Course;
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="Course">
        ///     員工資料.
        /// </param>
        private void CheckCourseIsNullThrowException(Course Course)
        {
            Course dbCourse = CourseService.GetCourseByCourse_ID(Course.Course_ID);

            if (dbCourse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="Course">
        ///     員工資料.
        /// </param>
        private void CheckCourseIsNotNullThrowException(Course Course)
        {
            Course dbCourse = CourseService.GetCourseByCourse_ID(Course.Course_ID);

            if (dbCourse != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }

}
