using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Repositaries;
using Unicom_TIC_Management_System__UMS_.View;
using static System.Collections.Specialized.BitVector32;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    internal class CourseController
    {
        public void AddSection(Courses course)
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Sections (Name) VALUES (@Name)", conn);
                cmd.Parameters.AddWithValue("@Name", course.Name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
