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
using System.Windows.Threading;

namespace practica_herder1
{




    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

   

    public partial class MainWindow : Window
    {
        private int failedAttempts = 0;
        private DispatcherTimer timer;
        int counter = 3;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(15);
            timer.Tick += Timer_Tick;
        }
        

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            var log = logIn.Text;
            var passwor = password.Text;
            var context = new AppDbContext();
            string userlogun1;
            full_fail.Visibility = Visibility.Collapsed;


            var user = context.Users.SingleOrDefault(x => (x.LogIn == log && x.Password == passwor) || (x.Email == log && x.Password == passwor));

            if (user is null)
            {
                          
               full_fail.Visibility = Visibility.Visible;
                i.Visibility = Visibility.Visible;
                counter--;
                if(counter == 0)
                {
                    counter = 3;
                }
               i.Text = counter.ToString();
                failedAttempts++;
                if (failedAttempts == 3)
                {
                    timer.Start();
                    logIn.IsEnabled = false;
                    enter.IsEnabled = false;
                    password_box.IsEnabled = false;
                    password.IsEnabled = false;
                    MessageBox.Show("не злоупотребляй. теперь ожидай");
                }
                return;
            }



            

           
            userlogun1 = log;
            int id = user.ID;
            Window_final win = new Window_final(userlogun1,id);
            win.Show();
            this.Hide();
            MessageBox.Show("УДАЧЕЙ ОБЛАДАЕШЬ ТЫ, МОЙ ЮНЫЙ ПАДАВАН");
            

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            failedAttempts = 0;
            logIn.IsEnabled = true;
            password.IsEnabled = true;
            password_box.IsEnabled = true;
            enter.IsEnabled = true;
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

        private void openeye_Click(object sender, RoutedEventArgs e)
        {
            var text = password_box.Password;
            password_box.Visibility = Visibility.Collapsed;
            password.Visibility = Visibility.Visible;
            password.Text = text;
            openeye.Visibility = Visibility.Hidden;
            closedeye.Visibility = Visibility.Visible;
        }

        private void closedeye_Click(object sender, RoutedEventArgs e)
        {
            var text1 = password.Text;
            password_box.Visibility= Visibility.Visible;
            password.Visibility= Visibility.Collapsed;
            password_box.Password = text1;
            closedeye.Visibility= Visibility.Hidden;
            openeye.Visibility= Visibility.Visible;
        }
    }
}
