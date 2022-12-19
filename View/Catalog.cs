using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using По_новой.Model;

namespace По_новой
{
    public partial class Catalog : Form
    {
        DemoMainEntities context = new DemoMainEntities();
        RequestDB req = new RequestDB();
        public Catalog(string name)
        {
            InitializeComponent();
            label1.Text = name;
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            comboBoxCatergor.Items.Add("Все категории");
            var categor = req.GetCategory();

            foreach (var x in categor)
            {
                comboBoxCatergor.Items.Add(x.CategoryName);
            }
            comboBoxCatergor.SelectedIndex = 0;
            comboBoxPrice.SelectedIndex = 0;
        }

        public void DataGeidLoad() 
        {
            var pr = context.Product.ToList();


            if (textBoxSearch.Text != null) 
            {
                pr = pr.Where(x => x.Name.Contains(textBoxSearch.Text)).ToList();
            }

            switch (comboBoxCatergor.SelectedIndex) 
            {
                case 1:
                    pr = pr.Where(x => x.Category.CategoryName == comboBoxCatergor.Text).ToList();
                    break;

                case 2:
                    pr = pr.Where(x => x.Category.CategoryName == comboBoxCatergor.Text).ToList();
                    break;
            }

            switch (comboBoxPrice.SelectedIndex)
            {
                case 1:
                    pr = pr.OrderBy(x => int.Parse(x.Price)).ToList();
                    break;

                case 2:
                    pr = pr.OrderByDescending(x => int.Parse(x.Price)).ToList();
                    break;
            }







            var product = req.GetProduct(pr);
            foreach (var x in product)
            {
                dataGridView1.Rows.Add(x);
            }

        }

        private void comboBoxCatergor_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataGeidLoad();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataGeidLoad();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            editintProduct edp = new editintProduct(label1.Text);
            edp.ShowDialog();
           
        }
    }
}
