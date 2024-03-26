using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using practica_herder1.windows;
using Microsoft.EntityFrameworkCore;
using practica_herder1.classes;

namespace practica_herder1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

   

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            var log = logIn.Text;
            var passwor = password.Text;
            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.LogIn == log && x.Password == passwor);

            if (user == null)
            {
                MessageBox.Show("НЕПРААААВИЛЬНО");
                return;
            }

            MessageBox.Show("УДАЧЕЙ ОБЛАДАЕШЬ ТЫ, МОЙ ЮНЫЙ ПАДАВАН");
        }

        private void toRegister_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Hide();

            var login = logIn.Text;
            var pass = password.Text;
        
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
