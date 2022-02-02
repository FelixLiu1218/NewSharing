using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Constructor

        public PageHost()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                NewPage.Content = IoC.Get<ApplicationViewModel>().CurrentPage.ToBasePage();
            }
        }

        #endregion


        #region Dependency Properties

        /// <summary>
        /// the current page to show in the page host
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// registers  CURRENT PAGE as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage),null,CurrentPagePropertyChanged));

        /// <summary>
        /// the current page to show in the page host
        /// </summary>
        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        /// <summary>
        /// registers  CURRENT PAGE as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel), 
                typeof(BaseViewModel), 
                typeof(PageHost), 
                new UIPropertyMetadata());

        #endregion


        #region Propert Changed Events

        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            //get the frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            // If the current hasn't changed update
            if (newPageFrame.Content is BasePage page && page.ToApplicationPage() == currentPage)
            {
                //Update the view model
                page.ViewModelObject = currentPageViewModel;
            
                return value;
            }

            //store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //remove current page from new page frame
            newPageFrame.Content = null;

            //move the previous page into the ole page frame
            oldPageFrame.Content = oldPageContent;

            //Animate out previous page
            if (oldPageContent is BasePage oldPage)
            {
                //tell old page animate out
                oldPage.ShouldAnimateOut = true;

                //remove old page
                Task.Delay((int) (oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }
            
            //set the new page content
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return value;
        }
        #endregion
    }
}
