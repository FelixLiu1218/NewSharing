using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NewProject
{
    public static class FrameworkElementAnimations
    {
        #region Slide In / Out
        /// <summary>
        /// Slides an element in
        /// </summary>
        /// <param name="element"></param>
        /// <param name="direction"></param>
        /// <param name="firstLoad"></param>
        /// <param name="seconds"></param>
        /// <param name="keepMargin"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static async Task SlideFadeIn(this FrameworkElement element, AnimationInDirection direction,
            bool firstLoad, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            switch (direction)
            {
                // Add slide from left animation
                case AnimationInDirection.Left:
                    sb.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide from right animation
                case AnimationInDirection.Right:
                    sb.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide from top animation
                case AnimationInDirection.Top:
                    sb.AddSlideFromTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                // Add slide from bottom animation
                case AnimationInDirection.Bottom:
                    sb.AddSlideFromBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible only if we are animating or its the first load
            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));

        }

        /// <summary>
        /// Slide an element out
        /// </summary>
        /// <param name="element"></param>
        /// <param name="direction"></param>
        /// <param name="seconds"></param>
        /// <param name="keepMargin"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static async Task SlideFadeOut(this FrameworkElement element, AnimationInDirection direction, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Slide in the correct direction
            switch (direction)
            {
                // Add slide to left animation
                case AnimationInDirection.Left:
                    sb.AddSlideToLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide to right animation
                case AnimationInDirection.Right:
                    sb.AddSlideToRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide to top animation
                case AnimationInDirection.Top:
                    sb.AddSlideToTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                // Add slide to bottom animation
                case AnimationInDirection.Bottom:
                    sb.AddSlideToBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }
            // Add fade in animation
            sb.AddFadeOut(seconds);
            // Start animating
            sb.Begin(element);
            // Make page visible only if we are animating
            if (seconds != 0)
                element.Visibility = Visibility.Visible;
            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
            // Make element invisible
            element.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Fade In / Out
        /// <summary>
        /// Fades an element in
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <returns></returns>
        public static async Task FadeIn(this FrameworkElement element, bool firstLoad, float seconds = 0.3f)
        {
            // Create the storyboard
            var sb = new Storyboard();
            // Add fade in animation
            sb.AddFadeIn(seconds);
            // Start animating
            sb.Begin(element);

            // Make page visible only if we are animating or its the first load
            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Fades out an element
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <returns></returns>
        public static async Task FadeOut(this FrameworkElement element, float seconds = 0.3f)
        {
            // Create the storyboard
            var sb = new Storyboard();
            // Add fade in animation
            sb.AddFadeOut(seconds);
            // Start animating
            sb.Begin(element);

            // Make page visible only if we are animating or its the first load
            if (seconds != 0)
                element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
            // Fully hide the element
            element.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
