using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CodingApp.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp()
        {
            //return ConfigureApp
            //        .Android
            //        .ApkFile("../../../CodingApp/bin/Release/com.companyname.codingapp.apk")
            //        .StartApp();
            return ConfigureApp.Android.InstalledApp("com.companyname.codingapp").StartApp();
        }
    }
}