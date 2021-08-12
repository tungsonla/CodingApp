using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.UITest;

namespace CodingApp.Test.Activities
{
    public abstract class BaseActivity
    {
        protected BaseActivity(IApp app, string pageTitle)
        {
            App = app;
            Title = pageTitle;
        }
    }
}
