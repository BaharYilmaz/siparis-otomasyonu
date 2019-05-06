using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiparisOtomasyonu
{
    public partial class Ana_Menu : Form
    {
        public Ana_Menu()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';

        }
        
        //verileri statik direk erişebiliyoruz
        public static List<string> ID = new List<string>();

        public static List<string> users = new List<string>();
        public static List<string> pass = new List<string>();
        public static List<string> Adres = new List<string>();
        public static bool Kontrol { get; set; }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            //berkan login 
            if (rdoCustomer.Checked)
            {
                StreamReader customerLogin = new StreamReader("CustomerLogin.txt",Encoding.GetEncoding("iso-8859-9"));

                string temp = "";
                while ((temp = customerLogin.ReadLine()) != null)
                {
                    string[] components = temp.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (txtPassword.Text==components[2])
                    {
                        ID.Add(components[0]);
                          users.Add(components[1]);
                         pass.Add(components[2]);
                        Adres.Add(components[3]);
                    }
                }
                customerLogin.Close();
    
                

                if (users.Contains(txtUser.Text) && pass.Contains(txtPassword.Text) && Array.IndexOf(users.ToArray(), txtUser.Text) == Array.IndexOf(pass.ToArray(), txtPassword.Text))
                {
                    //yetkilendirme boolen değişken
                    Kontrol = false;
                    Menu menu = new Menu();
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen doğru kullanıcı adı veya şifre giriniz.");
                    txtPassword.Text = "";
                    txtUser.Text = "";
                }
            }

            if (rdoAdmin.Checked)
            {
                
                StreamReader adminLogin = new StreamReader("AdminLogin.txt");
                string temp2 = "";
                while ((temp2 = adminLogin.ReadLine()) != null)
                {
                    string[] components2 = temp2.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    users.Add(components2[0]);
                    pass.Add(components2[1]);

                }
               
                adminLogin.Close();

                if (users.Contains(txtUser.Text) && pass.Contains(txtPassword.Text) && Array.IndexOf(users.ToArray(), txtUser.Text) == Array.IndexOf(pass.ToArray(), txtPassword.Text))
                {
                    // Yetkili_Firma adminForm = new Yetkili_Firma();
                    Kontrol = true;
                    // adminForm.Show();
                    Menu m = new Menu();
                    this.Hide();
                    m.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen doğru kullanıcı adı veya şifre giriniz.");
                    txtPassword.Text = "";
                    txtUser.Text = "";
                }

            }
        }

        private void Ana_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
