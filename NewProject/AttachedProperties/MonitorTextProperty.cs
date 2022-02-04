using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;

namespace NewProject
{
    /// <summary>
    /// Monitor password,if password is null,makes the tag to visible 
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            
            var passwordBox = sender as PasswordBox;

            if (passwordBox == null) return;

            passwordBox.PasswordChanged -= PasswordBox_TextChanged;

            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValuePassword(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_TextChanged;
            }
        }

        private void PasswordBox_TextChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValuePassword((PasswordBox)sender);
        }
    }

    /// <summary>
    /// Monitor textBox,if textBox is null,makes the text to visible 
    /// </summary>
    public class MonitorTextProperty : BaseAttachedProperty<MonitorTextProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            var textBox = sender as TextBox;

            if (textBox == null) return;

            if (textBox.IsFocused)
                textBox.TextChanged -= TextBox_TextChanged;



            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValueText(textBox);
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValueText((TextBox)sender);
        }
    }

    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValueText(DependencyObject sender)
        {
            SetValue(sender, ((TextBox)sender).Text.Length > 0);
        }
        public static void SetValuePassword(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
