using QLST.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLST.Presentation
{
    public partial class AddForm : Form
    {
        public AddForm()
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
        public delegate void ContactF1();
        public ContactF1 d { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
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
                QLSTBLL.Instance.addSP(sp);
                MessageBox.Show("Đã thêm SP Mã số: " + mspTxt.Text);
                d();
                this.Dispose();
            }
            catch
            {
                MessageBox.Show("Sản phẩm nhập vào không hợp lệ");
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
