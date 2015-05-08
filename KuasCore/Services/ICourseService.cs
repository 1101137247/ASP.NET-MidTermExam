using KuasCore.Dao;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services
{

    /// <summary>
    ///     員工資料維護的 Service.
    /// </summary>
    public interface ICourseService
    {

        /// <summary>
        ///     新增員工資料.
        /// </summary>
        /// <param name="Course">
        ///     員工資料.
        /// </param>
        void AddCourse(Course Course);

        /// <summary>
        ///     修改員工資料.
        /// </summary>
        /// <param name="Course">
        ///     員工資料.
        /// </param>
        void UpdateCourse(Course Course);

        /// <summary>
        ///     刪除員工資料.
        /// </summary>
        /// <param name="Course">
        ///     員工資料.
        /// </param>
        void DeleteCourse(Course Course);

        /// <summary>
        ///     取得所有員工資料.
        /// </summary>
        /// <returns>
        ///     所有員工資料.
        /// </returns>
        IList<Course> GetAllCourses();

        /// <summary>
        ///     依據 ID 取得員工資料.
        /// </summary>
        /// <param name="Course_ID">
        ///     員工 Course_ID.
        /// </param>
        /// <returns>
        ///     該員工資料.
        /// </returns>
        Course GetCourseByCourse_ID(string Course_ID);

    }
}
