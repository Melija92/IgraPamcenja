using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgraPamcenja
{
    public partial class UnosImena : Form
    {
        public String ImeIgraca { get; set; }
        public UnosImena()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImeIgraca = textBox1.Text;
            this.Close();
        }
    }
}
