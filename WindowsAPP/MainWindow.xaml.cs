using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace WindowsAPP
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "T2zlocY55s02hfu8EPfYXUHpsgb2EvvFCffhVoEh",
            BasePath = "https://mete-e384b-default-rtdb.europe-west1.firebasedatabase.app"
        };
        private IFirebaseClient client;

        private System.Timers.Timer timer = new System.Timers.Timer();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Initialize Firebase client
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                // Set up the timer
                timer.Interval = 1000; // 1 second
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
            else
            {
                MessageBox.Show("Failed to connect to Firebase Realtime Database");
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Update the current time property with the current date and time
            CurrentTime = DateTime.Now.ToString("yyyy-dd-mm HH:mm:ss");

            // Retrieve values from Firebase Realtime Database
            FirebaseResponse response = client.Get("RealTime");
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());

            // Update properties with real-time data
            Temperature = $"{data["Temperature"]}";
            Humidity = $"{data["Humidity"]}";
            Pressure = $"{data["Pressure"]}";
            LightLevel = $"{data["LightLevel"]}";

            // Retrieve values from Firebase Realtime Database for saved data
            response = client.Get("Save");
            Dictionary<string, string> data2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());

            // Update properties with saved data
            SavedTime = "Latest Save: " + data2["Time"];
            savedVals = $"Save:\nTemperature: {data2["Temperature"]} °C\nHumidity: {data2["Humidity"]}%\nPressure: {data2["Pressure"]} hPa\nLight level: {data2["LightLevel"]} lux";

            // Calculate differences and update properties
            Temperature_Dif = float.Parse(data["Temperature"]) - float.Parse(data2["Temperature"]);
            Humidity_Dif = float.Parse(data["Humidity"]) - float.Parse(data2["Humidity"]);
            Pressure_Dif = float.Parse(data["Pressure"]) - float.Parse(data2["Pressure"]);
            LightLevel_Dif = float.Parse(data["LightLevel"]) - float.Parse(data2["LightLevel"]);
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FirebaseResponse response = client.Get("RealTime");
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());
            client.Set("Save", data);
            client.Set("Save/Time", DateTime.Now.ToString("yyyy-dd-mm HH:mm:ss"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        // getters and setters




        private double temperature;
        public string Temperature
        {
            get { return $"{Math.Round(temperature, 2)}°C"; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp))
                {
                    temperature = temp;
                    OnPropertyChanged("Temperature");
                }
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
                double press;
                if (double.TryParse(value, out press))
                {
                    pressure = press;
                    OnPropertyChanged("Pressure");
                }
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
                    currentTime = "Last update: "+value;
                    OnPropertyChanged("CurrentTime");
            }
        }

        // Property for SavedTime
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

        // Property for savedVals
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


    }
}
