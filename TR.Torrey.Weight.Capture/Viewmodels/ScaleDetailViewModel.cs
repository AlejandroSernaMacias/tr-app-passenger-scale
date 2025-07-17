using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Input;
using TR.Torrey.Weight.Capture.Models;
using TR.Torrey.Weight.Capture.Repositories;
using TR.Torrey.Weight.Capture.Services;
using TR.Torrey.Weight.Capture.Ui;

namespace TR.Torrey.Weight.Capture.Viewmodels
{
    public class ScaleDetailViewModel : BaseViewModel
    {
        IDialogAlert _dialogAlert;
        public ICommand SaveCommand { get; }
        public ICommand ClosePopupCommand { get; }

        // Evento para notificar al control principal
        public event EventHandler<ReturnResponseEventArgs> ReturnResponse;
        public event EventHandler<CloseFormEventArgs> CloseForm;

        public Scale scale{ get; set; }
        #region Text
        private string _txtTxtName = Common.Common.MSG_NAME;
        public string TxtName
        {
            get => _txtTxtName;
            set
            {
                _txtTxtName = value;
                OnPropertyChanged();
            }
        }

        private string _txtName = "";
        public string Name
        {
            get => _txtName;
            set
            {
                _txtName = value;
                OnPropertyChanged();
            }
        }
        private string _txtTxtIp = Common.Common.MSG_IP;
        public string TxtIp
        {
            get => _txtTxtIp;
            set
            {
                _txtTxtIp = value;
                OnPropertyChanged();
            }
        }

        private string _txtIp = "";
        public string Ip
        {
            get => _txtIp;
            set
            {
                _txtIp = value;
                OnPropertyChanged();
            }
        }

        private string _txtTxtMinWeight = Common.Common.MSG_MINWEIGHT;
        public string TxtMinWeight
        {
            get => _txtTxtMinWeight;
            set
            {
                _txtTxtMinWeight = value;
                OnPropertyChanged();
            }
        }

        private string _txtMinWeight = "";
        public string MinWeight
        {
            get => _txtMinWeight;
            set
            {
                _txtMinWeight = value;
                OnPropertyChanged();
            }
        }

        private string _txtTxtMinTime = Common.Common.MSG_MINTIME;
        public string TxtMinTime
        {
            get => _txtTxtMinTime;
            set
            {
                _txtTxtMinTime = value;
                OnPropertyChanged();
            }
        }

        private string _txtMinTime = "";
        public string MinTime
        {
            get => _txtMinTime;
            set
            {
                _txtMinTime = value;
                OnPropertyChanged();
            }
        }

        private string _txtTxtSave = Common.Common.MSG_SAVE;
        public string TxtSave
        {
            get => _txtTxtSave;
            set
            {
                _txtTxtSave = value;
                OnPropertyChanged();
            }
        }

        private string _txtTxtNewScale = Common.Common.MSG_SCALE;
        public string TxtNewScale
        {
            get => _txtTxtNewScale;
            set
            {
                _txtTxtNewScale = value;
                OnPropertyChanged();
            }
        }

        private string _txtTxtStatus = "";
        public string TxtStatus
        {
            get => _txtTxtStatus;
            set
            {
                _txtTxtStatus = value;
                OnPropertyChanged();
            }
        }
        #endregion



        public ScaleDetailViewModel(IDialogAlert dialogAlert, Scale _scale)
        {
            this._dialogAlert = dialogAlert;

            scale = _scale;
            initializeValues();

            SaveCommand = new RelayCommand<object>(Save);
            ClosePopupCommand = new RelayCommand<object>(ClosePopup);

        }

        public void initializeValues()
        {
            try
            {
                var vName       = scale?.vName == null ? "" : scale.vName;
                var vIp         = scale?.vIp == null ? "" : scale.vIp;
                var fMinWeight  = scale?.fMinWeight == null ? "" : scale.fMinWeight;
                var iMinTime    = scale?.iMinTime == null ? Common.Common.ID_ZERO : scale.iMinTime;

                Name = vName;
                Ip = vIp;
                MinWeight = fMinWeight;
                MinTime = iMinTime.ToString();
            }
            catch (Exception ex)
            {
                var e = ex.Message;
            }
        }


        private async void Save(object parameter)
        {
            if (Name == null || Name == "")
            {
                TxtStatus = Common.Common.MSG_ERROR_NAME;
                return;
            }
            if (Ip == null || Ip == "")
            {
                TxtStatus = Common.Common.MSG_ERROR_IP;
                return;
            }
            if (MinWeight == null || MinWeight == "")
            {
                TxtStatus = Common.Common.MSG_ERROR_MINWEIGHT;
                return;
            }
            if (MinTime== null || MinTime == "")
            {
                TxtStatus = Common.Common.MSG_ERROR_MINTIME;
                return;
            }

            Scale scale = new Scale();
            scale.vIp           = Ip;
            scale.vName         = Name;
            scale.fMinWeight    = MinWeight;
            scale.vPort         = "";
            scale.fWeight       = 0.ToString();
            scale.fTotal        = 0.ToString();
            scale.iMinTime      = int.Parse(MinTime);
            scale.iSamples      = 0;
            scale.iStatus       = 0;
            scale.dtLastUpdate  = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var json = await ScaleRepository.save(scale);
            var response = JsonConvert.DeserializeObject<ResponseDataGeneric<string>>(json);

            if (response != null)
            {
                // Notificar al control principal
                ReturnResponse?.Invoke(this, new ReturnResponseEventArgs(response.code, response.message, response.data));
            }
        }
        private async void ClosePopup(object parameter)
        {
            CloseForm?.Invoke(this, new CloseFormEventArgs(true));
        }
    }

    public class ReturnResponseEventArgs : EventArgs
    {
        public int Code { get; }
        public string Message { get; }
        public string Data { get; }

        public ReturnResponseEventArgs(int code, string message, string data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }

    public class CloseFormEventArgs : EventArgs
    {
        public bool IsClose { get; }

        public CloseFormEventArgs(bool isClose)
        {
            IsClose = isClose;
        }
    }
}
