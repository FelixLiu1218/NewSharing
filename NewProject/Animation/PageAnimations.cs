using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NewProject
{
    public static class PageAnimations
    {
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromRight(seconds,page.WindowWidth);

            //Add slide from right animation
            sb.AddFadeIn(seconds);


            //Start animating
            sb.Begin(page);

            //make page visible
            page.Visibility = Visibility.Visible;

            await Task.Delay((int) (seconds * 1000));
        }

        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //Add slide from right animation
            sb.AddFadeOut(seconds);


            //Start animating
            sb.Begin(page);

            //make page visible
            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
    }
}
