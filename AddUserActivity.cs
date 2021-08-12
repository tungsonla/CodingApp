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
using System.Text.RegularExpressions;

namespace CodingApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", ParentActivity = typeof(MainActivity))]
    public class AddUserActivity : AppCompatActivity
    {
        private UserDataStore userDataStore;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_add_user);
            userDataStore = new UserDataStore(this);

            FindViewById<Button>(Resource.Id.CancelButton).Click += HandleCancel;
            FindViewById<Button>(Resource.Id.SaveButton).Click += HandleSave;
        }

        /// <summary>
        /// Handle Cancel Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void HandleCancel(object sender, EventArgs eventArgs)
        {
            Finish();
        }

        /// <summary>
        /// Handle Save Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void HandleSave(object sender, EventArgs eventArgs)
        {

            var userName = FindViewById<EditText>(Resource.Id.user_name).Text;
            var userPassword = FindViewById<EditText>(Resource.Id.user_password).Text;

            if (InputValidations(userName, userPassword) == true)
            {
                userDataStore.InsertNewUser(userName, PasswordHash.CreateHash(userPassword));
                Finish();
            }
        }

        /// <summary>
        /// Input Validations
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        private bool InputValidations(string userName, string userPassword)
        {
            var nameResult = FindViewById<TextView>(Resource.Id.name_message);
            nameResult.Text = String.Empty;
            var passwordResult = FindViewById<TextView>(Resource.Id.password_message);
            passwordResult.Text = String.Empty;

            if (String.IsNullOrWhiteSpace(userName))
            {
                nameResult.Text = "Please enter user name";
                return false;
            }

            if (userDataStore.IsUserNameExists(userName))
            {
                nameResult.Text = "User name already exists.";
                return false;
            }

            if (String.IsNullOrWhiteSpace(userPassword))
            {
                passwordResult.Text = "Please enter user password";
                return false;
            }

            if (userPassword.Length < 5 || userPassword.Length > 12)
            {
                passwordResult.Text = "Password must be between 5 and 12 characters in length.";
                return false;
            }

            if (!Regex.IsMatch(userPassword, @"\d"))
            {
                passwordResult.Text = "Password must contain at least 1 digit.";
                return false;
            }

            if (!Regex.IsMatch(userPassword, @"[a-zA-Z]"))
            {
                passwordResult.Text = "Password must contain at least 1 letter.";
                return false;
            }

            if (Regex.IsMatch(userPassword, @"(.+)\1"))
            {
                passwordResult.Text = "Password must not contain any sequence of characters immediately followed by the same sequence.";
                return false;
            }

            return true;
        }
    }
}
