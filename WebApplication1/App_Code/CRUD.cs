using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplication1.App_Code
{
    public class CRUD
    {
        static public string conStr = WebConfigurationManager.ConnectionStrings["CyberGymConnectionString"].ConnectionString;
        public SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberGymConnectionString"].ConnectionString);


        public SqlDataReader getDrPassSql(string mySql)
        {
            SqlDataReader dr;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(@mySql, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            dr = cmd.ExecuteReader();
            return dr;
        }
        public int InsertUpdateDeleteViaSqlDicRtnIdentity(string mySql, Dictionary<string, object> myPara) //9
        {
            Int32 newIdentityId = 000;
            try
            {
                using (SqlCommand cmd = new SqlCommand(mySql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    foreach (KeyValuePair<string, object> p in myPara)
                    {
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }
                    using (con)
                    {
                        con.Open();
                        newIdentityId = (Int32.Parse(cmd.ExecuteScalar().ToString()));
                    }
                }
            }

            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            //   return new List<Dictionary<string, object>>(); ////return new List<DataTable>();
            return newIdentityId;
        }
        //public int InsertUpdateDelete(string mySql) //7
        //{

        //    int rtn = 0;
        //    using (con)
        //    {
        //        using (SqlCommand cmd = new SqlCommand(mySql, con))
        //        {
        //            cmd.CommandType = CommandType.Text;

        //            con.Open();
        //            rtn = cmd.ExecuteNonQuery();
        //            return rtn;

        //        }
        //    }
        //}
        public int InsertUpdateDelete(string mySql, Dictionary<string, object> myPara) //8
        {
            int rtn = 0;
            using (SqlCommand cmd = new SqlCommand(mySql, con))
            {
                cmd.CommandType = CommandType.Text;
                foreach (KeyValuePair<string, object> p in myPara)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                using (con)
                {
                    con.Open();
                    rtn = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rtn;
        }
        public SqlDataReader getDrPassSqlDic(string mySql, Dictionary<string, object> formValues)
        {
            SqlDataReader dr;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(mySql, con);
            foreach (KeyValuePair<string, object> p in formValues)
            {
                // can put validation here to see if the value is empty or not 
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            con.Open();
            dr = cmd.ExecuteReader(CommandBehavior.Default);
            return dr;
        }
        public int InsertUpdateDeleteViaSqlDic(string sqlStatement, Dictionary<string, object> InputParaList)
        {
            int rowAffected;
            try
            {
                using (SqlConnection cn = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlStatement, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        foreach (KeyValuePair<string, object> p in InputParaList)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }
                        using (cn)
                        {
                            cn.Open();
                            rowAffected = cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            return rowAffected;
        }
    }
}