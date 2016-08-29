using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersSecimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //this.Text = cbSinif.SelectedItem.ToString();

            //selectedindex kaçıncı item ın seçili olduğunu verir.
            //selectedtext bişey vermez
            //selectedvalue daha çok db bağlantılarıyla alakalı
            //selecteditem cb içinde görünen değeri verir.
            if (!string.IsNullOrEmpty(txtAd.Text) && cbSinif.SelectedIndex>=0)
            {
                Ogrenci std = new Ogrenci
                    {
                        AdSoyad = txtAd.Text,
                        Sinif = cbSinif.SelectedItem.ToString()
                    };

                ListBox.SelectedObjectCollection secimler = lbDersler.SelectedItems;

                std.alinanDersler = new string[secimler.Count];
                for (int i = 0; i < std.alinanDersler.Length; i++)
                {
                    std.alinanDersler[i] = secimler[i].ToString();
                }

                string ders = "";
                for (int i = 0; i < std.alinanDersler.Length; i++)
                {
                    ders += std.alinanDersler[i] + "\n";
                }
                if (std.alinanDersler.Length == 0)
                {
                    MessageBox.Show("Ders seçimi yapılmadı.","HATA!..");
                }
                else
                {
                    MessageBox.Show(string.Format("İsim:{0}\nSınıf:{1}\n{2}", std.AdSoyad, std.Sinif, ders), "DURUM");
                } 
            }
        }

        //combobox da yapılan her seçimde bu metot çalışır.
        private void cbSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbDersler.Items.Clear();

            string dersAdi = cbSinif.SelectedItem.ToString();
            object[] dersler;
            switch (dersAdi)
            {
                case "JAVA":
                case ".NET":
                    dersler = new object[] { "Veritabanı", "Algoritma", "Design Pattern", "Programlama", "WEB" };
                    lbDersler.Items.AddRange(dersler);
                    break;
                case "SİSTEM":
                case "CISCO":
                    dersler = new object[] { "Network", "Linux", "Routing", "Microsoft" };
                    lbDersler.Items.AddRange(dersler);
                    break;
                case "ERP":
                    dersler = new object[] { "Veritabanı", "SAP", "Dynamics", "Programlama" };
                    lbDersler.Items.AddRange(dersler);
                    break;
            }
        }

        private void Acilis(object sender, EventArgs e)
        {
            this.Text = "Ders Seçim Formu";

        }


    }
}
