using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedRestrauntPickerWithDatabase.Models
{
    public class User
    {
        public int UserId { get; set; }     //Pk
        public string UserName { get; set; }
        public string FirstName { get; set; }


        public static string SqlDelete = $"Delete From Users where UserId = @UserId";
        public static string SqlInsert = "INSERT into Users" +
                                        " ( UserName, FirstName ) " +
                                        " (@UserName, @FirstName ) ";


        public static string SqlSelectByPk = "Select * from Users Where UserId = @UserId";
        public static void SetSqlParameterId(SqlCommand cmd, int UserId)
        {
            cmd.Parameters.AddWithValue("@UserId", UserId);
        }

        public static void LoadFromReader(User user, SqlDataReader reader)
        {
            user.UserName = Convert.ToString(reader["UserName"]);
            user.FirstName = Convert.ToString(reader["FirstName"]);
        }

        public void LoadFromReader(SqlDataReader reader)
        {
            LoadFromReader(this, reader);
        }



        public void SetSqlParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            SetSqlParameters(cmd);
        }

        public static string SqlUpdate =
            "UPDATE Users Set" +
            "UserName= @UserName" +
            "FirstName= @FirstName" +
            "Where UserId= @UserId";

        public static string SqlSelectAll =
            "select * from Users; ";


    }
}
