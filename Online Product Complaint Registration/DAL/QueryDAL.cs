using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Online_Product_Complaint_Registration.DAL
{
    public class QueryDAL
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();

        public QueryDAL()
        {
            string conn = ConfigurationManager.ConnectionStrings["rose"].ConnectionString;
            con = new SqlConnection(conn);
            cmd.Connection = con;
        }

        public SqlConnection Getcon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public int queryReg(BAL.QueryBAL obj)
        {
            string s = "insert into tbl_query  values('" + obj.productid + "','" + obj.userid + "','" + obj.querymsg + "','"+obj.queryrply+"','" + DateTime.Now.ToLongDateString().ToString() + "')";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }
        public DataTable Product_list()
        {

            string qry = "select  * from tbl_product";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable view_query(BAL.QueryBAL obj)
        {
            string qry = "select  c.qId,c.uid, p.pId,p.name,u.name, c.query, c.reply from tbl_product p  INNER JOIN tbl_query c  ON p.pId = c.pid INNER JOIN Registration u ON c.uid = u.uid";

            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }
        public int give_reply(BAL.QueryBAL obj)
        {
            string s = "update tbl_query  set reply='" + obj.queryrply + "' where qId='" + obj.queryid + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }
        public DataTable user_view_querystatus(BAL.QueryBAL obj)
        {
            string qry = "select p.name, c.query, c.reply from tbl_Product p  INNER JOIN tbl_query c  ON p.pid = c.pid INNER JOIN Registration u ON u.uid = c.uid AND c.uid ='" + obj.userid + "'";

            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

    }
}