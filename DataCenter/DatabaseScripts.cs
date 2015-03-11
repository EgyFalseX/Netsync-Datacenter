
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataCenter
{
    public static class DatabaseScripts
    {
        public static void FireScript()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataCenterConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            try
            {
                con.Open();

                if (CheckViewExists("vStudent"))
                {
                    cmd.CommandText = DropObject("vStudent");
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = vStudent;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                DataCenterX.LogMessage("Fire Scripting: " + ex.Message, typeof(DatabaseScripts), nsLib.Utilities.Types.MessageType.Error, ex, true);
            }
            con.Close();
        }

        public static bool CheckViewExists(string viewName)
        {
            bool exist = false;
            SqlConnection con = new SqlConnection(DataCenter.Properties.Settings.Default.DataCenterConnectionString);
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = string.Format(@"IF EXISTS(select * FROM sys.views where name = '{0}')
                                            SELECT 1
                                            ELSE
                                            SELECT 0", viewName);
            try
            {
                con.Open();
                if (cmd.ExecuteScalar().ToString() == "1")
                    exist = true;
                else
                    exist = false;
            }
            catch (SqlException ex)
            {
                DataCenterX.LogMessage(ex.Message, typeof(DatabaseScripts), nsLib.Utilities.Types.MessageType.Error, ex, true);
            }
            con.Close();
            return exist;
        }
        private static string DropObject(string objName)
        {
            return string.Format(@"DROP VIEW [dbo].[{0}]", objName);
        }

        public static string vStudent
        {
            get
            {
                return @"
                CREATE VIEW [dbo].[vStudent]
                AS
                SELECT        dbo.Student.stu_code, dbo.Student.stu_name, dbo.student_t.asase_code, dbo.student_t.alsofof_code, dbo.student_t.fasl_code, dbo.asase.asase_year, dbo.alsofof.alsofof_name, dbo.fasl.fasl_name
                FROM            dbo.student_t INNER JOIN
                                         dbo.Student ON dbo.student_t.stu_code = dbo.Student.stu_code INNER JOIN
                                         dbo.alsofof ON dbo.student_t.alsofof_code = dbo.alsofof.alsofof_code INNER JOIN
                                         dbo.asase ON dbo.student_t.asase_code = dbo.asase.asase_code INNER JOIN
                                         dbo.fasl ON dbo.student_t.fasl_code = dbo.fasl.fasl_code";
            }
        }



    }
}
