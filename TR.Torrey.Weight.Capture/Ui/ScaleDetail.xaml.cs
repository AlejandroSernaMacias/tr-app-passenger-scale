using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using TR.Torrey.Weight.Capture.Services;
using TR.Torrey.Weight.Capture.Viewmodels;

namespace TR.Torrey.Weight.Capture.Ui
{
    /// <summary>
    /// Interaction logic for ScaleDetail.xaml
    /// </summary>
    public partial class ScaleDetail : UserControl
    {
        public ScaleDetail()
        {
            InitializeComponent();
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

        private void only_ip(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            string ipPattern = @"^(\d{0,3})(\.)(\d{0,3})(\.)(\d{0,3})(\.)(\d{0,3})$";

            // Permitir solo números, puntos, y asegurarnos de no exceder 255 en cada octeto
            if (!Regex.IsMatch(e.Text, @"^\d$") && e.Text != ".")
            {
                e.Handled = true; // Bloquear caracteres no permitidos
                return;
            }

            // Obtener el texto actual del TextBox
            var currentText = (sender as TextBox).Text;

            // Verificar si el punto se está colocando en un lugar incorrecto o si se excede el límite 255
            if (e.Text == "." && (currentText.Split('.').Length > 3 || currentText.Length == 0 || currentText.EndsWith(".")))
            {
                e.Handled = true; // No permitir puntos en lugares incorrectos
            }

            // Verificar que cada número no exceda 255
            if (Regex.IsMatch(currentText + e.Text, ipPattern))
            {
                string[] segments = currentText.Split('.');
                if (segments.Length == 4)
                {
                    foreach (var segment in segments)
                    {
                        if (int.TryParse(segment, out int num) && (num > 255 || num < 0))
                        {
                            e.Handled = true; // Bloquear valores fuera del rango 0-255
                        }
                    }
                }
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

        private void only_number(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Verificar si el carácter ingresado es alfanumérico (letra o número)
            if (!Regex.IsMatch(e.Text, @"^[0-9]$"))
            {
                // Si no es alfanumérico, bloqueamos la entrada
                e.Handled = true;
            }
        }
    }
}
