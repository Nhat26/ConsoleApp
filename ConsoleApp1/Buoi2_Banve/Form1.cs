using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi2_Banve{
    public partial class Form1 : Form{
        int maHoaDon;
        public Form1(){
            InitializeComponent();
            maHoaDon = 0;
        }

        private void Form1_Load(object sender, EventArgs e){
            Khoitaoso(3, 5);

        }

        private void Khoitaoso(int dong, int cot){
            Button btnghe;
            int x, y = 5, dem = 1, KhoangcachX = 115, KhoangcachY = 62;
            for (int i = 0; i < dong; i++){
                x = 10;
                for (int j = 0; j < cot; j++){
                    //chạy dòng
                    btnghe = new Button();
                    btnghe.Location = new Point(x, y); //vị trí
                    btnghe.Size = new Size(90,50); //kích thước
                    btnghe.Text = dem++.ToString();
                    btnghe.BackColor = Color.White;
                    btnghe.Click += Btnghe_Click;
                    pnlHangghe.Controls.Add(btnghe);
                    x += KhoangcachX;
                }
                y += KhoangcachY;
            }
        }

        private void Btnghe_Click(object sender, EventArgs e){
            Button btnghe = (Button)sender;
            if (btnghe.BackColor==Color.White){
                btnghe.BackColor = Color.Red;
            }else if(btnghe.BackColor==Color.Red){
                btnghe.BackColor = Color.White;
            }else{
                MessageBox.Show("Ghế này đã được mua");
            } 
        }

        private void button3_Click(object sender, EventArgs e){
            double tongTien = 0, Tienghe;
            Dictionary<int, double> danhSachGheKemGiaTien = new Dictionary<int, double>();
            int soGhe;
            foreach (Button item in pnlHangghe.Controls)
            {
                soGhe = int.Parse(item.Text);
                if (item.BackColor==Color.Red){
                    Tienghe = Tinhtien(soGhe);
                    tongTien += Tienghe;
                    item.BackColor = Color.Gray;
                    danhSachGheKemGiaTien.Add(soGhe, Tienghe);
                }
            }
            txtTongtien.Text = tongTien.ToString();
            string msg;
            if(ThemHoaDon(tongTien, out msg))
            {
                ThemChiTietHoaDon();
                MessageBox.Show("Them Hoa Don Thanh Cong");
            }
            else
            {
                MessageBox.Show("Them hoa doan khong thanh cong!! \n Loi ", msg);
            }
        }



        private bool ThemHoaDon(float tongtien, out String msg)
        {
            msg = "";
            try
            {
                maHoaDon++;
                int rowIndex = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[rowIndex].Cells[0].Value = "HD" + maHoaDon;
                dgvHoaDon.Rows[rowIndex].Cells[1].Value = DateTime.Now.ToShortDateString();
                dgvHoaDon.Rows[rowIndex].Cells[2].Value = tongtien;
            }
            catch (Exception ex ) 
            {
                msg = ex.Message;
                return false;
            }
            return true;
           
        }

        private float Tinhtien(int Soghe){
            if (Soghe<=5){
                return 6000;
            }else if (Soghe <= 10){
                return 8000;
            }
            return 10000;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTongtien.Text = "";
            foreach (Button item in pnlHangghe.Controls)
            {
                item.BackColor = Color.White;
            }
        
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ban co mua thoat khong ?", "Thong Bao", MessageBoxButtons.YesNo);
            if(dialogResult==DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
