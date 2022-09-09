using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedRestrauntPickerWithDatabase.Models
{
    public class Restraunt
    {
        public int RestId { get; set; }     //PK
        public string RestrauntName { get; set; }
        public string? RestrauntType { get; set; }
        public string? Price { get; set; }
        public bool? DineIn { get; set; }=false;
        public bool? DriveThru { get; set; }=false;


        public static string SqlDelete = $"Delete From Restraunts where RestId = @RestId";
        public static string SqlInsert = "INSERT into Restraunts" +
                                        " ( RestrauntName, RestrauntType, Price, DineI, DriveThru ) " +
                                        " (@RestrauntName, @RestrauntType, @Price, @DineIn, @DriveThru ) ";


        public static string SqlSelectByPk = "Select * from Restraunts Where RestId = @RestId";
        public static void SetSqlParameterId(SqlCommand cmd, int RestId)
        {
            cmd.Parameters.AddWithValue("@RestId", RestId);
        }

        public static void LoadFromReader(Restraunt restraunt, SqlDataReader reader)
        {
            restraunt.RestId = Convert.ToInt32(reader["RestId"]);
            restraunt.RestrauntName = Convert.ToString(reader["RestrauntName"]);
            restraunt.RestrauntType = Convert.ToString(reader["RestrauntType"]);
            restraunt.Price = Convert.ToString(reader["Price"]);
            restraunt.DriveThru = Convert.ToBoolean(reader["DriveThru"]);
            restraunt.DineIn = Convert.ToBoolean(reader["DineIn"]);
        }

        public void LoadFromReader(SqlDataReader reader)
        {
            LoadFromReader(this, reader);
        }



        public void SetSqlParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@RestrauntName", RestrauntName);
            cmd.Parameters.AddWithValue("@RestrauntType", RestrauntType);
            cmd.Parameters.AddWithValue("@Pirce", Price);
            cmd.Parameters.AddWithValue("@DineIn", DineIn);
            cmd.Parameters.AddWithValue("DriveThru", DriveThru);
            SetSqlParameters(cmd);
        }

        public static string SqlUpdate =
            "UPDATE Restraunts Set" +
            "RestrauntName= @RestrauntName" +
            "RestrauntType= @RestrauntType" +
            "Price= @Price" +
            "DineIn= @DineIn" +
            "DriveThru= @DriveThru" +
            "Where RestId= @RestId";

        public static string SqlSelectAll =
            "select * from Restraunts; ";










    }



}
