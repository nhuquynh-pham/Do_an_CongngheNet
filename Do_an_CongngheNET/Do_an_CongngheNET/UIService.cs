using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace Do_an_CongngheNET
{
    /// <summary>
    /// UIService:
    /// Lớp xử lý giao diện dùng chung cho các Form
    /// - KHÔNG xử lý CSDL
    /// - KHÔNG xử lý nghiệp vụ
    /// - CHỈ điều khiển trạng thái giao diện
    /// </summary>
    public static class UIService
    {
        // ================================================================
        // 1. XÓA TRẮNG DỮ LIỆU TRONG CÁC ĐIỀU KIỂN NHẬP DỮ LIỆU
        // ================================================================
        public static void ClearInputs(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.Tag?.ToString() == "no-clear")
                    continue;

                if (ctrl is TextBoxBase txt)
                    txt.Clear();

                else if (ctrl is CheckBox chk)
                    chk.Checked = false;

                else if (ctrl is RadioButton rdo)
                    rdo.Checked = false;

                else if (ctrl is ComboBox cbo)
                    cbo.SelectedIndex = -1;

                if (ctrl.HasChildren)
                    ClearInputs(ctrl);
            }
        }
        // ================================================================
        // 2. THIẾT LẬP TRẠNG THÁI ENABLE CHO CÁC ĐIỀU KIỂN NHẬP DỮ LIỆU
        // Những điều khiển nào không thiết lập, đặt Tag = "AlwaysEnable"
        // ================================================================
        public static void SetInputsEnabled(Control container, bool isEnabled)
        {
            foreach (Control ctrl in container.Controls)
            {
                // bỏ qua điều khiển luôn được phép nhập
                if (ctrl.Tag?.ToString() == "AlwaysEnable")
                    continue;

                if (ctrl is TextBoxBase)
                    ctrl.Enabled = isEnabled;

                if (ctrl is CheckBox || ctrl is RadioButton)
                    ctrl.Enabled = isEnabled;

                if (ctrl is ComboBox || ctrl is ListBox || ctrl is CheckedListBox)
                    ctrl.Enabled = isEnabled;

                if (ctrl.HasChildren)
                    SetInputsEnabled(ctrl, isEnabled);
            }
        }
        // ================================================================
        // 3. THIẾT LẬP CÁC THUỘC TÍNH CHỈ ĐỌC, KHÔNG CHO NHẬP DỮ LIỆU
        // ================================================================
        public static void SetInputsReadOnly(Control container, bool isReadOnly)
        {
            foreach (Control ctrl in container.Controls)
            {
                // bỏ qua điều khiển luôn cho phép chỉnh sửa
                if (ctrl.Tag?.ToString() == "AlwaysEnable")
                    continue;

                if (ctrl is TextBoxBase txt)
                    txt.ReadOnly = isReadOnly;

                else if (ctrl is DataGridView dgv)
                    dgv.ReadOnly = isReadOnly;

                // đệ quy vào control con
                if (ctrl.HasChildren)
                    SetInputsReadOnly(ctrl, isReadOnly);
            }
        }
        // ================================================================
        // 4. THIẾT LẬP TRẠNG THÁI CÁC NÚT CRUD
        // edit = true  : được Thêm / Sửa
        // edit = false : chỉ Xem
        // btnDelete là tùy chọn (có thể NULL)
        // ================================================================       
        public static void SetButtonsEnabled(Control container, bool edit)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is Button btn && btn.Tag != null)
                {
                    if (btn.Tag.ToString() == "select")
                        btn.Enabled = !edit;
                    else if (btn.Tag.ToString() == "confirm")
                        btn.Enabled = edit;
                }

                if (ctrl.HasChildren)
                    SetButtonsEnabled(ctrl, edit);
            }
        }

        // ================================================================
        // 5. KIỂM TRA CÁC DỮ LIỆU BẮT BUỘC NHẬP
        // ================================================================
        public static bool Require(Control ctrl, string message)
        {
            bool isEmpty = false;
            if (ctrl is TextBoxBase txt)
                isEmpty = string.IsNullOrWhiteSpace(txt.Text);

            else if (ctrl is ComboBox cbo)
                isEmpty = cbo.SelectedIndex < 0;

            else if (ctrl is ListBox lst)
                isEmpty = lst.SelectedIndex < 0;

            if (isEmpty)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrl.Focus();
                return false;
            }
            return true;
        }
        // ================================================================
        // 6. KIỂM TRA ĐỘ DÀI TỐI ĐA DỮ LIỆU BẮT BUỘC NHẬP
        // ================================================================
        public static bool MaxLength(Control ctrl, int max, string message)
        {
            int length = 0;
            if (ctrl is TextBoxBase txt)
                length = txt.Text.Trim().Length;

            else if (ctrl is ComboBox cbo && cbo.DropDownStyle != ComboBoxStyle.DropDownList)
                length = cbo.Text.Trim().Length;

            if (length > max)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrl.Focus();
                return false;
            }
            return true;
        }

        // ================================================================
        // 7. HỘP THOẠI XÁC NHẬN XÓA DỮ LIỆU
        // ================================================================
        public static bool ConfirmDelete()
        {
            DialogResult dr = MessageBox.Show("Chắc chắn xóa dòng đang chọn không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return dr == DialogResult.Yes;
        }

        // ================================================================
        // 8. ĐIỀU HƯỚNG BÀN PHÍM KHI ẤN ENTER, DOWN HOẶC UP
        // ================================================================
        public static void MoveFocus(Control ctrl, KeyEventArgs e)
        {
            // Không xử lý khi control đang mở dropdown
            if (ctrl is ComboBox cbo && cbo.DroppedDown)
                return;

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                ctrl.Parent.SelectNextControl(
                    ctrl, true, true, true, true);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                ctrl.Parent.SelectNextControl(
                    ctrl, false, true, true, true);
                e.Handled = true;
            }
        }
        // ================================================================
        // 9.KIỂM TRA DỮ LIỆU NHẬP VÀO MỘT ĐIỀU KHIỂN LÀ SỐ
        // Ngầm định là số kiểu Decimal, ép kiểu khi gọi nếu số int, long
        // ================================================================
        public static bool IsNumber(Control ctrl, string message)
        {
            decimal value = 0;
            if (!decimal.TryParse(ctrl.Text, out value))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                return false;
            }
            return true;
        }
        // ================================================================
        // 10. THIẾT LẬP THUỘC TÍNH DÙNG CHUNG CHO DataGridView TRÊN MỌI FORM
        // ================================================================
        public static void SetGridStyle(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
        }
        // ================================================================
        // 11. THIẾT LẬP TIÊU ĐỀ CỘT CỦA DataGridView TRÊN FORM
        // ================================================================
        public static void SetGridHeader(DataGridView dgv, params string[] headers)
        {
            for (int i = 0; i < headers.Length && i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].HeaderText = headers[i];
            }
        }
        // HÀM XỬ LÝ KIỂU NGÀY THÁNG
        public static DateTime? ParseDate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            DateTime d;
            if (!DateTime.TryParseExact(text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
            {
                return null;
            }

            return d;
        }
        public static string FormatDate(object value)
        {
            if (value == null || value == DBNull.Value)
                return "";

            return Convert.ToDateTime(value).ToString("dd/MM/yyyy");
        }
    }
}

