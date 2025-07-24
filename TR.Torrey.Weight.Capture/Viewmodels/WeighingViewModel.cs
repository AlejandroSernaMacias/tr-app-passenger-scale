using AP.Data.Transfer.Controllers;
using AP.Data.Transfer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Torrey.Weight.Capture.Models;
using TR.Torrey.Weight.Capture.Repositories;
using TR.Torrey.Weight.Capture.Services;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Input;
using System.Collections.Concurrent;
using System.Windows.Forms;
using System.IO;
using System.Windows.Shapes;

namespace TR.Torrey.Weight.Capture.Viewmodels
{
    public class WeighingViewModel : BaseViewModel
    {
        IDialogAlert _dialogAlert;
        public ICommand CommunicationDisconectCommand { get; }
        public ICommand ReportCommand { get; }

        private static ConcurrentDictionary<string, Socket> sockets = new ConcurrentDictionary<string, Socket>();
        private static ConcurrentDictionary<string, CancellationTokenSource> cancellationTokens = new ConcurrentDictionary<string, CancellationTokenSource>();
        private static ConcurrentDictionary<string, float> maximosPesos = new ConcurrentDictionary<string, float>();
        public Dictionary<string, int> dictionaryWeighings = new Dictionary<string, int>();
        public Dictionary<string, float> dictionaryTotalWeighings = new Dictionary<string, float>();
        public Dictionary<string, IPEndPoint> dictionaryScales = new Dictionary<string, IPEndPoint>();

        public static string pathFile = "datos_maximo.csv";

        public APSocketController socketController;

        public APSocket serverSocket { get; set; }

        public Task<List<Models.Scale>> allScales { get; set; }
        public ObservableCollection<Models.Scale>? _scales { get; set; }
        private ObservableCollection<Models.Scale> _filteredScales;
        public string _scalesFound { get; set; }
        public bool readScale = true;


        #region TEXT VALUES
        private int _onlineCount;
        public int OnlineCount
        {
            get => _onlineCount;
            set
            {
                _onlineCount = value;
                OnPropertyChanged(nameof(OnlineCount));
            }
        }

