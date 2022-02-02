using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewProject
{
    /// <summary>
    /// Base attached property
    /// </summary>
    /// <typeparam></typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()

    {
        #region Public Events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// A singleton instance of parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",typeof(Property),
            typeof(BaseAttachedProperty<Parent,Property>),
            new PropertyMetadata(
                default (Property),
                new PropertyChangedCallback(OnValuePropertyChanged),
                new CoerceValueCallback(OnValuePropertyUpdated)
                ));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d,e);
            // call event listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d,e);
        }

        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);
            // call event listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            return value;
        }

        

        public static Property GetValue(DependencyObject d) => (Property) d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }

        public virtual void OnValueUpdated(DependencyObject sender, object value)
        {

        }
        #endregion
    }


}
