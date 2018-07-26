using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MobileTests
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
				return ConfigureApp
                    .Android
                    .ApkFile("test.apk")
                    .StartApp();
			}

			return ConfigureApp.iOS.StartApp();
		}
	}
}