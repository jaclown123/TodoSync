﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using TodoSynchronizer.Services;
using TodoSynchronizer.Views;

namespace TodoSynchronizer.UnitTest
{
    /// <summary>
    /// CanvasTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CanvasTestWindow : Window, INotifyPropertyChanged
    {
        public CanvasTestWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                this.RaisePropertyChanged("Message");
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        private string userEmail;
        public string UserEmail
        {
            get { return userEmail; }
            set
            {
                userEmail = value;
                this.RaisePropertyChanged("UserEmail");
            }
        }

        private IEnumerable items;
        public IEnumerable Items
        {
            get { return items; }
            set
            {
                items = value;
                this.RaisePropertyChanged("Items");
            }
        }

        private BitmapSource userAvatar;
        public BitmapSource UserAvatar
        {
            get { return userAvatar; }
            set
            {
                userAvatar = value;
                this.RaisePropertyChanged("UserAvatar");
            }
        }


        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var res1 = CanvasService.TryCacheLogin();
            if (res1.success)
            {
                Message = "登录成功";
                Success();
                return;
            }
            var m = new CanvasLoginWindow();
            var res2 = m.ShowDialog();
            if (res2.Value == true)
            {
                Message = "登录成功";
                Success();
                return;
            }
            else
            {
                Message = "登录失败";
                return;
            }
        }

        private void Success()
        {
            UserName = CanvasService.User.Name;
            UserEmail = CanvasService.User.PrimaryEmail;
            
            BitmapImage bitImage = new BitmapImage();
            bitImage.BeginInit();
            bitImage.UriSource = new Uri(CanvasService.User.AvatarUrl, UriKind.Absolute);
            bitImage.EndInit();
            UserAvatar = bitImage;
        }

        private void ButtonListCourses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonListAssignments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonListAnouncements_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonListQuizzes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonListDiscussions_Click(object sender, RoutedEventArgs e)
        {

        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }


        #endregion
    }
}
