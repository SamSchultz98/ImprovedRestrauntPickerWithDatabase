using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedRestrauntPickerWithDatabase.Models
{
    public class PastPick
    {
        public int PickId { get; set; }         //PK
        public int RestId { get; set; }         //FK to Restraunt (RestId)
        public DateTime DateTime { get; set; }
        public int Decider { get; set; }        //FK to user (UserId)


        public static string SqlDelete = $"Delete From PastPicks where PickId = @PickId";
        public static string SqlInsert = "INSERT into PastPicks" +
                                        " ( DateTime ) " +
                                        " (@DateTime ) ";


        public static string SqlSelectByPk = "Select * from PastPicks Where PickId = @PickId";
        public static void SetSqlParameterId(SqlCommand cmd, int PickId)
        {
            cmd.Parameters.AddWithValue("@PickId", PickId);
        }

        public static void LoadFromReader(PastPick pastpick, SqlDataReader reader)
        {
            pastpick.DateTime = Convert.ToDateTime(reader["DateTime"]);
        }

        public void LoadFromReader(SqlDataReader reader)
        {
            LoadFromReader(this, reader);
        }



        public void SetSqlParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@DateTime", DateTime);
            SetSqlParameters(cmd);
        }

        public static string SqlUpdate =
            "UPDATE Restraunts Set" +
            "DateTime= @DateTime";

        public static string SqlSelectAll =
            "select * from PastPicks; ";





















    }
}
