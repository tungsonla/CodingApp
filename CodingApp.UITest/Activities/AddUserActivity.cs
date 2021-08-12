using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace CodingApp.UITest.Activities
{
    public class AddUserActivity : BaseActivity
    {
        public AddUserActivity(IApp app, string pageTitle)
            : base(app, pageTitle)
        {
        }

        public void EnterNameText(string text)
        {
            App.EnterText(x => x.Marked("user_name"), text);
            App.DismissKeyboard();
            App.Screenshot("Entered Name");
        }

        public void EnterPasswordText(string text)
        {
            App.EnterText(x => x.Marked("user_password"), text);
            App.DismissKeyboard();
            App.Screenshot("Entered Password");
        }

        public void TapSaveButton()
        {
            App.Tap(x => x.Marked("btn_save"));
            App.Screenshot("Save Button Tapped");
        }

        public void TapCancelButton()
        {
            App.Tap(x => x.Marked("btn_cancel"));
            App.Screenshot("Cancel Button Tapped");
        }
    }
}
