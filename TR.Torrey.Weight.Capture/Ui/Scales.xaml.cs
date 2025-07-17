using MaterialDesignThemes.Wpf;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using TR.Torrey.Weight.Capture.Services;
using TR.Torrey.Weight.Capture.Viewmodels;

namespace TR.Torrey.Weight.Capture.Ui
{
    /// <summary>
    /// Interaction logic for Scales.xaml
    /// </summary>
    public partial class Scales : UserControl
    {
        IDialogAlert _dialogAlert;
        public Scales(IDialogAlert dialogAlert)
        {
            InitializeComponent();

            this.Loaded += UC_Loaded;
            this.Unloaded += UC_Unloaded;
            this._dialogAlert = dialogAlert;


            hName.Header       = Common.Common.MSG_SCALE;
            hIp.Header         = Common.Common.MSG_IP;
            hMinWeight.Header  = Common.Common.MSG_MINWEIGHT;
            hLastUpdate.Header = Common.Common.MSG_LASTUPDATE;
            hActions.Header    = Common.Common.MSG_ACTIONS;
        }
        private void UC_Unloaded(object sender, RoutedEventArgs e)
        {
        }
        private void UC_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext = new ScalesViewModel(this._dialogAlert);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)MainWindow.GetWindow(this);
            mainWindow.GoScaleDetail();
        }

        private void dgScales_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Models.Scale? model = ((System.Windows.Controls.Button)sender).DataContext as Models.Scale;

                if (model != null)
                {
                    var viewModel = DataContext as ScalesViewModel;
                    viewModel?.Delete(model);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Models.Scale? model = ((System.Windows.Controls.Button)sender).DataContext as Models.Scale;

                if (model != null)
                {
                    var viewModel = DataContext as ScalesViewModel;
                    viewModel?.Edit(model);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void only_characters(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Verificar si el carácter ingresado es alfanumérico (letra o número)
            if (!Regex.IsMatch(e.Text, @"^[a-zA-Z0-9]$"))
            {
                // Si no es alfanumérico, bloqueamos la entrada
                e.Handled = true;
            }
        }

        private void only_weight(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Obtener el texto actual en el TextBox
            var currentText = (sender as TextBox).Text;

            // Definir una expresión regular que permita números con hasta 2 decimales
            // Permite números enteros y números con hasta dos decimales (Ej: 123, 123.45)
            string pattern = @"^(\d+(\.\d{0,2})?)?$";

            // Concatenar el texto actual con el nuevo carácter ingresado
            string newText = currentText + e.Text;

            // Comprobar si el nuevo texto cumple con el formato de número entero o decimal con máximo 2 decimales
            if (!Regex.IsMatch(newText, pattern))
            {
                e.Handled = true; // Si no es válido, bloquear el carácter ingresado
            }
        }
    }
}
