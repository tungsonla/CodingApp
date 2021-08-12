using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace CodingApp.UITest.Activities
{
    public class MainActivity : BaseActivity
    {

        public MainActivity(IApp app, string pageTitle)
            : base(app, pageTitle)
        {
        }

        public void TapAddButton()
        {
            App.Tap(x => x.Marked("fab"));
            App.Screenshot("Fab Button Tapped");
        }

    }
}
