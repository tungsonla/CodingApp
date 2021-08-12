using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using CodingApp.UITest.Activities;

namespace CodingApp.UITest
{
    public abstract class BaseTest
    {
        #region Properties

        protected IApp App { get; private set; }
        protected MainActivity MainActivity { get; private set; }
        protected AddUserActivity AddUserActivity { get; private set; }

        #endregion

        #region Methods

        [SetUp]
        public async Task TestSetup()
        {
            App = AppInitializer.StartApp();

            MainActivity = new MainActivity(App, "activity_main");
            AddUserActivity = new AddUserActivity(App, "activity_add_user");

            await MainActivity.WaitForPageToLoad().ConfigureAwait(false);
            App.Screenshot("App Launched");
        }

        [TearDown]
        public async Task TestTearDown()
        {
            try
            {
                await Task.FromResult(App.WaitForElement("activity_main")).ConfigureAwait(false);
            }
            catch
            {
                AddUserActivity.TapCancelButton();
            }
        }

        #endregion

        #region Protected Methods

        protected bool DoesItemExist(string name)
        {
            try
            {
                App.ScrollDownTo(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
