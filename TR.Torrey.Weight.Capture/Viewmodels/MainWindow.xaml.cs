using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System.Windows;
using TR.Torrey.Weight.Capture.Models;
using TR.Torrey.Weight.Capture.Repositories;
using TR.Torrey.Weight.Capture.Ui;
using TR.Torrey.Weight.Capture.Services;
using System.Windows.Forms;
using System;
using System.Net;
using System.Linq;
using System.IO;
using TR.Torrey.Weigh.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TR.Torrey.Weight.Capture.Viewmodels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDialogAlert
    {
        Ui.Scales scales;
        Ui.ScaleDetail scaleDetail;
        Ui.Weighing weighing;
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += Main_Loaded;
            this.Unloaded += Main_Unloaded;

            scales = new Ui.Scales(this);
            weighing = new Ui.Weighing(this);

            txtbtnCloseMessage.Text = Common.Common.MSG_CLOSE;
            btnCloseMessage.ToolTip = Common.Common.MSG_CLOSE;
            SoftwareVersion.Text    = Common.Common.MSG_VERSION;
        }
        #region Loaded

        private void Main_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GoScaleList();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
        #endregion

        public void GoScaleList()
        {
            ContentMenu.Content = scales;
        }
        public void GoScaleDetail()
        {
            ContentMenu.Content = scaleDetail;
        }
        public void GoWeighing()
        {
            ContentMenu.Content = weighing;
        }

        private void Scales_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GoScaleList();
        }
        private void ScalesWeighing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GoWeighing();
        }

        private void btnCloseMessage_Click(object sender, RoutedEventArgs e)
        {
            dgContent.IsOpen = false;
        }
        public void showMessage(string message)
        {
            msgError.Text = message;
            dgError.Visibility = Visibility.Visible;
            dgContent.ShowDialog(dgContent.DialogContent);
        }

        public void showSimpleDialogAlert(string message)
        {
            showMessage(message);
        }
        public void showScaleList()
        {
            GoScaleList();
        }

    }
}
