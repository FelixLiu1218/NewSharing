﻿using NewProject.Core;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Dna;

namespace NewProject
{
    /// <summary>
    /// the base page for all pages to gain base functionality
    /// </summary>
    public class BasePage : UserControl
    {
        #region Private menber

        private object _viewModel;

        #endregion

        #region Public Properties

        public Animation PageLoadAnimation { get; set; } = Animation.SlideAndFadeInFromRight;

        public Animation PageUnloadAnimation { get; set; } = Animation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.55f;

        /// <summary>
        /// a flag to indicate if this page should animate out on load
        /// when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        /// <summary>
        /// the view model associated with this page
        /// </summary>
        public object ViewModelObject
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value) return;

                _viewModel = value;

                //View model change
                OnViewModelChanged();

                //set the data context for this page
                DataContext = _viewModel;
            }
        }

        #endregion


        #region Constructor

        public BasePage()
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;


            if (PageLoadAnimation != Animation.None)
            {
                Visibility = Visibility.Collapsed;
            }


            Loaded += BasePage_Loaded;
        }

        #endregion


        #region Animation Load or Unload


        public async Task AnimateIn()
        {
            if (PageLoadAnimation == Animation.None) return;

            switch (PageLoadAnimation)
            {
                case Animation.SlideAndFadeInFromRight:

                    //Start the animation
                    await this.SlideFadeIn(AnimationInDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);

                    break;
                default:
                    Debugger.Break();
                    break;
            }
        }
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            //if we are setup to animate ot on load
            if (ShouldAnimateOut)
            {
                await AnimateOut();
            }
            else
            {
                await AnimateIn();
            }
        }



        public async Task AnimateOut()
        {
            if (PageUnloadAnimation == Animation.None) return;

            switch (PageUnloadAnimation)
            {
                case Animation.SlideAndFadeOutToLeft:

                    //Start the animation
                    await this.SlideFadeOut(AnimationInDirection.Left, SlideSeconds);

                    break;
            }
        }

        #endregion

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected virtual void OnViewModelChanged()
        {

        }

    }

    public class BasePage<VM> : BasePage
        where VM:BaseViewModel,new()

    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public VM ViewModel
        {
            get => (VM) ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage() : base()
        {
            // If in design time mode...
            if (DesignerProperties.GetIsInDesignMode(this))
                // Just use a new instance of the VM
                ViewModel = new VM();
            else
                // Create a default view model
                ViewModel = Framework.Service<VM>() ?? new VM();
        }

        public BasePage(VM specificViewModel =null) : base()
        {
            // Set specific view model
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
            {
                // If in design time mode...
                if (DesignerProperties.GetIsInDesignMode(this))
                    // Just use a new instance of the VM
                    ViewModel = new VM();
                else
                {
                    // Create a default view model
                    ViewModel = Framework.Service<VM>() ?? new VM();
                }
            }
        }

            #endregion
    }
}
