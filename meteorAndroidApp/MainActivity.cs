using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using System.Timers;
using Android.Widget;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using Java.Lang;

namespace meteorAndroidApp
{


    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        string language = "en";

        private IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "92Avq34xTQN38jJarUvcfrj7mzpHOzXj6HenJSOd",
            BasePath = "https://iot-meteorologicka-stanica-default-rtdb.europe-west1.firebasedatabase.app"
        };
        private IFirebaseClient client;

        private TextView _textViewTemperature;
        private TextView _textViewHumidity;
        private TextView _textViewPressure;
        private TextView _textViewLightLevel;
        private TextView timeShower;
        private TextView text6;
        private TextView text7;
        private Timer _timer;
        private TextView _textViewTemperature_dif;
        private TextView _textViewHumidity_dif;
        private TextView _textViewPressure_dif;
        private TextView _textViewLightLevel_dif;
        private Button btn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Click += OnButtonClicked;

            // Find TextViews by their IDs
            _textViewTemperature = FindViewById<TextView>(Resource.Id.textView1);
            _textViewHumidity = FindViewById<TextView>(Resource.Id.textView2);
            _textViewPressure = FindViewById<TextView>(Resource.Id.textView3);
            _textViewLightLevel = FindViewById<TextView>(Resource.Id.textView4);
            timeShower = FindViewById<TextView>(Resource.Id.textView5);
            text6 = FindViewById<TextView>(Resource.Id.textView6);
            text7 = FindViewById<TextView>(Resource.Id.textView7);
            _textViewTemperature_dif = FindViewById<TextView>(Resource.Id.textView8);
            _textViewHumidity_dif = FindViewById<TextView>(Resource.Id.textView9);
            _textViewPressure_dif = FindViewById<TextView>(Resource.Id.textView10);
            _textViewLightLevel_dif = FindViewById<TextView>(Resource.Id.textView11);
            btn = FindViewById<Button>(Resource.Id.button1);

            // Initialize timer with 1 second interval+firebase
            try
            {
                client = new FireSharp.FirebaseClient(config);
                _timer = new Timer(1000);
                _timer.Elapsed += Timer_Elapsed;
                _timer.Start();

            }
            catch (System.Exception ex) { }
        }

        string temperatureName = "Temperature"; // Custom name for temperature
        string humidityName = "Humidity"; // Custom name for humidity
        string pressureName = "Pressure"; // Custom name for pressure
        string lightLevelName = "Light Level"; // Custom name for light level
        string saveName = "Save"; // Custom name for saved data
        string latestSaveName = "Latest save"; // Custom name for latest saved data
        string latestUpdateName = "Latest update";


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Update TextViews with new values every second

            // RunOnUiThread method ensures that the code inside the lambda expression is executed on the UI thread
            RunOnUiThread(() =>
            {
                // Fetch data from Firebase for "RealTime" node
                FirebaseResponse response = client.Get("RealTime");
                Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());

                // Update TextViews with fetched data
                _textViewTemperature.Text = $"{temperatureName}:\n" + data["Temperature"] + " °C";
                _textViewHumidity.Text = $"{humidityName}:\n" + data["Humidity"] + " %";
                _textViewPressure.Text = $"{pressureName}:\n" + data["Pressure"] + " hPa";
                _textViewLightLevel.Text = $"{lightLevelName}:\n" + data["LightLevel"] + " lux";

                // Fetch data from Firebase for "Save" node
                FirebaseResponse response2 = client.Get("Save");
                Dictionary<string, string> data2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(response2.Body.ToString());

                // Calculate difference in values between "RealTime" and "Save" nodes
                Temperature_dif = System.Math.Round(float.Parse(data["Temperature"]) - float.Parse(data2["Temperature"]), 2);
                Humidity_dif = System.Math.Round(float.Parse(data["Humidity"]) - float.Parse(data2["Humidity"]), 2);
                Pressure_dif = System.Math.Round(float.Parse(data["Pressure"]) - float.Parse(data2["Pressure"]), 2);
                LightLevel_dif = System.Math.Round(float.Parse(data["LightLevel"]) - float.Parse(data2["LightLevel"]), 2);


                // Update TextViews with calculated differences and current time
                timeShower.Text = $"{latestUpdateName}:   {DateTime.Now.ToString("yyyy-dd-mm HH:mm:ss")}\n{latestSaveName}:   {data2["Time"]}";
                text6.Text = $"{saveName}:\n{temperatureName}: {data2["Temperature"]} °C\n{humidityName}: {data2["Humidity"]}%\n{pressureName}: {data2["Pressure"]} hPa\n{lightLevelName}: {data2["LightLevel"]} lux";
            });
        }


        private void languageEnglish()
        {
            temperatureName = "Temperature"; // Custom name for temperature
            humidityName = "Humidity"; // Custom name for humidity
            pressureName = "Pressure"; // Custom name for pressure
            lightLevelName = "Light Level"; // Custom name for light level
            saveName = "Save"; // Custom name for saved data
            latestSaveName = "Latest Save"; // Custom name for latest saved data
            latestUpdateName = "Latest update";
            text7.Text = "Relative change:";
            btn.Text = "Save current values";
            Timer_Elapsed(null, null);
        }

        private void languageSlovak()
        {
            temperatureName = "Teplota"; // Custom name for temperature
            humidityName = "Vlhkosť"; // Custom name for humidity
            pressureName = "Tlak"; // Custom name for pressure
            lightLevelName = "Úroveň svetla"; // Custom name for light level
            saveName = "Uložené"; // Custom name for saved data
            latestSaveName = "Najnovšie uložené"; // Custom name for latest saved data
            latestUpdateName = "Posledný update";
            text7.Text = "Zmena:";
            btn.Text = "Uložiť aktúalne hodnoty";
            Timer_Elapsed(null, null);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (language)
            {
                case "sk":
                    languageEnglish();
                    language = "en";
                    break;
                default:
                    languageSlovak();
                    language = "sk";
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            // Stop and dispose the timer when the activity is destroyed
            _timer.Stop();
            _timer.Dispose();
        }

        public void OnButtonClicked(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("RealTime");
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());
            client.Set("Save", data);
            client.Set("Save/Time", DateTime.Now.ToString("yyyy-dd-mm HH:mm:ss"));


        }

        //getters and setters

        private double _temperature_dif;
        public double Temperature_dif
        {
            get { return _temperature_dif; }
            set
            {
                _temperature_dif = value;
                _textViewTemperature_dif.Text = value.ToString() + " °C";
                if (value > 0)
                {
                    _textViewTemperature_dif.SetTextColor(Android.Graphics.Color.Green);
                }
                else if (value < 0)
                {
                    _textViewTemperature_dif.SetTextColor(Android.Graphics.Color.Red);
                }
                else
                {
                    _textViewTemperature_dif.SetTextColor(Android.Graphics.Color.White);
                }
            }
        }

        private double _humidity_dif;
        public double Humidity_dif
        {
            get { return _humidity_dif; }
            set
            {
                _humidity_dif = value;
                _textViewHumidity_dif.Text = value.ToString() + "%";
                if (value > 0)
                {
                    _textViewHumidity_dif.SetTextColor(Android.Graphics.Color.Green);
                }
                else if (value < 0)
                {
                    _textViewHumidity_dif.SetTextColor(Android.Graphics.Color.Red);
                }
                else
                {
                    _textViewHumidity_dif.SetTextColor(Android.Graphics.Color.White);
                }
            }
        }

        private double _pressure_dif;
        public double Pressure_dif
        {
            get { return _pressure_dif; }
            set
            {
                _pressure_dif = value;
                _textViewPressure_dif.Text = value.ToString() + " hPa";
                if (value > 0)
                {
                    _textViewPressure_dif.SetTextColor(Android.Graphics.Color.Green);
                }
                else if (value < 0)
                {
                    _textViewPressure_dif.SetTextColor(Android.Graphics.Color.Red);
                }
                else
                {
                    _textViewPressure_dif.SetTextColor(Android.Graphics.Color.White);
                }
            }
        }

        private double _lightLevel_dif;
        public double LightLevel_dif
        {
            get { return _lightLevel_dif; }
            set
            {
                _lightLevel_dif = value;
                _textViewLightLevel_dif.Text = value.ToString() + " lux";
                if (value > 0)
                {
                    _textViewLightLevel_dif.SetTextColor(Android.Graphics.Color.Green);
                }
                else if (value < 0)
                {
                    _textViewLightLevel_dif.SetTextColor(Android.Graphics.Color.Red);
                }
                else
                {
                    _textViewLightLevel_dif.SetTextColor(Android.Graphics.Color.White);
                }
            }
        }



    }
}
