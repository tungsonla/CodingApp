using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace CodingApp.UITest.Activities
{
    public abstract class BaseActivity
    {
        #region Constructors

        protected BaseActivity(IApp app, string pageTitle)
        {
            App = app;
            Title = pageTitle;
        }

        #endregion

        #region Properties

        public string Title { get; }
        protected IApp App { get; }

        #endregion

        #region Methods

        public virtual Task WaitForPageToLoad() => Task.FromResult(App.WaitForElement(Title));

        #endregion
    }
}
