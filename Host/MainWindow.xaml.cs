﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ServiceHost UserService = new ServiceHost(typeof(WCF.UserService));
            UserService.Open();

            ServiceHost StoryService = new ServiceHost(typeof(WCF.StoryService));
            StoryService.Open();

            ServiceHost LeafService = new ServiceHost(typeof(WCF.LeafService));
            LeafService.Open();
        }
    }
}
