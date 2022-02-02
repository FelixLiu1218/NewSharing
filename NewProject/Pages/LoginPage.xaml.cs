using System.Windows.Controls;
using System;
using System.Data;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// LoginPage.xaml 的互動邏輯
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>,IHavePassword
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor whit specific view model
        /// </summary>
        public LoginPage(LoginViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        //the secure password for this login page
        public SecureString SecurePassword  => PasswordText.SecurePassword;
    }
}
