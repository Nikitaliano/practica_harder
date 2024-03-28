using practica_herder1.classes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
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



namespace practica_herder1.windows
{
    /// <summary>
    /// Логика взаимодействия для rename.xaml
    /// </summary>
    public partial class rename : Window
    {
        public int _id;
        public rename( int id)
        {
            InitializeComponent();
            _id = id;

        }

        private void upd_Click(object sender, RoutedEventArgs e)
        {
            
            string relogin = reLog.Text;
            string repasww = rePass.Text;
            string rem = reMail.Text;
            
           var userId = Convert.ToInt32( _id);
            var context = new AppDbContext();
            var USER = context.Users.Find(userId);
            USER.LogIn = relogin;
            USER.Email = rem;
            USER.Password = repasww;
            context.SaveChanges();
        }

        private void ext_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            Hide();
        }
    }
}
