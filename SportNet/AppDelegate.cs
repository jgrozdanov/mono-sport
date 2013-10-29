using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SDWebImage;
using MonoTouch.FacebookConnect;
using Google.Plus;
using SportNet.Web.Models;

namespace SportNet
{
 
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		public override UIWindow Window {
			get;
			set;
		}

		// app state declarations
		public UIImage profilePhoto { get; set; }
		public float FeaturedScrollOffset { get; set; }
		public bool IsSeven { get; set; }

		public static string FbAppId = "1390701187813059";
		public static string GoogleClientId = "33566934173-ut55f4no1cs2oef2o1i5anhkiaf0h5fh.apps.googleusercontent.com";
		public static string[] Permissions = new string[] { "user_about_me", "email" };

		public static AddContentModel MainCategories { get; set; }
		public static AddContentModel SubCategories { get; set; }

		public static void MakeImageFromURL(UIImageView imageHolder, string url)
		{
			// using SDWebImage to lazy load and
			// cache the images
			imageHolder.SetImage (new NSUrl (url));
		}

		public static bool IsLoggedIn()
		{
			string path = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string filePath = Path.Combine (path, "user.txt");
			return File.Exists (filePath);
		}

		public static void SaveProfileId(int id)
		{
			string path = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string filePath = Path.Combine (path, "user.txt");
			File.WriteAllText (filePath, id.ToString());
		}

		public static int GetProfileId()
		{
			string path = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string filePath = Path.Combine (path, "user.txt");
			int n = 0;
			if (!File.Exists (filePath))
				return 0;
			int.TryParse (File.ReadAllText (filePath), out n);
			return n;
		}

		public static void DeleteProfileId()
		{
			string path = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string filePath = Path.Combine (path, "user.txt");
			File.Delete (filePath);
		}

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Window = new UIWindow (UIScreen.MainScreen.Bounds);

			// System version checks
			if (int.Parse (UIDevice.CurrentDevice.SystemVersion.Split ('.') [0]) < 7) {
				IsSeven = false;
			} 
			else {
				IsSeven = true;
			}

			// Init the singletons oi oi
			MainCategories = new AddContentModel ();
			MainCategories.Categories = new List<AddContentItem> ();
			SubCategories = new AddContentModel ();
			SubCategories.Categories = new List<AddContentItem> ();

			var tabbar = new MainTabController ();
			Window.RootViewController = tabbar;

			FBSettings.DefaultAppID = FbAppId;
			FBSettings.DefaultDisplayName = "Sport.Net";

			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
			Window.MakeKeyAndVisible ();
			return true;
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// This handler will properly handle the URL that your application 
			// receives at the end of the authentication process.
			return UrlHandler.HandleUrl (url, sourceApplication, annotation);
		}    

		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		// This method is called when the application is about to terminate. Save data, if needed. 
		public override void WillTerminate (UIApplication application)
		{
		}
	}
}

