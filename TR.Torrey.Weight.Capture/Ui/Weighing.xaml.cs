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
using TR.Torrey.Weight.Capture.Services;
using TR.Torrey.Weight.Capture.Viewmodels;

namespace TR.Torrey.Weight.Capture.Ui
{
    /// <summary>
    /// Interaction logic for Weighing.xaml
    /// </summary>
    public partial class Weighing : UserControl
    {
        IDialogAlert _dialogAlert;
        public Weighing(IDialogAlert dialogAlert)
        {
            InitializeComponent();

            this.Loaded += UC_Loaded;
            this.Unloaded += UC_Unloaded;
            this._dialogAlert = dialogAlert;


            HeaderScaleName.Header  = Common.Common.MSG_SCALE;
            HeaderIp.Header         = Common.Common.MSG_IP;
            HeaderMinWeight.Header  = Common.Common.MSG_MINWEIGHT + " (kg)";
            HeaderSamples.Header    = Common.Common.MSG_SAMPLES;
            HeaderWeight.Header     = Common.Common.MSG_WEIGHT + " (kg)";
            HeaderTotal.Header      = Common.Common.MSG_TOTAL + " (kg)";
            HeaderMinTime.Header    = Common.Common.MSG_MINTIME + " (seg)";
            HeaderScaleStatus.Header= Common.Common.MSG_STATUS;
        }
        private void UC_Unloaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as WeighingViewModel;
            //viewModel?.CommunicationDisconectCommand.Execute(null);
        }
        private void UC_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext = new WeighingViewModel(this._dialogAlert);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
    }
}
