using System;
using dataBaseConnectionTest.classes.Plugin;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace dataBaseConnectionTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

           
        }

        private void Register_Click(object sender, EventArgs e)
        {
            String data = Web.GetPost("http://127.0.0.1/Register.php", "UserName", "tim", "Password", "test");
            Console.WriteLine(data);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            String data = Web.GetPost("http://127.0.0.1/Login.php", "UserName", "daan", "Password", "test");
            Console.WriteLine(data);
        }
    }
}
