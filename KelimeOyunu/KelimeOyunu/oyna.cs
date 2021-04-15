using System;
using System.Windows.Forms;

namespace KelimeOyunu
{
    public partial class oyna : Form
    {
        private string isim;
        public bool basla;
        public oyna()
        {
            InitializeComponent();

        }

        private void oyna_Load(object sender, EventArgs e)
        {
            basla = false;
        }

        private void baslaButon_Click(object sender, EventArgs e)
        {
            this.isim = IsimBox.Text;
            basla = true;
            Close();
        }
        public string isimcagir()
        {
            return this.isim;
        }

        private void iptalButon_Click(object sender, EventArgs e)
        {
            basla = false;
            Close();
        }
    }
}
