using CRUD.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUD.Data
{
    public class DataInfo
    {
        private string connectionString = @"Data Source=LAPTOP-C59IR2RT\SQLEXPRESS;Initial Catalog=CRUD;User ID=root;Password=*******;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Trusted_Connection=True";
        public List<StudentInfo> FetchAll()
        {
            List<StudentInfo> returnList = new List<StudentInfo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.info";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentInfo studentInfo = new StudentInfo();
                        studentInfo.Id = reader.GetInt32(0);
                        studentInfo.Name = reader.GetString(1);
                        studentInfo.CollegeName = reader.GetString(2);
                        studentInfo.CourseName = reader.GetString(3);
                        studentInfo.Address = reader.GetString(4);

                        returnList.Add(studentInfo);
                    }
                }
            }



            return returnList;
        }

        public StudentInfo FetchOne(int id)

        {
            StudentInfo first = new StudentInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.info WHERE Id = @id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        first.Id = reader.GetInt32(0);
                        first.Name = reader.GetString(1);
                        first.CollegeName = reader.GetString(2);
                        first.CourseName = reader.GetString(3);
                        first.Address = reader.GetString(4);
                    }
                }
            }

            return first;
        }


        public int CreateorUpdate(StudentInfo studentInfo)

        {
            StudentInfo first = new StudentInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if (studentInfo.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.info Values(@Name, @CollegeName , @CourseName , @Address)";
                }

                else
                {
                    sqlQuery = "UPDATE dbo.info SET Name = @Name , CollegeName=@CollegeName ,CourseName=@CourseName , Address=@Address WHERE Id=@Id ";

                }


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = studentInfo.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = studentInfo.Name;
                command.Parameters.Add("@CollegeName", System.Data.SqlDbType.VarChar, 1000).Value = studentInfo.CollegeName;
                command.Parameters.Add("@CourseName", System.Data.SqlDbType.VarChar, 1000).Value = studentInfo.CourseName;
                command.Parameters.Add("@Address", System.Data.SqlDbType.VarChar, 1000).Value = studentInfo.Address;
                connection.Open();


                int newID = command.ExecuteNonQuery();
                return newID;

            }


        }

        public int Delete(int id)

        {
            StudentInfo first = new StudentInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM dbo.Info WHERE Id = @Id"; 

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 1000).Value =id;
                
                connection.Open();


                int deleteID = command.ExecuteNonQuery();
                return deleteID;

            }


        }


    }
}
