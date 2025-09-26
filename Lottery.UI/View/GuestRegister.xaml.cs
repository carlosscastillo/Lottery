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

namespace Lottery.UI.View
{
    /// <summary>
    /// Lógica de interacción para GuestRegister.xaml
    /// </summary>
    public partial class GuestRegister : Window
    {
        public GuestRegister()
        {
            InitializeComponent();
        }

        private void StartGuestButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Bienvenido invitado: {GuestNicknameTextBox.Text}");

            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
