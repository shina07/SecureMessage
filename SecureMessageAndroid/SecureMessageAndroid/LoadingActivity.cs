using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace SecureMessageAndroid
{
    [Activity(Label = "LoadingActivity", MainLauncher = true)]
    public class LoadingActivity : Activity
    {
        static readonly string Tag = "X:" + typeof(LoadingActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Log.Debug(Tag, "LoadingActivity.OnCreate");

            // Create your application here
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_loading);
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { Startup(); });
            startupWork.Start();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        async void Startup()
        {
            Log.Debug(Tag, "Loading Start.");
            await Task.Delay(5000); // Simulate a bit of startup work.
            Log.Debug(Tag, "Loading Finished. start MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}