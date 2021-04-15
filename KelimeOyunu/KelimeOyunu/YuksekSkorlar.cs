using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KelimeOyunu
{
    public partial class YuksekSkorlar : Form
    {
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        DataSet verikumesi;
        public YuksekSkorlar()
        {
            InitializeComponent();
        }

        private void YuksekSkorlar_Load(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=kelimeoyunu.mdb");
            adaptor = new OleDbDataAdapter("Select Tarih,Saat,İsim,Skor,KalanSure from YuksekSkor ORDER BY Skor DESC, KalanSure DESC ", baglanti);
            verikumesi = new DataSet();
            baglanti.Open();
            adaptor.Fill(verikumesi, "YuksekSkor");
            dataGridView1.DataSource = verikumesi.Tables["YuksekSkor"];
            baglanti.Close();
        }
    }
}
