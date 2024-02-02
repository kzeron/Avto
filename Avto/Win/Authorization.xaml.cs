﻿using Avto.Win;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Avto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Services services = new Services();
            services.Show();
            this.Close();
        }

        private void ResetPassowrdText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new ResetPassowordWin().Show();
            Close();
        }

        private void RegistrationText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
