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

namespace PasswordBoxWithEye.Controls
{
    /// <summary>
    /// Interaction logic for PaswordBoxWithEye.xaml
    /// </summary>
    public partial class PaswordBoxWithEye : UserControl
    {
        Boolean PasswordHiddenHasFocus = false;
        Boolean PasswordShowHasFocus = false;
        public PaswordBoxWithEye()
        {
            InitializeComponent();
        }
        public PasswordBox PasswordHidden
        {
            get { return textBoxPrivatePassword; }
            set { textBoxPrivatePassword = value; }
        }
        public TextBox PasswordVisible
        {
            get { return textBoxPlainPassword; }
            set { textBoxPlainPassword = value; }
        }

        private void labelEyeHide_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            labelEyeHide.Visibility = Visibility.Hidden;
            labelEyeShow.Visibility = Visibility.Visible;
            PasswordHidden.Visibility = Visibility.Hidden;
            PasswordVisible.Visibility = Visibility.Visible;
        }

        private void labelEyeShow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            labelEyeHide.Visibility = Visibility.Visible;
            labelEyeShow.Visibility = Visibility.Hidden;
            PasswordHidden.Visibility = Visibility.Visible;
            PasswordVisible.Visibility = Visibility.Hidden;
        }

        private void textBoxPrivatePassword_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordHiddenHasFocus = true;
            PasswordShowHasFocus = false;
        }

        private void textBoxPlainPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordShowHasFocus = true;
            PasswordHiddenHasFocus = false;
        }

        private void textBoxPrivatePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordShowHasFocus)
            { return; }
            textBoxPlainPassword.Text = textBoxPrivatePassword.Password;
        }

        private void textBoxPlainPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordHiddenHasFocus)
            { return; }
            textBoxPrivatePassword.Password = textBoxPlainPassword.Text;
        }
    }
}
