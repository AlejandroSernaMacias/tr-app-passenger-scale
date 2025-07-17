using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Xml.Linq;
using TR.Torrey.Weight.Capture.Models;
using TR.Torrey.Weight.Capture.Repositories;
using TR.Torrey.Weight.Capture.Services;
using System.Windows;
using TR.Torrey.Weight.Capture.Ui;

namespace TR.Torrey.Weight.Capture.Viewmodels
{
    public class ScalesViewModel : BaseViewModel
    {
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand NewCommand { get; }


        IDialogAlert _dialogAlert;

        public Scale _scale { get; set; }

        public Task<List<Models.Scale>> allScales { get; set; }
        public ObservableCollection<Models.Scale>? _scales { get; set; }
        private ObservableCollection<Models.Scale> _filteredScales;
        public ObservableCollection<Models.Scale> Scales
        {
            get => _filteredScales;
            private set
            {
                _filteredScales = value;
                OnPropertyChanged(nameof(Scales));
            }
        }

        #region TEXT
        public string _scalesFound { get; set; }

        private string _txtTxtSeach = Common.Common.MSG_SEARCH;
        public string TxtSeach
        {
            get => _txtTxtSeach;
            set
            {
                _txtTxtSeach = value;
                OnPropertyChanged();
            }
        }
        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
                ApplyFilter();
            }
        }

        private string _txtTxtNew = Common.Common.MSG_SCALE_ADD;
        public string TxtNew
        {
            get => _txtTxtNew;
            set
            {
                _txtTxtNew = value;
                OnPropertyChanged();
            }
        }
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

        public string ScalesFound
        {
            get => _scalesFound;
            set
            {
                _scalesFound = value;
                OnPropertyChanged(nameof(ScalesFound));
            }
        }


        private string _txtTxtEdit = Common.Common.MSG_EDIT;
        public string TxtEdit
        {
            get => _txtTxtEdit;
            set
            {
                _txtTxtEdit = value;
                OnPropertyChanged();
            }
        }
        private string _txtTxtDelete = Common.Common.MSG_DELETE;
        public string TxtDelete
        {
            get => _txtTxtDelete;
            set
            {
                _txtTxtDelete = value;
                OnPropertyChanged();
            }
        }

        #endregion


        public ScalesViewModel(IDialogAlert dialogAlert)
        {
            this._dialogAlert = dialogAlert;

            refresh();

            EditCommand     = new RelayCommand<Models.Scale>(Edit);
            DeleteCommand   = new RelayCommand<Models.Scale>(Delete);
            NewCommand = new RelayCommand<object>(New);
        }
        #region SEARCH
        public void refresh()
        {
            allScales       = GetAll();
            _scales         = new ObservableCollection<Models.Scale>(allScales.Result.ToList());

            var filter1     = _scales.Where(i => i.vIp != null && i.vName != null).ToList();
            _filteredScales = new ObservableCollection<Models.Scale>(filter1.Take(200));
            ScalesFound     = MessageFound(_filteredScales.Count, allScales.Result.Count);

            FilterText = string.Empty;
        }
        private static async Task<List<Models.Scale>> GetAll()
        {
            var json = await ScaleRepository.scales();
            var response = JsonConvert.DeserializeObject<ResponseDataGeneric<List<Models.Scale>>>(json);

            if (response?.code == Common.Common.CODE_SUCCESS)
            {
                return response.data;
            }
            return new List<Models.Scale>();
        }
        #endregion


        public async void Delete(Models.Scale scale)
        {
            var json = await ScaleRepository.delete(scale);
            var response = JsonConvert.DeserializeObject<Response>(json);
            
            ShowAlert(response.message);

            refresh();
        }

        public async void Edit(Models.Scale scale)
        {
            if (scale.vIp == null || scale.vIp == "")
            {
                ShowAlert(Common.Common.MSG_ERROR_IP);
                return;
            }
            if (scale.vName == null || scale.vName == "")
            {
                ShowAlert(Common.Common.MSG_ERROR_NAME);
                return;
            }
            if (scale.fMinWeight == null || scale.fMinWeight == "")
            {
                ShowAlert(Common.Common.MSG_ERROR_MINWEIGHT);
                return;
            }

            _scale = scale;

            showForm();
        }
        private void New(object parameter)
        {
            Models.Scale scale = new Models.Scale();

            scale.vPort = Common.Common.SCALE_PORT.ToString();
            scale.vName = string.Empty;
            scale.fMinWeight = string.Empty;
            scale.fWeight = string.Empty;
            scale.fTotal = string.Empty;
            scale.iMinTime = Common.Common.ID_ZERO;
            scale.iSamples = Common.Common.ID_ZERO;
            scale.iStatus = Common.Common.ID_ZERO;
            scale.dtLastUpdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            _scale = scale;

            showForm();
        }

        private Popup _AddFormPopup;
        public void showForm()
        {
            try
            {
                var formulario          = new ScaleDetail();
                var formularioViewModel = new ScaleDetailViewModel(this._dialogAlert, _scale);
                formulario.DataContext  = formularioViewModel;

                // Suscribirse al evento UsuarioCreado
                formularioViewModel.ReturnResponse += FormularioViewModel_ReturnResponse;
                formularioViewModel.CloseForm += FormularioViewModel_ClosePopup;

                _AddFormPopup = new Popup
                {
                    Child = formulario,
                    PlacementTarget = Application.Current.MainWindow, // Centrar en la ventana principal
                    Placement = PlacementMode.Center,
                    IsOpen = true,
                    StaysOpen = true
                };
            }
            catch (Exception ex)
            {
                var e = ex.Message;
            }
        }


        private void FormularioViewModel_ClosePopup(object sender, CloseFormEventArgs e)
        {
            if (e.IsClose)
            {
                if (_AddFormPopup != null && _AddFormPopup.IsOpen)
                {
                    _AddFormPopup.IsOpen = false;
                    _AddFormPopup = null;
                }
            }
        }
        private async void FormularioViewModel_ReturnResponse(object sender, ReturnResponseEventArgs e)
        {
            if (_AddFormPopup != null && _AddFormPopup.IsOpen && e.Code == Common.Common.CODE_SUCCESS)
            {
                _AddFormPopup.IsOpen = false;
                _AddFormPopup = null;
            }

            //ShowAlert(e.Code, e.Message, e.Data);

            refresh();
        }


        private void ApplyFilter()
        {
            try
            {
                if (_scales == null) return;

                if (string.IsNullOrEmpty(_filterText))
                {
                    Scales = new ObservableCollection<Models.Scale>(_scales.Take(200));
                }
                else
                {
                    var filter1 = _scales.Where(i => i.vIp != null && i.vName != null).ToList();
                    var filtered = filter1.Where(i => i.vIp.Contains(_filterText) || i.vName.Contains(_filterText)).ToList();
                    Scales = new ObservableCollection<Models.Scale>(filtered);
                }

                ScalesFound = MessageFound(Scales.Count, allScales.Result.Count);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }
        
        private string MessageFound(int scalesFound, int scales)
        {
            string message = Common.Common.MSG_SHOWING_ITEM + " " + scalesFound + " " + Common.Common.MSG_OF_ITEM + " " + scales;
            return message;
        }

        private void showScaleList()
        {
            this._dialogAlert.showScaleList();
        }
        private void ShowAlert(string message)
        {
            this._dialogAlert.showSimpleDialogAlert(message);
        }
    }
}
