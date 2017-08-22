﻿using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Gu.Wpf.UiAutomation.Shapes;
using Gu.Wpf.UiAutomation.WindowsAPI;

namespace Gu.Wpf.UiAutomation.Overlay
{
    public class OverlayRectangleWindow : Window
    {
        public OverlayRectangleWindow(Rectangle rectangle, Color color, int durationInMs)
        {
            AutomationProperties.SetAutomationId(this, "Gu.Wpf.UiAutomationOverlayWindow");
            AutomationProperties.SetName(this, "Gu.Wpf.UiAutomationOverlayWindow");
            AllowsTransparency = true;
            WindowStyle = WindowStyle.None;
            Topmost = true;
            ShowActivated = false;
            ShowInTaskbar = false;
            Background = Brushes.Transparent;
            Top = rectangle.Top;
            Left = rectangle.Left;
            Width = rectangle.Width;
            Height = rectangle.Height;
            var borderBrush = new SolidColorBrush(color);
            borderBrush.Freeze();
            Content = new Border { BorderThickness = new Thickness(2), BorderBrush = borderBrush };
            StartCloseTimer(TimeSpan.FromMilliseconds(durationInMs));
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            // Make the window click-thru
            SetWindowTransparent();
        }

        private void SetWindowTransparent()
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            var extendedStyle = User32.GetWindowLong(hwnd, WindowLongParam.GWL_EXSTYLE);
            User32.SetWindowLong(hwnd, WindowLongParam.GWL_EXSTYLE, extendedStyle | WindowStyles.WS_EX_TRANSPARENT);
        }

        private void StartCloseTimer(TimeSpan closeTimeout)
        {
            var timer = new DispatcherTimer {Interval = closeTimeout};
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var timer = (DispatcherTimer)sender;
            timer.Tick -= TimerTick;
            timer.Stop();
            Close();
        }
    }
}
