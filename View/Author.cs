using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace По_новой
{
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
        }

        Thread th;
        RequestDB req = new RequestDB();
        public string name;

        private void button1_Click(object sender, EventArgs e)
        {
            var user = req.GetUser(textBoxLogin.Text, textBoxPassword.Text);

            if (user != null)
            {
                MessageBox.Show("Приветствуем: " + user.Name + "\nРоль: " + user.Role.RoleName);
                name = user.Name;
                this.Close();
                th = new Thread(CatalogForm);
                th.Start();
            }
            else 
            {
                MessageBox.Show("Логин или пароль неверный");
                Thread.Sleep(10);
            }

        }

        public void CatalogForm() 
        {
            Application.Run(new Catalog(name));
        }
    }
}
