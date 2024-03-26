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
using System.Windows.Shapes;
using practica_herder1.classes;
using practica_herder1.windows;

namespace practica_herder1.windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void try_Click(object sender, RoutedEventArgs e)
        {
            var lolig = login.Text;
            var pass = password.Text;
            var mail = email.Text;
            var pas2 = password_reapet.Text;
            var context = new AppDbContext();

            var user_exist = context.Users.FirstOrDefault(x => x.LogIn == lolig);
            if (user_exist != null)
            {
                MessageBox.Show("I FOUND YOU FAKER");
                return;
            }
            var user = new User { LogIn = lolig , Password = pass, Email = mail};
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("YOU ARE ALLOWED");
        }
    }
}
