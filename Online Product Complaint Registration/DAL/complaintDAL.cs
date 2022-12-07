using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Online_Product_Complaint_Registration.DAL
{
    public class complaintDAL
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();

        public complaintDAL()
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
        public DataSet ProductValues(int pId)
        {

            string qry = "select  * from tbl_product where pId='" + pId + "'";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.ExecuteNonQuery();
            da.Fill(ds);
            return ds;
        }
        public int complaintReg(BAL.complaintBAL obj)
        {
            string s = "insert into tbl_complaint  values('" + obj.userid + "','" + obj.productid + "','" + obj.cmpmsg + "','Complaint Received','" + DateTime.Now.ToLongDateString().ToString() + "')";
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
        public DataTable users_list()
        {
            string qry = "select  * from Registration";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable view_complaints(BAL.complaintBAL obj)
        {
            //string qry = "select r.*,d.* from tbl_complaint d INNER JOIN tbl_Product r  ON r.pid=d.pid AND userid='" + obj.userid +"'";
            string qry = "select r.*,d.* from tbl_complaint d INNER JOIN tbl_product r  ON r.pId=d.pId";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

 

        public int Update_Status(BAL.complaintBAL obj)
        {
            string s = "update tbl_complaint  set status='" + obj.cmpsts + "' where cId='" + obj.cid + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }
        public DataTable user_view_complaints(BAL.complaintBAL obj)
        {
            string qry = "select  c.date,p.name,u.uId,u.name,c.complaint, c.status from tbl_product p  INNER JOIN tbl_complaint c  ON p.pId = c.pId INNER JOIN Registration u ON u.uId = c.uid AND c.uid ='" + obj.userid + "'";

            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}