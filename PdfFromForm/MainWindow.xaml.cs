using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PdfFromForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Border> bordersList = new List<Border>();

        public MainWindow()
        {
            InitializeComponent();

            // Store the borders (forms) into the List
            foreach (var control in mainGrid.Children)
            {
                if (control.GetType() == typeof(Border))
                {
                    Border brd = (Border)control;
                    bordersList.Add(brd);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int indexBorderSlideOut = -1;
            int indexBorderSlideIn = -1;

            // Find out which menu is clicked
            Button btnClickedMenu = (Button)sender;
            StackPanel stackPanel = (StackPanel)btnClickedMenu.Parent;
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                if (sender.Equals(stackPanel.Children[i]))
                {
                    indexBorderSlideIn = i;
                }
            }

            // Find out which border (form) is active
            for (int i = 0; i < bordersList.Count; i++)
            {
                if (bordersList[i].Height != 0)
                {
                    indexBorderSlideOut = i;
                }
            }


            if (indexBorderSlideIn < 0 || indexBorderSlideIn > bordersList.Count - 1 || indexBorderSlideOut < 0 || indexBorderSlideOut > bordersList.Count - 1)
            {
                MessageBox.Show("Something went wrong !");
                return;
            }


            if (!sender.Equals(stackPanel.Children[indexBorderSlideOut]))
            {
                CloseFormPage(indexBorderSlideOut);
            }

            if (0 <= indexBorderSlideIn && indexBorderSlideIn < bordersList.Count)
            {
                OpenFormPage(indexBorderSlideIn);
            }

        }

        /// <summary>
        /// Open the page with specified index.
        /// </summary>
        /// <param name="indexBorderSlideIn"></param>
        private void OpenFormPage(int indexBorderSlideIn)
        {
            Border borderSlideIn = bordersList[indexBorderSlideIn];
            if (borderSlideIn.ActualHeight == 0 + borderSlideIn.Padding.Top + borderSlideIn.Padding.Bottom)
            {
                DoubleAnimation dbIn = new DoubleAnimation();
                dbIn.From = 0;
                dbIn.To = mainGrid.ActualHeight;
                dbIn.Duration = TimeSpan.FromSeconds(0.5);
                dbIn.BeginTime = TimeSpan.FromSeconds(0.5);
                borderSlideIn.BeginAnimation(Border.HeightProperty, dbIn);
            }
        }

        /// <summary>
        /// Close the page with specified index.
        /// </summary>
        /// <param name="indexBorderSlideOut"></param>
        private void CloseFormPage(int indexBorderSlideOut)
        {
            Border borderSlideOut;
            if (0 <= indexBorderSlideOut && indexBorderSlideOut < bordersList.Count)
            {
                borderSlideOut = bordersList[indexBorderSlideOut];
                if (borderSlideOut.ActualHeight != 0)
                {
                    DoubleAnimation dbOut = new DoubleAnimation();
                    dbOut.From = mainGrid.ActualHeight;
                    dbOut.To = 0;
                    dbOut.Duration = TimeSpan.FromSeconds(0.5);
                    dbOut.BeginTime = TimeSpan.FromSeconds(0);
                    borderSlideOut.BeginAnimation(Border.HeightProperty, dbOut);
                }
            }
        }
    }
}