        private int _offlineCount;
        public int OfflineCount
        {
            get => _offlineCount;
            set
            {
                _offlineCount = value;
                OnPropertyChanged(nameof(OfflineCount));
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
        public string ScalesFound
        {
            get => _scalesFound;
            set
            {
                _scalesFound = value;
                OnPropertyChanged(nameof(ScalesFound));
            }
        }
        public ObservableCollection<Models.Scale> Scales
        {
            get => _filteredScales;
            private set
            {
                _filteredScales = value;
                OnPropertyChanged(nameof(Scales));
            }
        }
        private string _weight;
        public string Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private string _txtTxtReport = Common.Common.MSG_CREATE_REPORT;
        public string TxtReport
        {
            get => _txtTxtReport;
            set
            {
                _txtTxtReport = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public WeighingViewModel(IDialogAlert dialogAlert)
        {
            ReportCommand = new RelayCommand<int>(Report);
            CommunicationDisconectCommand = new RelayCommand<int>(CommunicationDisconect);

            this._dialogAlert = dialogAlert;

            loadListScales();
            initFile();

            if (allScales?.Result.Count > 0)
                readScales();
            else
                ShowAlert(Common.Common.MSG_SCALE_NOT_FOUND);
        }


        public void loadListScales()
        {
            allScales = GetAll();
            _scales = new ObservableCollection<Models.Scale>(allScales.Result.ToList());

            var filter1 = _scales.Where(i => i.vIp != null && i.vName != null).ToList();
            _filteredScales = new ObservableCollection<Models.Scale>(filter1.Take(200));
            ScalesFound = MessageFound(_filteredScales.Count, allScales.Result.Count);

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

        #region REPORT
        public async void initFile()
        {
            try
            {
                if (File.Exists(pathFile))
                {
                    try
                    {
                        File.Delete(pathFile);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                using (StreamWriter escritor = new StreamWriter(pathFile, true, Encoding.UTF8)) // Append to file
                {
                    escritor.WriteLine("" + Common.Common.MSG_SCALE + "," + Common.Common.MSG_IP + "," + Common.Common.MSG_WEIGHT + "," + Common.Common.MSG_DATE + "");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el peso máximo: {ex.Message}");
            }
        }
        public async void finishFile()
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(pathFile, true, Encoding.UTF8)) // Append to file
                {
                    escritor.WriteLine(",,");
                    escritor.WriteLine(",,");
                    escritor.WriteLine(",,");
                    escritor.WriteLine(",,");
                    escritor.WriteLine(",,");

                    escritor.WriteLine("" + Common.Common.MSG_SCALE + "," + Common.Common.MSG_IP + "," + Common.Common.MSG_SAMPLES + "," + Common.Common.MSG_TOTAL + "," + Common.Common.MSG_DATE + "");

                    foreach (var scale in dictionaryScales)
                    {
                        var scaleValues = _scales?.FirstOrDefault(b => b.vName == scale.Key);

                        var iSamples = dictionaryWeighings[scale.Key];
                        var fTotal = dictionaryTotalWeighings[scale.Key];

                        escritor.WriteLine(scale.Key + "," + scaleValues?.vIp + "," + iSamples + "," + fTotal + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el peso máximo: {ex.Message}");
            }
        }
        public void GuardaPesos(string nombreBascula, float pesoMaximo)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(pathFile, true, Encoding.UTF8)) // Append to file
                {
                    var scaleValues = _scales?.FirstOrDefault(b => b.vName == nombreBascula);

                    float pesoMaximo_temp = (float)Math.Round(float.Parse(pesoMaximo.ToString()), 2);

                    escritor.WriteLine($"{nombreBascula},{scaleValues?.vIp},{pesoMaximo_temp},{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                }

            }
            catch (Exception ex)
            {
                ShowAlert(Common.Common.MSG_ERROR_SAVE_WEIGHT + " " + ex.Message);
            }
        }

        public void Report(int status)
        {
            CommunicationDisconect(0);
            resetScales();
            finishFile();

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = @"C:\";
            saveDialog.Title = Common.Common.MSG_REPORT;
            saveDialog.Filter = "CSV files (*.csv)|*.csv|Excel Files|*.xls;*.xlsx";

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var path = System.IO.Path.GetFullPath(saveDialog.FileName);

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                try
                {
                    if (File.Exists(pathFile))
                    {
                        if (File.Exists(pathFile))
                            File.Copy(pathFile, path, true);
                        else
                            File.Copy(pathFile, path);
                    }

                    ShowAlert(Common.Common.MSG_REPORT_SAVED + path);

                    if (allScales?.Result.Count > 0)
                    {
                        readScale = true;
                        readScales();
                    }
                }
                catch (Exception ex)
                {
                    ShowAlert(Common.Common.MSG_ERROR_CREATE_REPORT + " " + ex.Message);
                }

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
            }
        }

        #endregion
        public async void readScales()
        {
            dictionaryScales.Clear();
            foreach (var sc in _scales.Take(200))
                dictionaryScales[sc.vName] = new IPEndPoint(IPAddress.Parse(sc.vIp), Common.Common.SCALE_PORT);

            readScale = true;

            var throttler = new SemaphoreSlim(20); // max 20 concurrent reads

            while (readScale)
            {
                var start = DateTime.Now;

                var tasks = dictionaryScales.Select(async kvp =>
                {
                    await throttler.WaitAsync();
                    try { await LeerPesoDeBasculaAsync(kvp.Key, kvp.Value); }
                    finally { throttler.Release(); }
                });

                await Task.WhenAll(tasks);

                _ = App.Current.Dispatcher.InvokeAsync(() =>
                {
                    OnlineCount = _scales.Count(s => s.iStatus == 1);
                    OfflineCount = _scales.Count(s => s.iStatus == 0);
                });

                var elapsed = (DateTime.Now - start).TotalMilliseconds;
                var delay = Math.Max(0, 333 - elapsed);
                await Task.Delay((int)delay);
            }
        }

        public void CommunicationDisconect(int status)
        {
            readScale = false;
            foreach (var s in sockets.Values)
            {
                try { s.Shutdown(SocketShutdown.Both); s.Close(); } catch { }
            }
            sockets.Clear();
        }

        public void resetScales()
        {
            foreach (var scale in dictionaryScales)
            {
                var scaleValues = _scales?.FirstOrDefault(b => b.vName == scale.Key);
                scaleValues.iSamples = 0;
                scaleValues.fTotal = "0";
            }
        }

        public async Task<Dictionary<string, string>> LeerPesosDeBasculasAsync(Dictionary<string, IPEndPoint> basculas)
        {
            Dictionary<string, string> resultados = new Dictionary<string, string>();

            foreach (var bascula in basculas)
            {
                string nombreBascula = bascula.Key;
                IPEndPoint endpoint = bascula.Value;
                string peso = await LeerPesoDeBasculaAsync(nombreBascula, endpoint);

                resultados[nombreBascula] = peso;
            }

            return resultados;
        }
        public async Task<string> LeerPesoDeBasculaAsync(string nombreBascula, IPEndPoint endpoint)
        {
            string peso = null;

            try
            {
                Socket socket;

                // Reutilizar socket existente
                if (!sockets.TryGetValue(nombreBascula, out socket) || !socket.Connected)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {
                        NoDelay = true // Desactivar Nagle para respuesta inmediata
                    };

                    await socket.ConnectAsync(endpoint);
                    sockets[nombreBascula] = socket;
                }

                // Enviar comando "P"
                byte[] comando = Encoding.ASCII.GetBytes("P");
                await socket.SendAsync(comando, SocketFlags.None);

                // Leer respuesta
                byte[] buffer = new byte[1024];
                socket.ReceiveTimeout = 1000; // 1 segundo de timeout
                int bytesRead = await socket.ReceiveAsync(buffer, SocketFlags.None);

                peso = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim('\r', '\n');

                string pesoNet = peso.TrimStart().Split(' ')[0];

                var scale = _scales?.FirstOrDefault(b => b.vName == nombreBascula);
                if (scale != null)
                {
                    float minWeight = (float)Math.Round(float.Parse(scale.fMinWeight), 2);
                    scale.iStatus = 1;
                    scale.fWeight = peso;

                    if (float.TryParse(pesoNet, out float pesoNumerico))
                    {
                        float pesoRedondeado = (float)Math.Round(pesoNumerico, 2);
                        //// revisar pesoMaxAnterior
                        if (pesoRedondeado <= minWeight && maximosPesos.TryGetValue(nombreBascula, out float pesoMaxAnterior) && pesoMaxAnterior > minWeight)
                        {
                            GuardaPesos(nombreBascula, pesoMaxAnterior);
                            dictionaryWeighings[nombreBascula]++;
                            dictionaryTotalWeighings[nombreBascula] = (float)Math.Round(dictionaryTotalWeighings[nombreBascula] + pesoMaxAnterior, 2);

                            scale.iSamples = dictionaryWeighings[nombreBascula];
                            scale.fTotal = dictionaryTotalWeighings[nombreBascula].ToString();
                            maximosPesos[nombreBascula] = 0;
                        }
                        else
                        {
                            maximosPesos.AddOrUpdate(nombreBascula, pesoRedondeado, (key, oldVal) => Math.Max(oldVal, pesoRedondeado));
                        }
                    }
                }
            }
            catch (SocketException)
            {
                var scale = _scales?.FirstOrDefault(b => b.vName == nombreBascula);
                if (scale != null) scale.iStatus = 0;

                // Cerrar y remover socket dañado
                if (sockets.TryRemove(nombreBascula, out var socket))
                {
                    try { socket.Close(); } catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error leyendo báscula {nombreBascula}: {ex.Message}");
            }

            return peso;
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