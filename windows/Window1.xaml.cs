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
                login.BorderBrush = Brushes.Red;
                logErr.Visibility = Visibility.Visible;
                return;
            }

            if(login.Text.Length >=1 && password.Text.Length > 6 && email.Text.Length > 6) 
            {
                if(email.Text.Contains("@") && email.Text.Contains(".")) 
                {
                    errow.Visibility = Visibility.Hidden;
                    if (pass == pas2)
                    {
                        error_cop.Visibility = Visibility.Hidden;
                        var user = new User { LogIn = lolig, Password = pass, Email = mail };
                        context.Users.Add(user);
                        context.SaveChanges();
                        MessageBox.Show("YOU ARE ALLOWED");
                        MainWindow win = new MainWindow();
                        win.Show();
                        this.Hide();

                    }
                    else
                    {
                        error_cop.Visibility = Visibility.Visible;
                        password_reapet.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    errow.Visibility = Visibility.Visible;
                    email.BorderBrush = Brushes.Red;
                }
            }
            
            if(login.Text.Length < 1)
            {
                error_log.Visibility = Visibility.Visible;
                login.BorderBrush = Brushes.Red;
            }
            else
            {
                error_log.Visibility = Visibility.Hidden;

            }
            if (password.Text.Length < 6)
            {
                error_pa.Visibility = Visibility.Visible;
                password.BorderBrush = Brushes.Red;
            }
            else
            {
                error_pa.Visibility = Visibility.Hidden;

            }
            if (email.Text.Length < 6)
            {
                error_ma.Visibility = Visibility.Visible;
                email.BorderBrush = Brushes.Red;
            }
            else
            {
                error_ma.Visibility = Visibility.Hidden;

            }
        }
    }
}
