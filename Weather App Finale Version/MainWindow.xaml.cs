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
using Newtonsoft.Json.Linq;
using static System.Diagnostics.Debug;

namespace Weather_App
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private async void Btn_suche_ClickAsync(object sender, RoutedEventArgs e)
        {
            string stadt = txt_eingabe.Text;


            ApiAbfrage api = new ApiAbfrage(stadt);
            string responseBody = await api.GetWetterdaten(stadt);

            if (!string.IsNullOrEmpty(responseBody))
            {
                JObject jsonResponse = JObject.Parse(responseBody);

                JArray listArray = (JArray)jsonResponse["list"];
                if (listArray != null && listArray.Count >= 32)
                {
                    // aktuell
                    JObject firstItem = (JObject)listArray[0];
                    JObject mainObject = (JObject)firstItem["main"];
                    JArray weatherArray = (JArray)firstItem["weather"];
                    // Tag 1
                    int jumpCount = Zeitsprünge.GetJumpCount();
                    JObject secondItem = (JObject)listArray[jumpCount];
                    JObject tag1 = (JObject)secondItem["main"];
                    JValue day1 = (JValue)secondItem["dt_txt"];
                    // Tag 2
                    int jumpCounttag2 = jumpCount + 8;
                    JObject thirdItem = (JObject)listArray[jumpCounttag2];
                    JObject tag2 = (JObject)thirdItem["main"];
                    JValue day2 = (JValue)thirdItem["dt_txt"];
                    // Tag 3
                    int jumpCounttag3 = jumpCount + 16;
                    JObject fourthItem = (JObject)listArray[jumpCounttag3];
                    JObject tag3 = (JObject)fourthItem["main"];
                    JValue day3 = (JValue)fourthItem["dt_txt"];

                    if (mainObject != null && weatherArray != null)
                    {
                        // Ort
                        string ort = (string)jsonResponse["city"]["name"];
                        txt_stadt.Content = ort;
                        // Wetterbeschreibung
                        string weatherDescription = (string)weatherArray[0]["description"];
                        txt_wetterlage.Content = weatherDescription;
                        // Wetter Foto
                        string weatherFoto = (string)weatherArray[0]["main"];
                        FotoKlasse imageHelper = new FotoKlasse();
                        string imagePath = imageHelper.SelectImage(weatherFoto);
                        Image_wetter.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                        // Regenwahrscheinlichkeit
                        double popValue = (double)firstItem["pop"];
                        double regenwahrscheinlichkeit = popValue * 100;
                        txt_regen1.Content = "Regen:             " + regenwahrscheinlichkeit.ToString() + "%";
                        // Temeratur aktuell
                        double temperature = (double)mainObject["temp"];
                        int roundedTemperature = (int)Math.Round(temperature);
                        txt_temp.Content = roundedTemperature.ToString() + "°";
                        // Temperatur Max
                        double höchsttemperature = (double)mainObject["temp_max"];
                        int roundedTemperature_h = (int)Math.Round(höchsttemperature);
                        txt_htemp.Content = "H: " + roundedTemperature_h.ToString() + "°";
                        // Temperatur Min
                        double tieftemperature = (double)mainObject["temp_min"];
                        int roundedTemperature_t = (int)Math.Round(tieftemperature);
                        txt_ttemp.Content = "T: " + roundedTemperature_t.ToString() + "°";
                        // Temperatur Tag 1
                        double temperature_tag1 = (double)tag1["temp"];
                        int roundedTemperature_tag1 = (int)Math.Round(temperature_tag1);
                        txt_temp_tag1.Content =  roundedTemperature_tag1.ToString() + "°";
                        DateTime dt1 = DateTime.Parse(day1.Value<string>()); 
                        txt_datum_tag1.Content = dt1.Day + "." + dt1.Month + ".";
                        // Temperatur Tag 2
                        double temperature_tag2 = (double)tag2["temp"];
                        int roundedTemperature_tag2 = (int)Math.Round(temperature_tag2);
                        txt_temp_tag2.Content = roundedTemperature_tag2.ToString() + "°";
                        DateTime dt2 = DateTime.Parse(day2.Value<string>());
                        txt_datum_tag2.Content = dt2.Day + "." + dt2.Month + ".";
                        // Temperatur Tag 3
                        double temperature_tag3 = (double)tag3["temp"];
                        int roundedTemperature_tag3 = (int)Math.Round(temperature_tag3);
                        txt_temp_tag3.Content = roundedTemperature_tag3.ToString() + "°";
                        DateTime dt3 = DateTime.Parse(day3.Value<string>());
                        txt_datum_tag3.Content = dt3.Day + "." + dt3.Month + ".";
                    }
                }
            }
            else
            {
                MessageBox.Show("Fehler bei der Eingabe", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Btn_ende_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}


