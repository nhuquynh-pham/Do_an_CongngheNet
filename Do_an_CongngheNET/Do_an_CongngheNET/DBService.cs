using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// mở thêm các thư viện
using System.Data;
using System.Data.SqlClient;

namespace Do_an_CongngheNET
{
    public class DBService
    {
        // khai báo xâu kết nối với CSDL
        private readonly string _connectionString;

        // ================================================================
        // 1. HÀM THIẾT LẬP ĐỂ GÁN XÂU KẾT NỐI VỚI CSDL
        // ================================================================
        public DBService()
        {
            _connectionString = @"Data Source=DESKTOP-UJLMR8A;Initial Catalog=QLKTX;Integrated Security=True;TrustServerCertificate=True";
        }

        // ================================================================
        // 2. HÀM THỰC HIỆN CÂU LỆNH SELECT ĐỂ TRUY VẤN DỮ LIỆU
        // ĐẦU VÀO: Một câu lệnh sql với các tham số định nghĩa
        // ĐẦU RA: Một đối tượng lớp DataTable
        // ================================================================
        public DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            // tạo một kết nối với CSDL
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // tạo một đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // tạo một đối tượng SqlDataAdapter để truy vấn dữ liệu
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        // định nghĩa tham số, tạo kết nối và truy vấn
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // ================================================================
        // 3. HÀM THỰC HIỆN MỘT CÂU LỆNH INSERT/UPDATE/DELETE
        // ĐẦU VÀO: Một câu lệnh sql với các tham số định nghĩa
        // ĐẦU RA: Số dòng bị ảnh hưởng
        // ================================================================
        public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            // tạo một kết nối với CSDL
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // tạo một đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // định nghĩa tham số, và thực hiện câu lệnh sql
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // ================================================================
        // 4. HÀM THỰC HIỆN MỘT CÂU LỆNH SELECT VÀ TRẢ VỀ MỘT ĐỐI TƯỢNG
        // ĐẦU VÀO: Một câu lệnh sql với các tham số định nghĩa
        // ĐẦU RA: Một giá trị object (dùng cho COUNT, MAX, ...)
        // ================================================================
        public object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            // tạo một kết nối với CSDL
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // tạo một đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // định nghĩa tham số, và thực hiện câu lệnh sql
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}