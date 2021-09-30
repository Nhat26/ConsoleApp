using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            danhsach a = new danhsach();
            do{
                Console.WriteLine("1 Nhap");
                Console.WriteLine("2 Xuat");
                Console.WriteLine("3 Tinh tong luong");
                Console.WriteLine("4 Danh sach luong");
                Console.WriteLine("0 Thoat");
                int chon = int.Parse(Console.ReadLine());
                if (chon==0){
                    break;
                }
                switch (chon)
                {
                    case 1:
                        a.nhap();
                        break;
                    case 2:
                        a.xuat();
                        break;
                    case 3:
                        a.TinhTongLuong();
                        break;
                    case 4:
                        a.dsluong();
                        break;
                    default:
                        break;
                }
            } while (true);
            //danhsach ds = new danhsach();
            //ds.nhap();
            //ds.xuat();
        }
    }

    public abstract class Nhanvien
    {
        //public virtual void nhap(){
        //    Console.Write("Nhap ho ten: ");
        //    Console.ReadLine();
        //    Console.Write("\nNhap nam sinh: ");
        //    Console.ReadLine();
        //    Console.Write("\nNhap bang cap: ");
        //    Console.ReadLine();
        //}

        //public virtual void xuat() {
        //    Console.WriteLine("Hoten: ");
        //    Console.WriteLine("Nam sinh: ");
        //    Console.WriteLine("Bang cap: ");
        //}
        public string Hoten { get; set; }
        public DateTime Namsinh { get; set; }
        public string Bangcap { get; set; }
        public virtual void Nhap()
        {
            Console.Write("Ho ten: ");
            Hoten = Console.ReadLine();
            Console.Write("\nNam sinh: ");
            Namsinh = DateTime.Parse(Console.ReadLine());
            Console.Write("\nBang cap: ");
            Bangcap = Console.ReadLine();
        }


        public virtual void Xuat()
        {
            Console.WriteLine("Ho ten: {0}", Hoten);
            Console.WriteLine("Nam sinh: {0}", Namsinh);
            Console.WriteLine("Bang cap: {0}", Bangcap);
        }

        public abstract float Tinhluong();
    }

    public class NhanvienPTN : Nhanvien
    {
        public float Luongtrongthang { get; set; }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("\nLuong trong thang: ");
            Luongtrongthang = float.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Luong trong thang: {0}", Luongtrongthang);
        }
        public override float Tinhluong()
        {
            return Luongtrongthang;
        }
    }

    public class NhanvienQL : Nhanvien
    {
        public string Chucvu { get; set; }
        public int Songaycong { get; set; }
        public float Bacluong { get; set; }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("\nChuc vu: ");
            Chucvu = Console.ReadLine();
            Console.Write("\nSo ngay cong: ");
            Songaycong = int.Parse(Console.ReadLine());
            Console.Write("\nBac luong: ");
            Bacluong = float.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Chuc vu: {0}", Chucvu);
            Console.WriteLine("So ngay cong: {0}", Songaycong);
            Console.WriteLine("Bac luong: {0}", Bacluong);
        }
        public override float Tinhluong()
        {
            Console.WriteLine("Luong = " + (Songaycong * Bacluong));
            return Songaycong * Bacluong;
        }
    }

    public class danhsach{
        List<Nhanvien> ds;
        public danhsach(){
            ds = new List<Nhanvien>();
        }

        public void nhap(){
            Nhanvien a = null;
            do
            {
                Console.WriteLine("1 Nhan vien QL");
                Console.WriteLine("2 Nhan vien PTN");
                Console.WriteLine("3 Thoat");
                int chon = int.Parse(Console.ReadLine());
                if (chon == 0)
                {
                    break;
                }
                switch (chon)
                {
                    case 1:
                        a = new NhanvienPTN();
                        break;
                    case 2:
                        a = new NhanvienQL();
                        break;
                    default:
                        break;
                }
                a.Nhap();
                ds.Add(a);
            } while (true);
        }
        
        public void xuat()
        {
            foreach (var item in ds)
            {
                Console.WriteLine("-----------------------");
                item.Xuat();
                Console.WriteLine();
            }
        }

        public void TinhTongLuong(){
            float luongQL, luongPTN;
            luongQL = ds.OfType<NhanvienQL>().Sum(nv => nv.Tinhluong());
            luongPTN = ds.OfType<NhanvienPTN>().Sum(nv => nv.Tinhluong());
            Console.WriteLine("Luong NhanvienQL: {0}",luongQL);
            Console.WriteLine("Luong NhanvienPTN: {0}",luongPTN);
        }

        public void dsluong(){
            List<Nhanvien> lnv =ds.Where(nv => nv.Tinhluong() >= 10).ToList();
            if (lnv.Count==0){
                Console.WriteLine("khong co ");
            }
            else{
                foreach (var item in lnv)
                {
                    item.Xuat();
                }
            }
        }
    }
}
