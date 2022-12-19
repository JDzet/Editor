using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace По_новой
{
    public partial class editintProduct : Form
    {
        public editintProduct(string name)
        {
            InitializeComponent();
            label1.Text = name;
        }

        private void editintProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            Catalog c = new Catalog(label1.Text);
            c.Show();

        }
    }
}
