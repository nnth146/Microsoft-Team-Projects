using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MoneyLover.View
{
    public sealed partial class ButtonNavigationView : UserControl
    {
        public ButtonNavigationView()
        {
            this.InitializeComponent();

            _monthlyButtonIsSelected = false;
            _annualButtonIsSelected = false;
        }

        public object MonthlyButtonCommandParameter { get; set; }
        public object AnnualButtonCommandParameter { get; set; } 

        private bool _monthlyButtonIsSelected;
        private bool _annualButtonIsSelected;


        public ICommand MonthlyButtonCommand
        {
            get { return (ICommand)GetValue(MonthlyButtonCommandProperty); }
            set { SetValue(MonthlyButtonCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonthlyButtonCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthlyButtonCommandProperty =
            DependencyProperty.Register("MonthlyButtonCommand", typeof(ICommand), typeof(ButtonNavigationView), new PropertyMetadata(null));



        public ICommand AnnualButtonCommand
        {
            get { return (ICommand)GetValue(AnnualButtonCommandProperty); }
            set { SetValue(AnnualButtonCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnnualButtonCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnnualButtonCommandProperty =
            DependencyProperty.Register("AnnualButtonCommand", typeof(ICommand), typeof(ButtonNavigationView), new PropertyMetadata(0));



        private void MonthlyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_monthlyButtonIsSelected)
            {
                MonthlyButton.Background = ButtonBackgroundPointerOver;
                AnnualButton.Background = ButtonBackground;
                _monthlyButtonIsSelected = true;
                _annualButtonIsSelected = false;
                OnMonthlyButtonIsSelected();
            }
        }

        private void AnnualButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_annualButtonIsSelected)
            {
                MonthlyButton.Background = ButtonBackground;
                AnnualButton.Background = ButtonBackgroundPointerOver;
                _annualButtonIsSelected = true;
                _monthlyButtonIsSelected = false;
                OnAnnualButtonIsSelected();
            }
        }

        private void OnMonthlyButtonIsSelected()
        {
            MonthlyButtonCommand?.Execute(MonthlyButtonCommandParameter);
        }

        private void OnAnnualButtonIsSelected()
        {
            AnnualButtonCommand?.Execute(AnnualButtonCommandParameter);
        }
    }
}
