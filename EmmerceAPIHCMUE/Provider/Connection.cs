using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EmmerceAPIHCMUE.Provider
{
    public class Connection
    {
        private string ConnSQL = "Data Source=DESKTOP-K4R56PD;Initial Catalog=ecommerce;Integrated Security=True";
        //Exec được tất cả câu query
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(this.ConnSQL))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if(item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                conn.Close();
            }
               
            return data;
        }
        //Chủ yêu là thêm sửa xóa
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(this.ConnSQL))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                
                conn.Close();
            }

            return data;
        }
        //Chủ yếu sử dụng để đếm(kết hợp count(*) trong sql)
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection conn = new SqlConnection(this.ConnSQL))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
               
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                conn.Close();
            }

            return data;
        }
    }
}
