﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Audio_Player
{

    public partial class MainWindow : Window
    {
        private void PlayList_Click(object sender, RoutedEventArgs e)
        {
            SetVisibleMain();
            OpacityAnim(PlayGrid, sender);
        }

        private void AddToFolder_Click(object sender, RoutedEventArgs e)
        {
            SetVisibleFolderAdder();
            RideAnim(AddFolder, sender);
        }

        private void OpacityAnim(Grid elem, object sender)
        {
            DoubleAnimation Anim = new DoubleAnimation();
            (sender as Button).IsHitTestVisible = false; //отключаем кнопку переключение на время анимации
            Anim.Completed += delegate
            {
                (sender as Button).IsHitTestVisible = true; //включаем кнопку
            };
            Anim.From = 0;
            Anim.To = 1;
            Anim.Duration = new Duration(TimeSpan.FromSeconds(1));
            elem.BeginAnimation(OpacityProperty, Anim);
        }

        private void RideAnim(Grid elem, object sender)
        {
            ThicknessAnimation Anim = new ThicknessAnimation();
            (sender as Button).IsHitTestVisible = false;
            Anim.Completed += delegate
            {
                (sender as Button).IsHitTestVisible = true;
            };
            Anim.From = new Thickness(-400, 200, 0, 0);
            Anim.To = elem.Margin;
            Anim.Duration = new Duration(TimeSpan.FromSeconds(1));
            elem.BeginAnimation(MarginProperty, Anim);
        }

    }
    
}