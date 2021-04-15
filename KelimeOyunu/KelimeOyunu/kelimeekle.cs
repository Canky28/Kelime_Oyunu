using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KelimeOyunu
{
    public partial class kelimeekle : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=kelimeoyunu.mdb");
        OleDbCommand komut;

        public kelimeekle()
        {
            InitializeComponent();
            cevapBox.Text = "";
            soruBox.Text = "";
            cevapBox.CharacterCasing = CharacterCasing.Upper;
            soruBox.CharacterCasing = CharacterCasing.Upper;
        }

        private void kelimeekleButon_Click(object sender, EventArgs e)
        {
            try
            {
                string cevap = cevapBox.Text;
                string soru = soruBox.Text;
                if (soru != "" && cevap != "")
                {
                    char[] harf = cevap.ToCharArray();
                    komut = new OleDbCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert into Sorular (Kelime,Soru,HarfSayi) values (@pkelime, @pSoru, @pharf)";
                    komut.Parameters.AddWithValue("@pkelime", cevap);
                    komut.Parameters.AddWithValue("@psoru", soru);
                    komut.Parameters.AddWithValue("@pharf", harf.Length);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Ekleme Başarılı");
                    cevapBox.Text = "";
                    soruBox.Text = "";
                }
                else MessageBox.Show("Lütfen boş alanları doldurun", "Ekleme Başarısız");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme Başarısız", "Hata");
            }


        }

        private void iptalButon_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kelimeekle_Load(object sender, EventArgs e)
        {

        }
    }
}
