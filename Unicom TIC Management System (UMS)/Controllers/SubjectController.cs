using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;



namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    internal class SubjectController
    {
        public static void AddSubject(Subject subject)
        {
            SubjectService.AddSubject(subject);
        }

        public static void UpdateSubject(Subject subject)
        {
            SubjectService.UpdateSubject(subject);
        }

        public static void DeleteSubject(int subjectId)
        {
            SubjectService.DeleteSubject(subjectId);
        }

        public static List<Subject> GetAllSubjects()
        {
            return SubjectService.GetAllSubjects();
        }

        public static List<CourseSubject> GetCourseSubjectView()
        {
            return SubjectService.GetCourseSubjectView();
        }

        public static string GetSubjectNameById(int id)
        {
            return SubjectService.GetSubjectNameById(id);
        }

    }
}
