using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading.Tasks;

namespace CodingApp.UITest
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public async Task AddBtn_SaveNewUser_Success()
        {
            // Arrange

            // Act
            // press add button
            MainActivity.TapAddButton();

            // wait for activity item detail
            await Task.FromResult(App.WaitForElement("activity_add_user")).ConfigureAwait(false);

            // enter item data
            AddUserActivity.EnterNameText("test_name");
            AddUserActivity.EnterPasswordText("abcd1234");

            // press save button
            AddUserActivity.TapSaveButton();

            // wait for main_activity
            await Task.FromResult(App.WaitForElement("activity_main")).ConfigureAwait(false);

            // Assert => entered item should be on the list
            Assert.True(DoesItemExist("test_name"));
        }
    }
}
