using QLST.DTO;
using QLST.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLST
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
            foreach (MH mh in QLSTBLL.Instance.GetAllMHs())
            {
                mathangCbb.Items.Add(mh.nameMH);
            }
            foreach (NSX nsx in QLSTBLL.Instance.GetAllNSXs())
            {
                nhasxCbb.Items.Add(nsx.nameNSX);
            }
        }
        private void reload()
        {
            dataGridView1.DataSource = QLSTBLL.Instance.GetAllSPs();
        }
        private void showBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLSTBLL.Instance.GetAllSPs();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[e.RowIndex];
                int stt = Convert.ToInt32(row.Cells[0].Value);
                SP sp = QLSTBLL.Instance.GetSPBySTT(stt);
                mspTxt.Text = sp.msp;
                nameTxt.Text = sp.nameSP;
                dateTimePicker1.Value = sp.ngaynhap;
                mathangCbb.SelectedIndex = Convert.ToInt32(sp.maMH);
                nhasxCbb.SelectedIndex = Convert.ToInt32(sp.maNSX);
                radioButton1.Checked = sp.status;
                radioButton2.Checked = !sp.status;
            }
            catch
            {

            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                int stt = Convert.ToInt32(row.Cells[0].Value);
                SP sp = new SP
                {
                    msp = mspTxt.Text,
                    nameSP = nameTxt.Text,
                    ngaynhap = dateTimePicker1.Value,
                    maMH = mathangCbb.SelectedIndex.ToString(),
                    maNSX = nhasxCbb.SelectedIndex.ToString(),
                    status = radioButton1.Checked,
                };
                try
                {
                    QLSTBLL.Instance.updateSP(stt, sp);
                    MessageBox.Show("Đã chập nhật SP: " + stt.ToString());
                }
                catch
                {
                    MessageBox.Show("Thông tin cập nhật không hợp lệ");
                }
                reload();
            }    
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            f.d += new AddForm.ContactF1(reload);
            f.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string name = searchTxt.Text;
            dataGridView1.DataSource = QLSTBLL.Instance.GetSPsByName(name);
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int stt = Convert.ToInt32(row.Cells[0].Value);
                    QLSTBLL.Instance.deleteSPBySTT(stt);
                }
                reload();
            }
            else MessageBox.Show("Sản phẩm xóa không hợp lệ\n Lưu ý chọn hàng!");
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            string compareType = comboBox3.Text;
            if (compareType != "")
            {
                List<DGVDisplay> li = new List<DGVDisplay>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    li.Add(new DGVDisplay
                    {
                        STT = Convert.ToInt32(row.Cells[0].Value),
                        msp = Convert.ToString(row.Cells[1].Value),
                        nameSP = Convert.ToString(row.Cells[2].Value),
                        NSX = Convert.ToString(row.Cells[3].Value),
                        ngaynhap = Convert.ToDateTime(row.Cells[4].Value),
                        MH = Convert.ToString(row.Cells[5].Value),
                        status = Convert.ToBoolean(row.Cells[6].Value)
                    });
                }
                dataGridView1.DataSource = QLSTBLL.Instance.sortDGV(li, compareType);
            }
            else
            {
                MessageBox.Show("Chọn kiểu sắp xếp");
            }    
        }
    }
}
