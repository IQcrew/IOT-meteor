using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Globalization;

namespace WindowsAPP
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "92Avq34xTQN38jJarUvcfrj7mzpHOzXj6HenJSOd",
            BasePath = "https://iot-meteorologicka-stanica-default-rtdb.europe-west1.firebasedatabase.app"
        };
        private IFirebaseClient client;
        CultureInfo culture = CultureInfo.InvariantCulture;
        DispatcherTimer dispatcherTimer;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            TemperatureName = temperatureName;
            HumidityName = humidityName;
            PressureName = pressureName;
            LightLevelName = lightLevelName;
            ButtonText = buttonText;

            try
            {
                client = new FireSharp.FirebaseClient(config);
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(Timer_Elapsed);
                dispatcherTimer.Start();
            }
            catch (Exception ex) { }

        }


        string temperatureName = "Teplota";
        string humidityName = "Vlhkosť";
        string pressureName = "Tlak";
        string lightLevelName = "Úroveň svetla";
        string saveName = "Uložiť";
        string latestSaveName = "Posledné uloženie";
        string latestUpdateName = "Posledná aktualizácia";
        string buttonText = "Uložiť aktuálne hodnoty";

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            FirebaseResponse response = client.Get("RealTime");
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());

            Temperature = $"{data["Temperature"]}";
            Humidity = $"{data["Humidity"]}";
            Pressure = $"{data["Pressure"]}";
            LightLevel = $"{data["LightLevel"]}";

            response = client.Get("Save");
            Dictionary<string, string> data2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());

            SavedTime = $"{latestSaveName}: {data2["Time"]}";
            savedVals = $"{saveName}:\n{temperatureName}: {data2["Temperature"]} °C\n{humidityName}: {data2["Humidity"]}%\n{pressureName}: {data2["Pressure"]} hPa\n{lightLevelName}: {data2["LightLevel"]} lux";


            Temperature_Dif = Math.Round(float.Parse(data["Temperature"], culture) - float.Parse(data2["Temperature"], culture), 2);
            Humidity_Dif = Math.Round(float.Parse(data["Humidity"], culture) - float.Parse(data2["Humidity"], culture), 2);
            Pressure_Dif = Math.Round(float.Parse(data["Pressure"], culture) - float.Parse(data2["Pressure"], culture), 2);
            LightLevel_Dif = Math.Round(float.Parse(data["LightLevel"], culture) - float.Parse(data2["LightLevel"], culture), 2);
        }





        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FirebaseResponse response = client.Get("RealTime");
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());

            client.Set("Save", data);

            client.Set("Save/Time", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void languageEnglish_Click(object sender, RoutedEventArgs e)
        {
            temperatureName = "Temperature";
            humidityName = "Humidity";
            pressureName = "Pressure";
            lightLevelName = "Light Level";
            saveName = "Save";
            latestSaveName = "Latest Save";
            buttonText = "Save current values";
            latestUpdateName = "Latest update";

            TemperatureName = temperatureName;
            HumidityName = humidityName;
            PressureName = pressureName;
            LightLevelName = lightLevelName;
            ButtonText = buttonText;

            Timer_Elapsed(null, null);
        }

        private void languageSlovak_Click(object sender, RoutedEventArgs e)
        {

            temperatureName = "Teplota";
            humidityName = "Vlhkosť";
            pressureName = "Tlak";
            lightLevelName = "Úroveň svetla";
            saveName = "Uložené";
            latestSaveName = "Najnovšie uložené";
            buttonText = "Uložiť aktuálne hodnoty";
            latestUpdateName = "Posledný update";

            TemperatureName = temperatureName;
            HumidityName = humidityName;
            PressureName = pressureName;
            LightLevelName = lightLevelName;
            ButtonText = buttonText;

            Timer_Elapsed(null, null);
        }

        #region poperties


        private double temperature;
        public string Temperature
        {
            get { return $"{Math.Round(temperature, 2)}°C"; }
            set
            {

                temperature = double.Parse(value, culture);
                OnPropertyChanged("Temperature");

            }
        }

        private int humidity;
        public string Humidity
        {
            get { return $"{humidity}%"; }
            set
            {
                int hum;
                if (int.TryParse(value, out hum))
                {
                    humidity = hum;
                    OnPropertyChanged("Humidity");
                }
            }
        }

        private double pressure;
        public string Pressure
        {
            get { return $"{Math.Round(pressure, 2)} hPa"; }
            set
            {

                pressure = double.Parse(value, culture);
                OnPropertyChanged("Pressure");

            }
        }

        private int lightLevel;
        public string LightLevel
        {
            get { return $"{lightLevel} Lux"; }
            set
            {
                int light;
                if (int.TryParse(value, out light))
                {
                    lightLevel = light;
                    OnPropertyChanged("LightLevel");
                }
            }
        }

        private string currentTime;
        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = $"{latestUpdateName}: " + value;
                OnPropertyChanged("CurrentTime");
            }
        }

        private string _savedTime;
        public string SavedTime
        {
            get { return _savedTime; }
            set
            {
                _savedTime = value;
                OnPropertyChanged("SavedTime");
            }
        }

        private string _savedVals;
        public string savedVals
        {
            get { return _savedVals; }
            set
            {
                _savedVals = value;
                OnPropertyChanged("savedVals");
            }
        }

        private double _temperature_Dif;
        public double Temperature_Dif
        {
            get { return _temperature_Dif; }
            set
            {
                if (_temperature_Dif != value)
                {
                    _temperature_Dif = value;
                    OnPropertyChanged(nameof(Temperature_Dif));
                    OnPropertyChanged(nameof(Temperature_DifTextColor));
                }
            }
        }

        private double _humidity_Dif;
        public double Humidity_Dif
        {
            get { return _humidity_Dif; }
            set
            {
                if (_humidity_Dif != value)
                {
                    _humidity_Dif = value;
                    OnPropertyChanged(nameof(Humidity_Dif));
                    OnPropertyChanged(nameof(Humidity_DifTextColor));
                }
            }
        }

        private double _pressure_Dif;
        public double Pressure_Dif
        {
            get { return _pressure_Dif; }
            set
            {
                if (_pressure_Dif != value)
                {
                    _pressure_Dif = value;
                    OnPropertyChanged(nameof(Pressure_Dif));
                    OnPropertyChanged(nameof(Pressure_DifTextColor));
                }
            }
        }

        private double _lightLevel_Dif;
        public double LightLevel_Dif
        {
            get { return _lightLevel_Dif; }
            set
            {
                if (_lightLevel_Dif != value)
                {
                    _lightLevel_Dif = value;
                    OnPropertyChanged(nameof(LightLevel_Dif));
                    OnPropertyChanged(nameof(LightLevel_DifTextColor));
                }
            }
        }
        private string _temperatureName;
        public string TemperatureName
        {
            get { return _temperatureName; }
            set
            {
                if (_temperatureName != value)
                {
                    _temperatureName = $"{value}: ";
                    OnPropertyChanged(nameof(TemperatureName));
                }
            }
        }

        private string _humidityName;
        public string HumidityName
        {
            get { return _humidityName; }
            set
            {
                if (_humidityName != value)
                {
                    _humidityName = $"{value}: ";
                    OnPropertyChanged(nameof(HumidityName));
                }
            }
        }

        private string _pressureName;
        public string PressureName
        {
            get { return _pressureName; }
            set
            {
                if (_pressureName != value)
                {
                    _pressureName = $"{value}: ";
                    OnPropertyChanged(nameof(PressureName));
                }
            }
        }

        private string _lightLevelName;
        public string LightLevelName
        {
            get { return _lightLevelName; }
            set
            {
                if (_lightLevelName != value)
                {
                    _lightLevelName = $"{value}: ";
                    OnPropertyChanged(nameof(LightLevelName));
                }
            }
        }
        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                if (_buttonText != value)
                {
                    _buttonText = value;
                    OnPropertyChanged(nameof(ButtonText));
                }
            }
        }
        public SolidColorBrush Temperature_DifTextColor
        {
            get
            {
                if (Temperature_Dif > 0)
                    return new SolidColorBrush(Colors.Green);
                else if (Temperature_Dif < 0)
                    return new SolidColorBrush(Colors.Red);
                else
                    return new SolidColorBrush(Colors.White);
            }
        }

        public SolidColorBrush Humidity_DifTextColor
        {
            get
            {
                if (Humidity_Dif > 0)
                    return new SolidColorBrush(Colors.Green);
                else if (Humidity_Dif < 0)
                    return new SolidColorBrush(Colors.Red);
                else
                    return new SolidColorBrush(Colors.White);
            }
        }

        public SolidColorBrush Pressure_DifTextColor
        {
            get
            {
                if (Pressure_Dif > 0)
                    return new SolidColorBrush(Colors.Green);
                else if (Pressure_Dif < 0)
                    return new SolidColorBrush(Colors.Red);
                else
                    return new SolidColorBrush(Colors.White);
            }
        }

        public SolidColorBrush LightLevel_DifTextColor
        {
            get
            {
                if (LightLevel_Dif > 0)
                    return new SolidColorBrush(Colors.Green);
                else if (LightLevel_Dif < 0)
                    return new SolidColorBrush(Colors.Red);
                else
                    return new SolidColorBrush(Colors.White);
            }
        }
        #endregion

    }
}
