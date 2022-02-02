using System.Windows.Controls;
using System;
using System.Data;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security;
using System.Windows.Media.Animation;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// ChatPage.xaml 的互動邏輯
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel"></param>
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();

        }

        #endregion

        #region Override Methods

        

        #endregion
    }
}
