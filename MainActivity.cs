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

namespace CodingApp
{
    [Activity(Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        private ListView userListView;
        private UserDataStore userDataStore;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            userDataStore = new UserDataStore(this);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            userListView = FindViewById<ListView>(Resource.Id.userListView);
           
        }

        protected override void OnResume()
        {
            base.OnResume();
            this.LoadUserList();
        }

        public void LoadUserList()
        {
            List<string> userList = userDataStore.GetUserList();
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, userList);
            userListView.Adapter = adapter;
        }

        /// <summary>
        /// Navigate to Add User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            using (Intent myIntent = new Intent(this, typeof(AddUserActivity)))
            {
                StartActivity(myIntent);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
