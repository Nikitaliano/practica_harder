using practica_herder1.classes;
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

namespace practica_herder1.windows
{
    /// <summary>
    /// Логика взаимодействия для Window_final.xaml
    /// </summary>
    public partial class Window_final : Window
    {
        public int _id;           
        public Window_final(string userlogun1, int id)
        {
            InitializeComponent();
            _id = id;
            var content = new AppDbContext();
            var user = content.Users.FirstOrDefault(x => x.ID == id);
            string detector = user.LogIn;
            greeting.Text += detector;
        }

      

        private void create_Click(object sender, RoutedEventArgs e)
        {
           
           int ik = _id;
            rename win = new rename(ik);
            win.Show();
            this.Hide();
        }

        private void ex_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Hide();
        }
    }
}
