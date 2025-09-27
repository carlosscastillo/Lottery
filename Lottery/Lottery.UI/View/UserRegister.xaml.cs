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
using Lottery.Data;

namespace Lottery.UI.View
{
    /// <summary>
    /// Lógica de interacción para UserRegister.xaml
    /// </summary>
    public partial class UserRegister : Window
    {
        public UserRegister()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Por favor, llena todos los campos obligatorios.", "Campos Vacíos");
                return;
            }
            if (PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de Contraseña");
                return;
            }

            RegistrationFormPanel.Visibility = Visibility.Collapsed;
            VerificationCodePanel.Visibility = Visibility.Visible;
            VerificationEmailTextBlock.Text = EmailTextBox.Text;
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new base_pruebaEntities())
            {
                var newUser = new User
                {
                    first_name = NameTextBox.Text,
                    paternal_last_name = PaternalLastNameTextBox.Text,
                    maternal_last_name = MaternalLastNameTextBox.Text,
                    nickname = NicknameTextBox.Text,
                    email = EmailTextBox.Text,
                    password = PasswordBox.Password,
                    registration_date = DateTime.Now,
                    id_avatar = 1
                };
                dbContext.User.Add(newUser);
                dbContext.SaveChanges();

                VerificationCodePanel.Visibility = Visibility.Collapsed;
                RegistrationCompletedPanel.Visibility = Visibility.Visible;
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            VerificationCodePanel.Visibility = Visibility.Collapsed;
            RegistrationFormPanel.Visibility = Visibility.Visible;
        }
    }
}
