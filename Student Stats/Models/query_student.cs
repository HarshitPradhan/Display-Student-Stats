using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data;

namespace Student_Stats.Models
{
    public class query_student
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public List<Student> getData()
        {
            List<Student> students = new List<Student>();
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select *  from [Student]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student student = new Student();
                        student.id = Convert.ToInt32(rdr.GetValue(0));
                        student.name = rdr.GetValue(1).ToString();
                        student.age = rdr.GetValue(2).ToString();
                        student.phy = Convert.ToInt32(rdr.GetValue(3));
                        student.chem = Convert.ToInt32(rdr.GetValue(4));
                        student.maths = Convert.ToInt32(rdr.GetValue(5));
                        students.Add(student);
                    }
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return students;
        }




        public int getcount()
        {
            int result = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select count(*)  from [Student]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }






        public int getsubjects()
        {
            int result = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select count(*)  from [Subject]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }



        public int getminPhy()
        {
            int result = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select Min([phy])  from [Student]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }




        public int getminChe()
        {
            int result = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select Min([chem])  from [Student]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public int getminMath()
        {
            int result = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select Min([maths])  from [Student]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }



        public int getmaxPhy()
        {
            int result = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select Max([phy])  from [Student]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }



        public int getmaxChe()
        {
            int result = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select Max([chem])  from [Student]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }




        public int getmaxMath()
        {
            int result = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("select Max([maths])  from [Student]", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    result = (int)cmd.ExecuteScalar();
                    conn.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }


        public List<Student> getstudentwithlowestandhighestmarks()
        {
            List<Student> student = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("select Min([phy])  from [Student]", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                conn.Open();
                int marks = (int)cmd.ExecuteScalar();
                SqlCommand cmd2 = new SqlCommand("select Max([phy])  from [Student]", conn);
                cmd2.CommandType = System.Data.CommandType.Text;

                int marks2 = (int)cmd2.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand("select * from [Student] WHERE phy=@marks OR phy=@marks2", conn);
                cmd1.Parameters.Add("@marks", SqlDbType.Int).Value = marks;
                cmd1.Parameters.Add("@marks2", SqlDbType.Int).Value = marks2;
                cmd1.CommandType = System.Data.CommandType.Text;
                SqlDataReader rdr = cmd1.ExecuteReader();
                while (rdr.Read())
                {
                    Student result = new Student();
                    result.id = Convert.ToInt32(rdr.GetValue(0));
                    result.name = rdr.GetValue(1).ToString();
                    result.age = rdr.GetValue(2).ToString();
                    result.phy = Convert.ToInt32(rdr.GetValue(3));
                    result.chem = Convert.ToInt32(rdr.GetValue(4));
                    result.maths = Convert.ToInt32(rdr.GetValue(5));
                    student.Add(result);
                }
                conn.Close();

            }
            return student;
        }



    }
}