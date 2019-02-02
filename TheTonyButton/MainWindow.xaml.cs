using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheTonyButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		bool canClick = true;
		
        public MainWindow()
        {
            InitializeComponent();

            Storyboard jugglingAnimation = (Storyboard)Resources["Juggling"];
            Storyboard moveToTopAnimation = (Storyboard)Resources["MoveToTop"];
            Storyboard emailAnimation = (Storyboard)Resources["EmailAnimation"];
            Storyboard gaspAnimation = (Storyboard)Resources["GaspAnimation"];
            Storyboard laptopAnimation = (Storyboard)Resources["LaptopAnimation"];
            Storyboard laptopAnimationReversed = (Storyboard)Resources["LaptopAnimationReversed"];
            Storyboard emailAnimationReversed = (Storyboard)Resources["EmailAnimationReversed"];
			Storyboard hover = (Storyboard)Resources["Hover"];
            Storyboard thumbsUp = (Storyboard)Resources["ThumbsUp"];
            Storyboard tapEffect = (Storyboard)Resources["TapEffects"];
            Storyboard reverseBalls = (Storyboard)Resources["MoveDown"];

            jugglingAnimation.Begin();

            //Keyboard handler to close the window when Escape key is pressed.
            KeyUp += (s, e) =>
                {
                    if(e.Key == Key.Escape)
                    {
                        Close();
                    }
                };

            TonyHead.MouseLeftButtonUp += (s, e) =>
            {
                if (canClick)
                {
                    canClick = false;
                    TonyHead.Cursor = Cursors.Arrow;
                    emailAnimation.Begin();
                }
            };

            emailAnimation.Completed += (s, e) =>
            {
				jugglingAnimation.Stop();
                moveToTopAnimation.Begin();
                laptopAnimation.Begin();
            };

            laptopAnimation.Completed += (s, e) =>
            {
                thumbsUp.Begin();

                emailAnimation.Stop();
            };
			
			moveToTopAnimation.Completed += (s, e) =>
            {
                hover.Begin();
            };

            laptopAnimation.Completed += (s, e) =>
            {
                tapEffect.Begin();
            };

            tapEffect.Completed += (s, e) =>
            {
                emailAnimationReversed.Begin();
            };

            emailAnimationReversed.Completed += (s, e) =>
            {
                laptopAnimationReversed.Begin();
            };

            laptopAnimationReversed.Completed += (s, e) =>
            {
                reverseBalls.Begin();
                hover.Stop();
            };

            reverseBalls.Completed += (s, e) =>
            {
                jugglingAnimation.Begin();
                canClick = true;
                TonyHead.Cursor = Cursors.Hand;
            };

            KeyUp += (s, e) =>
            {

                if (e.Key == Key.Up)
                {
                    reverseBalls.Begin();
                    
                    moveToTopAnimation.Stop();
                    emailAnimation.Stop();
                    laptopAnimation.Stop();
                    laptopAnimationReversed.Stop();
                    emailAnimationReversed.Stop();
                    gaspAnimation.Stop();
                    hover.Stop();
                    thumbsUp.Stop();
                    tapEffect.Stop();
                    canClick = true;
                    TonyHead.Cursor = Cursors.Hand;
                }
            };
        }


    }

}
