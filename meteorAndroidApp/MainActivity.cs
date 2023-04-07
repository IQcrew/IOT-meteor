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

namespace meteorAndroidApp
{


    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "T2zlocY55s02hfu8EPfYXUHpsgb2EvvFCffhVoEh",
            BasePath = "https://mete-e384b-default-rtdb.europe-west1.firebasedatabase.app"
        };
        private IFirebaseClient client;

        private TextView _textViewTemperature;
        private TextView _textViewHumidity;
        private TextView _textViewPressure;
        private TextView _textViewLightLevel;
        private Timer _timer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // Find TextViews by their IDs
            _textViewTemperature = FindViewById<TextView>(Resource.Id.textView1);
            _textViewHumidity = FindViewById<TextView>(Resource.Id.textView2);
            _textViewPressure = FindViewById<TextView>(Resource.Id.textView3);
            _textViewLightLevel = FindViewById<TextView>(Resource.Id.textView4);

            // Initialize timer with 1 second interval+firebase
            try
            {
                client = new FireSharp.FirebaseClient(config);
                _timer = new Timer(1000);
                _timer.Elapsed += Timer_Elapsed;
                _timer.Start();

            }
            catch (Exception ex) { }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Update TextViews with new values every second
            RunOnUiThread(() =>
            {
                FirebaseResponse response = client.Get("RealTime");
                Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Body.ToString());
                _textViewTemperature.Text = "Temperature:\n" + data["Temperature"] + " °C";
                _textViewHumidity.Text = "Humidity:\n" + data["Humidity"] + " %";
                _textViewPressure.Text = "Pressure:\n" + data["Pressure"] + " hPa";
                _textViewLightLevel.Text = "Light level:\n" + data["LightLevel"] + " lux";
            });
        }

        

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
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
    }
}
