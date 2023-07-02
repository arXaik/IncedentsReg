using IncedentsReg.Model;
using IncedentsReg.View;
using Kurs.Model;
using Kurs.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Kurs.ViewModel
{
    internal class LoginViewModel
    {
        private ModelContext db;
        private LoginView window;

        public LoginViewModel(LoginView window)
        {
            this.window = window;
            db = new ModelContext();
        }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                  (loginCommand = new RelayCommand(obj =>
                  {
                      string login = window.LoginBox.Text;
                      string password = Hash(window.PasswordBox.Password);
                      User user = db.User.Where(p => p.Login == login && p.Password == password).FirstOrDefault();
                      if (user != null)
                      {
                          MainWindow participation = new MainWindow();
                          participation.Show();
                      }
                      else
                      {
                          MessageBox.Show("Неправильный логин или пароль");
                      }
                  }));
            }
        }
        private RelayCommand registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ??
                  (registerCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          User user = new User();
                          user.Login = window.LoginBox.Text;
                          user.Password = Hash(window.PasswordBox.Password);
                          db.User.Add(user);
                          int res = db.SaveChanges();
                          if (res == 1) MessageBox.Show("Пользователь успешно создан");
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        private string Hash(string stringToHash)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
            }
        }
    }
}
