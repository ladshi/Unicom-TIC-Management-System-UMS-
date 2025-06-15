using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;

namespace Unicom_TIC_Management_System__UMS_.Services
{
    public class StudentService
    {
        public static bool AddStudent(Student student)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = @"INSERT INTO Students
                    (First_name, Last_name, DOB, Gender, Email, Phone_Number, Address, Enrollment_date, CourseId, UserId)
                    VALUES (@FirstName, @LastName, @DOB, @Gender, @Email, @PhoneNumber, @Address, @EnrollmentDate, @CourseId, @UserId)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@DOB", student.DOB);
                    cmd.Parameters.AddWithValue("@Gender", (int)student.Gender); // Enum as int
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                    cmd.Parameters.AddWithValue("@CourseId", student.CourseId);
                    cmd.Parameters.AddWithValue("@UserId", student.UserId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
