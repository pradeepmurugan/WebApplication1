using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class Students : Controller
    {
        private string providerName;

        // GET: Student
        public ActionResult Index()
        {
            String connectionString = "<Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20170222054809.mdf;Initial Catalog=aspnet-WebApplication1-20170222054809;Integrated Security=True" providerName = "System.Data.SqlClient/>";
            String sql = "SELECT * FROM students";
            SqlCommand cmd = new SqlCommand(sql, conn);

            var model = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var student = new Student();
                    student.FirstName = rdr["FirstName"];
                    student.LastName = rdr["LastName"];
                    student.Class = rdr["Class"];


                    model.Add(student);
                }

            }

            return View(model);

        }
    }
}