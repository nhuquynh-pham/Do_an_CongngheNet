using System.Collections.Generic;

namespace Do_an_CongngheNET
{
    public static class SessionManager
    {
        public static string MaTK { get; set; }
        public static string TenDangNhap { get; set; }
        public static string HoTen { get; set; }
        public static string TenVaiTro { get; set; }

        // Key = MaCN ("CN001".."CN011"), Value = true/false
        public static Dictionary<string, bool> Quyen { get; set; }
            = new Dictionary<string, bool>();

        public static bool CoQuyen(string maCN)
        {
            return Quyen.ContainsKey(maCN) && Quyen[maCN];
        }

        public static void Clear()
        {
            MaTK = TenDangNhap = HoTen = TenVaiTro = null;
            Quyen.Clear();
        }
    }
}