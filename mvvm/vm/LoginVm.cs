using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Билет_20.Pages;
using Билет_20.Static;

namespace Билет_20.mvvm.vm
{
    public class LoginVm : BaseVm
    {
        bool needCapcha = false;
        private readonly PasswordBox passwordBox;
        private readonly Canvas capchaField;
        private Visibility capchaVisibility = Visibility.Collapsed;

        public string Login { get; set; }
        public string CapchaText { get; set; }

        string generateCapcha;
        public CommandVm RunLogin { get; set; }


        public Visibility CapchaVisibility
        {
            get => capchaVisibility;
            set
            {
                capchaVisibility = value;
                Signal();
            }
        }
        public LoginVm(PasswordBox passwordBox, Canvas capchaField)
        {
            this.passwordBox = passwordBox;
            this.capchaField = capchaField;

            RunLogin = new CommandVm(() =>
            {

                try
                {

                    var user = DataBase.Instance().Users.FirstOrDefault(s => s.UserLogin == Login && s.UserPassword
                    == passwordBox.Password);

                    bool success = user != null;

                    if (!success && generateCapcha != CapchaText)
                        success = false;

                    if (!success && needCapcha)
                    {
                        GenerateCapcha();
                        MessageBox.Show("Неверный логин или пароль");
                        return;
                    }
                    if (!success)
                    {
                        MessageBox.Show("Неверный логин или пароль.Требуется потверждение епси(капчи)");
                        needCapcha = true;
                        GenerateCapcha();
                        CapchaVisibility = Visibility.Visible;
                        return;
                    }

                    User.Loggen = user;
                    PageNavigator.Get().CurrentPage = new ListProducts();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка какая а хрен знает");
                }
            }, () => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(passwordBox.Password));

        }
        //97 123
        //65 91
        //48 58
        Random random = new Random();
        char GenerateChar()
        {
            if (random.Next(0, 10) > 5)
                return (char)random.Next(97, 123);
            else if (random.Next(0, 10) > 5)
                return (char)random.Next(65, 91);
            else
                return (char)random.Next(48, 58);
        }

        private void GenerateCapcha()
        {
            capchaField.Children.Clear();
            generateCapcha = null;
            for (int i = 0; i < 4; i++)
            {
                char simba = GenerateChar();
                generateCapcha += simba;
                var label = new Label();
                label.Content = simba;
                label.FontSize = 15;
                Canvas.SetTop(label, 15 + random.Next(-8, 9));
                Canvas.SetLeft(label, 10 * generateCapcha.Length + random.Next(-5, 5));
                capchaField.Children.Add(label);
            }
        }
    }
}
