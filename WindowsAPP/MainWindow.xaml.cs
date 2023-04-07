using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using System.Windows;
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
                if (currentTime != value)
                {
                    currentTime = value;
                    OnPropertyChanged("CurrentTime");
                }
            }
        }


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

            Temperature = $"{data["Temperature"]}";
            Humidity = $"{data["Humidity"]}";
            Pressure = $"{data["Pressure"]}";
            LightLevel = $"{data["LightLevel"]}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
