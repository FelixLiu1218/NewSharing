using System.Windows.Controls;
using System;
using System.Data;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security;
using System.Windows.Input;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textbox = sender as TextBox;

            //If pressed enter key
            if (e.Key == Key.Enter)
            {
                //Check if control key pressed
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    // Add a new line 
                    var index = textbox.CaretIndex;

                    //Insert new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    //Shift the caret forward to the next line
                    textbox.CaretIndex = index + Environment.NewLine.Length;

                    //Mark this key as handled
                    e.Handled = true;
                }
                else
                {
                    //if pressed enter key ,then send the message
                    ViewModel.Send();
                }

                e.Handled = true;
            }
        }
    }
}
