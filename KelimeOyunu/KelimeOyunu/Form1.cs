using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KelimeOyunu
{
    public partial class Form1 : Form
    {
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        OleDbCommand komut;
        DataSet verikumesi;
        private string isim;
        Random rastgele = new Random();
        int sorusaniye = 20;
        int topdakika = 4;
        int topsaniye = 60;
        bool cevap = false;
        int i = 0;
        Label[] harfler = new Label[10];
        string[,] sorular;
        PictureBox[] kutucuklar = new PictureBox[10];
        int sorupuan;
        int toppuan = 0;

        public Form1()
        {
            InitializeComponent();
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=kelimeoyunu.mdb");
            soruSure.Interval = 1000;
            genelSure.Interval = 1000;
            SoruLabel.Text = "";
            cevapBox.Text = "";
            puanToplamLabel.Text = "";
            soruPuanLabel.Text = "";
            cevapBox.CharacterCasing = CharacterCasing.Upper;
            harfler[0] = harfBir;
            harfler[1] = harfIki;
            harfler[2] = harfUc;
            harfler[3] = harfDort;
            harfler[4] = harfBes;
            harfler[5] = harfAltı;
            harfler[6] = harfYedi;
            harfler[7] = harfSekiz;
            harfler[8] = harfDokuz;
            harfler[9] = harfOn;
            kutucuklar[0] = pictureBox1;
            kutucuklar[1] = pictureBox2;
            kutucuklar[2] = pictureBox3;
            kutucuklar[3] = pictureBox4;
            kutucuklar[4] = pictureBox5;
            kutucuklar[5] = pictureBox6;
            kutucuklar[6] = pictureBox7;
            kutucuklar[7] = pictureBox8;
            kutucuklar[8] = pictureBox9;
            kutucuklar[9] = pictureBox10;


            for (int i = 0; i < harfler.Length; i++)
            {
                harfler[i].Visible = false;
                kutucuklar[i].Visible = false;
            }
            cevaplaButon.Enabled = false;
            cevapla1Button.Enabled = false;
            harfalButon.Enabled = false;
        }

        private void oynaButon_Click(object sender, EventArgs e)
        {

            oyna oyna = new oyna();
            oyna.ShowDialog();
            this.isim = oyna.isimcagir();

            if (oyna.basla)
            {
                oynaButon.Visible = false;
                iptalButon.Visible = true;
                sorular = Baslat();
                puanToplamLabel.Visible = true;
                soruPuanLabel.Visible = true;
                cevapla1Button.Enabled = true;
                harfalButon.Enabled = true;
                soruEkleButon.Enabled = false;
                enlerButon.Enabled = false;
                sorugec();

            }
        }
        //Yüksek Skorları kaydetme
        private void kaydet(string isim, int skor, int kalansure)
        {
            
            string tarih = DateTime.Now.ToLongDateString();
            string saat = DateTime.Now.ToShortTimeString();
            try
            {
                adaptor = new OleDbDataAdapter("Select Skor,KalanSure,Sayi from YuksekSkor ORDER BY Skor ASC", baglanti);
                verikumesi = new DataSet();
                baglanti.Open();
                adaptor.Fill(verikumesi, "YuksekSkor");
                int x = verikumesi.Tables["YuksekSkor"].Rows.Count;
                int temp = Convert.ToInt32(verikumesi.Tables["YuksekSkor"].Rows[0][0].ToString());
                int temp2 = Convert.ToInt32(verikumesi.Tables["YuksekSkor"].Rows[0][1].ToString());
                int temp3 = Convert.ToInt32(verikumesi.Tables["YuksekSkor"].Rows[0][2].ToString());
                if (x < 10)
                {
                    komut = new OleDbCommand();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert into YuksekSkor (Tarih, Saat, İsim, Skor, KalanSure) values (@ptarih, @psaat, @pisim, @pskor, @pkalansure)";
                    komut.Parameters.AddWithValue("@ptarih", tarih);
                    komut.Parameters.AddWithValue("@psaat", saat);
                    komut.Parameters.AddWithValue("@pisim", isim);
                    komut.Parameters.AddWithValue("@pskor", skor);
                    komut.Parameters.AddWithValue("@pkalansure", kalansure);
                    komut.ExecuteNonQuery();
                }
                else if ((skor > temp) || ((skor == temp) && (kalansure < temp2)))
                {

                    komut = new OleDbCommand();
                    komut.Connection = baglanti;
                    komut.CommandText = "delete from YuksekSkor where Sayi=" + temp3.ToString() + "";
                    komut.ExecuteNonQuery();
                    komut = new OleDbCommand();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert into YuksekSkor (Tarih, Saat, İsim, Skor, KalanSure) values (@ptarih, @psaat, @pisim, @pskor, @pkalansure)";
                    komut.Parameters.AddWithValue("@ptarih", tarih);
                    komut.Parameters.AddWithValue("@psaat", saat);
                    komut.Parameters.AddWithValue("@pisim", isim);
                    komut.Parameters.AddWithValue("@pskor", skor);
                    komut.Parameters.AddWithValue("@pkalansure", kalansure);
                    komut.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                try
                {
                    komut = new OleDbCommand();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert into YuksekSkor (Tarih, Saat, İsim, Skor, KalanSure) values (@ptarih, @psaat, @pisim, @pskor, @pkalansure)";
                    komut.Parameters.AddWithValue("@ptarih", tarih);
                    komut.Parameters.AddWithValue("@psaat", saat);
                    komut.Parameters.AddWithValue("@pisim", isim);
                    komut.Parameters.AddWithValue("@pskor", skor);
                    komut.Parameters.AddWithValue("@pkalansure", kalansure);
                    komut.ExecuteNonQuery();
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("HATA", "Kayıt Başarısız");
                }
            }
            baglanti.Close();
        }
        //Soru ekleme Butonu
        private void soruEkleButon_Click(object sender, EventArgs e)
        {
            kelimeekle kelimeekle = new kelimeekle();
            kelimeekle.ShowDialog();
        }
        //Soruları rastgele çekme
        private string[,] Baslat()
        {
            string s;
            string c;


            adaptor = new OleDbDataAdapter("Select * from Sorular", baglanti);
            verikumesi = new DataSet();
            baglanti.Open();
            adaptor.Fill(verikumesi, "Sorular");
            string[,] sorular = new string[14, 2];


            //4 harfli rastgele soru seçme
            adaptor = new OleDbDataAdapter("Select * from Sorular where HarfSayi = 4", baglanti);
            verikumesi = new DataSet();
            adaptor.Fill(verikumesi, "Sorular");
            int y = 0;
            int z = 0;
            while (y == z)
            {
                y = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
                z = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
            }
            c = verikumesi.Tables["Sorular"].Rows[y][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[y][1].ToString();
            sorular[0, 0] = c;
            sorular[0, 1] = s;
            c = verikumesi.Tables["Sorular"].Rows[z][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[z][1].ToString();
            sorular[1, 0] = c;
            sorular[1, 1] = s;

            //5 harfli rastgele soru seçme
            adaptor = new OleDbDataAdapter("Select * from Sorular where HarfSayi = 5", baglanti);
            verikumesi = new DataSet();
            adaptor.Fill(verikumesi, "Sorular");
            y = 0;
            z = 0;
            while (y == z)
            {
                y = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
                z = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
            }
            c = verikumesi.Tables["Sorular"].Rows[y][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[y][1].ToString();
            sorular[2, 0] = c;
            sorular[2, 1] = s;
            c = verikumesi.Tables["Sorular"].Rows[z][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[z][1].ToString();
            sorular[3, 0] = c;
            sorular[3, 1] = s;

            //6 harfli rastgele soru seçme
            adaptor = new OleDbDataAdapter("Select * from Sorular where HarfSayi = 6", baglanti);
            verikumesi = new DataSet();
            adaptor.Fill(verikumesi, "Sorular");
            y = 0;
            z = 0;
            while (y == z)
            {
                y = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
                z = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
            }
            c = verikumesi.Tables["Sorular"].Rows[y][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[y][1].ToString();
            sorular[4, 0] = c;
            sorular[4, 1] = s;
            c = verikumesi.Tables["Sorular"].Rows[z][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[z][1].ToString();
            sorular[5, 0] = c;
            sorular[5, 1] = s;

            //7 harfli rastgele soru seçme
            adaptor = new OleDbDataAdapter("Select * from Sorular where HarfSayi = 7", baglanti);
            verikumesi = new DataSet();
            adaptor.Fill(verikumesi, "Sorular");
            y = 0;
            z = 0;
            while (y == z)
            {
                y = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
                z = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
            }
            c = verikumesi.Tables["Sorular"].Rows[y][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[y][1].ToString();
            sorular[6, 0] = c;
            sorular[6, 1] = s;
            c = verikumesi.Tables["Sorular"].Rows[z][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[z][1].ToString();
            sorular[7, 0] = c;
            sorular[7, 1] = s;

            //8 harfli rastgele soru seçme
            adaptor = new OleDbDataAdapter("Select * from Sorular where HarfSayi = 8", baglanti);
            verikumesi = new DataSet();
            adaptor.Fill(verikumesi, "Sorular");
            y = 0;
            z = 0;
            while (y == z)
            {
                y = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
                z = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
            }
            c = verikumesi.Tables["Sorular"].Rows[y][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[y][1].ToString();
            sorular[8, 0] = c;
            sorular[8, 1] = s;
            c = verikumesi.Tables["Sorular"].Rows[z][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[z][1].ToString();
            sorular[9, 0] = c;
            sorular[9, 1] = s;

            //9 harfli rastgele soru seçme
            adaptor = new OleDbDataAdapter("Select * from Sorular where HarfSayi = 9", baglanti);
            verikumesi = new DataSet();
            adaptor.Fill(verikumesi, "Sorular");
            y = 0;
            z = 0;
            while (y == z)
            {
                y = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
                z = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
            }
            c = verikumesi.Tables["Sorular"].Rows[y][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[y][1].ToString();
            sorular[10, 0] = c;
            sorular[10, 1] = s;
            c = verikumesi.Tables["Sorular"].Rows[z][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[z][1].ToString();
            sorular[11, 0] = c;
            sorular[11, 1] = s;

            //10 harfli rastgele soru seçme
            adaptor = new OleDbDataAdapter("Select * from Sorular where HarfSayi = 10", baglanti);
            verikumesi = new DataSet();
            adaptor.Fill(verikumesi, "Sorular");
            y = 0;
            z = 0;
            while (y == z)
            {
                y = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
                z = rastgele.Next(verikumesi.Tables["Sorular"].Rows.Count);
            }
            c = verikumesi.Tables["Sorular"].Rows[y][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[y][1].ToString();
            sorular[12, 0] = c;
            sorular[12, 1] = s;
            c = verikumesi.Tables["Sorular"].Rows[z][0].ToString();
            s = verikumesi.Tables["Sorular"].Rows[z][1].ToString();
            sorular[13, 0] = c;
            sorular[13, 1] = s;

            baglanti.Close();
            return sorular;
        }




        //Kırmızı Buton
        private void cevapla1Button_Click(object sender, EventArgs e)
        {
            sorusaniye = 20;
            soruSureSaniye.Text = "20";
            soruSure.Start();
            genelSure.Stop();
            cevapBox.Enabled = true;
            cevaplaButon.Enabled = true;
            soruSureSaniye.Visible = true;
            cevapla1Button.Enabled = false;
        }
        //Soru Süresi
        private void soruSure_Tick(object sender, EventArgs e)
        {
            sorusaniye--;
            if (sorusaniye > -1)
            {
                soruSureSaniye.Text = sorusaniye.ToString();
            }
            else
            {
                cevaplaButon.Enabled = false;
                cevapBox.Text = "";
                cevapBox.Enabled = false;
                soruSure.Stop();
                char[] cvp = sorular[i - 1, 0].ToCharArray();
                for (int z = 0; z < cvp.Length; z++)
                {
                    harfler[z].Text = cvp[z].ToString();
                    harfler[z].Visible = true;
                    harfler[z].Update();
                    System.Threading.Thread.Sleep(1000);
                }
                toppuan -= sorupuan;
                sorugec();
            }
        }
        private void sorugec()
        {
            if (i == 14)
            {
                Bitir();
            }
            char[] chararr = sorular[i, 0].ToCharArray();

            for (int i = 0; i < chararr.Length; i++)
            {
                kutucuklar[i].Visible = true;

                harfler[i].Text = "";
                harfler[i].Visible = false;
            }
            SoruLabel.Text = sorular[i, 1];
            genelSure.Start();
            soruSure.Stop();
            soruSureSaniye.Text = "20";
            soruSureSaniye.Visible = false;
            puanToplamLabel.Text = toppuan.ToString();

            sorupuan = chararr.Length * 100;
            soruPuanLabel.Text = sorupuan.ToString();
            cevapla1Button.Enabled = true;
            harfalButon.Enabled = true;
            i++;
        }
        // Cevapladım Butonu
        private void cevaplaButon_Click(object sender, EventArgs e)
        {
            if (cevapBox.Text.Equals(sorular[i - 1, 0]))
            {
                cevap = true;
            }

            if (cevap)
            {
                if (i < 14)
                {

                    char[] cvp = sorular[i - 1, 0].ToCharArray();
                    for (int z = 0; z < cvp.Length; z++)
                    {
                        harfler[z].Text = cvp[z].ToString();
                        harfler[z].Visible = true;
                        harfler[z].Update();
                        System.Threading.Thread.Sleep(500);
                    }


                    toppuan += sorupuan;
                    sorugec();
                    cevap = false;
                }
                else
                {
                    Bitir();
                }

                cevaplaButon.Enabled = false;
                soruSureSaniye.Visible = false;
                cevapBox.Enabled = false;
                cevapBox.Text = "";
            }

        }
        //Toplam Süre Sayacı
        private void genelSure_Tick(object sender, EventArgs e)
        {
            topsaniye = topsaniye - 1;
            toplamSureSaniye.Text = Convert.ToString(topsaniye);
            toplamSureDakika.Text = Convert.ToString(topdakika - 1);
            if (topsaniye == 0)
            {

                topdakika = topdakika - 1;
                toplamSureDakika.Text = Convert.ToString(topdakika);
                topsaniye = 60;
            }

            if (toplamSureDakika.Text == "-1")
            {
                Bitir();
            }

        }
        private void Bitir()
        {
            genelSure.Stop();
            soruSure.Stop();
            string tarih = DateTime.Now.ToLongDateString();
            string saat = DateTime.Now.ToShortTimeString();
            int kalansure = (Convert.ToInt32(toplamSureDakika.Text) * 60) + Convert.ToInt32(toplamSureSaniye.Text);
            string puanınız = "Oyuncunun Adı: " + this.isim + "\nOyuncunun Puanı :" + toppuan.ToString() + "\nKalan Süre: " + kalansure.ToString()+"s\nOynama Tarihi: "+tarih+"\nOynama Zamanı: " +saat;
            MessageBox.Show(puanınız,"Puanınız");
            kaydet(this.isim, toppuan, kalansure);
            toplamSureDakika.Text = "00";
            toplamSureSaniye.Text = "00";
            topsaniye = 60;
            topdakika = 4;
            sorusaniye = 20;
            SoruLabel.Text = "";
            cevapBox.Text = "";
            puanToplamLabel.Text = "";
            soruPuanLabel.Text = "";

            for (int i = 0; i < harfler.Length; i++)
            {
                harfler[i].Visible = false;
                kutucuklar[i].Visible = false;
            }
            cevaplaButon.Enabled = false;
            cevapla1Button.Enabled = false;
            harfalButon.Enabled = false;
            this.toppuan = 0;
            this.i = 0;
            soruEkleButon.Enabled = true;
            enlerButon.Enabled = true;
        }

        private void iptalButon_Click(object sender, EventArgs e)
        {
            iptalButon.Visible = false;
            oynaButon.Visible = true;
            Bitir();
        }

        //Harf Alma Butonu        
        private void harfalButon_Click(object sender, EventArgs e)
        {
            char[] chararr = sorular[i - 1, 0].ToCharArray();
            int z;
            int y = 0;
            for (int i = 0; i < chararr.Length; i++)
            {
                if (harfler[i].Visible)
                {
                    y++;
                }
            }
            if (y == chararr.Length)
            {
                harfalButon.Enabled = false;
                return;
            }

            do
            {
                z = rastgele.Next(0, chararr.Length);
                harfler[z].Text = chararr[z].ToString();

            }
            while (harfler[z].Visible);

            sorupuan -= 100;
            soruPuanLabel.Text = sorupuan.ToString();
            harfler[z].Visible = true;




        }

        private void enlerButon_Click(object sender, EventArgs e)
        {
            YuksekSkorlar yuksekSkorlar = new YuksekSkorlar();
            yuksekSkorlar.ShowDialog();
        }

    }
}
