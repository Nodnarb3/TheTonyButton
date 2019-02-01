﻿using System;
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
        public MainWindow()
        {
            bool canClick = true;

            InitializeComponent();

            Storyboard jugglingAnimation = (Storyboard)Resources["Juggling"];
            Storyboard moveToTopAnimation = (Storyboard)Resources["MoveToTop"];
            Storyboard hover = (Storyboard)Resources["Hover"];

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
                    jugglingAnimation.Stop();
                    moveToTopAnimation.Begin();
                }
            };

            moveToTopAnimation.Completed += (s, e) =>
            {
                hover.Begin();
            };

            KeyUp += (s, e) =>
            {

                if (e.Key == Key.Up)
                {
                    jugglingAnimation.Begin();
                    moveToTopAnimation.Stop();
                    canClick = true;
                }
            };
        }


    }

}
