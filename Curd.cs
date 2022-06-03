using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CoreWebApp.Model;


namespace CoreWebApp.CallingSP
{
    public class Curd
    {
        public bool AddUsers(Register register)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=office;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_INSERTDATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NAME", register.NAME);
                cmd.Parameters.AddWithValue("@EMAILID", register.EMAILID);
                cmd.Parameters.AddWithValue("@PASSWORD", register.PASSWORD);
                cmd.Parameters.AddWithValue("@GENDER", register.GENDER);
                cmd.Parameters.AddWithValue("@DEPARTMENT", register.DEPARTMENT);
                cmd.Parameters.AddWithValue("@CITY", register.CITY);
                int X = cmd.ExecuteNonQuery();
                if (X > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Login(Register register)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=office;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getlogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emailid", register.EMAILID);
                cmd.Parameters.AddWithValue("@Password", register.PASSWORD);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static IEnumerable<Register> GetAllData()
        {
            List<Register> lstregister = new List<Register>();
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=office;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getalldatatbl_register", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Register reg = new Register();
                    reg.UserID =Convert.ToInt32( dr[0].ToString());
                    reg.NAME = dr[1].ToString();
                    reg.EMAILID = dr[2].ToString();
                    reg.PASSWORD = dr[3].ToString();
                    reg.GENDER = dr[4].ToString();
                    reg.DEPARTMENT = dr[5].ToString();
                    reg.CITY = dr[6].ToString();
                    lstregister.Add(reg);
                }
                return lstregister;
            }
            return lstregister;
        }

        public static Register GetDataByID(int? UserID)
        {
            Register reg = new Register();
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=office;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getdatabyID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Userid", UserID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    reg.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    reg.NAME = dr["Name"].ToString();
                    reg.EMAILID = dr["EmailID"].ToString();
                    reg.PASSWORD = dr["Password"].ToString();
                    reg.GENDER = dr["Gender"].ToString();
                    reg.DEPARTMENT = dr["Department"].ToString();
                    reg.CITY = dr["city"].ToString();
                }
                return reg;

            }
        }

        public static bool Update(Register register)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=office;Integrated Security=true"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateDATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NAME", register.NAME);
                cmd.Parameters.AddWithValue("@EMAILID", register.EMAILID);
                cmd.Parameters.AddWithValue("@PASSWORD", register.PASSWORD);
                cmd.Parameters.AddWithValue("@GENDER", register.GENDER);
                cmd.Parameters.AddWithValue("@DEPARTMENT", register.DEPARTMENT);
                cmd.Parameters.AddWithValue("@CITY", register.CITY);
                cmd.Parameters.AddWithValue("@UserID", register.UserID);
                int X = cmd.ExecuteNonQuery();
                if (X > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
