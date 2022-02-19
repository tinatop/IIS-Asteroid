using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class MainForm : Form
    {
        private string token;

        public MainForm(string JWTtoken)
        {
            InitializeComponent();
            token = JWTtoken;
        }

        private void btnXSD_Click(object sender, EventArgs e)
        {
            XSDValidacija form = new XSDValidacija(token);
            form.Show();

        }

        private void btnRNG_Click(object sender, EventArgs e)
        {
            RNGValidacija form = new RNGValidacija(token);
            form.Show();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SOAP_Pretrazivanje form = new SOAP_Pretrazivanje();
            form.Show();
        }

        private void btnTemperatura_Click(object sender, EventArgs e)
        {
            Temperatura form = new Temperatura();
            form.Show();
        }
    }
}
