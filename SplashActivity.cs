using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using System.Collections.Generic;
using Android.Widget;
using Android.Content;
using System.Threading.Tasks;

namespace CodingApp
{
    [Activity(Theme = "@style/ThemeSplash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);  
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { AppStartup(); });
            startupWork.Start();
        }


        async void AppStartup()
        {
            await Task.Delay(500);
            StartActivity(new Android.Content.Intent(Application.Context, typeof(MainActivity)));
        }

        public override void OnBackPressed() { }
    }
}
