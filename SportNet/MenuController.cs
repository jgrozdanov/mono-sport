// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Newtonsoft.Json;
using SportNet.Web.Models;

namespace SportNet
{
	public partial class MenuController : UITableViewController
	{
		public MenuController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			if (((AppDelegate)UIApplication.SharedApplication.Delegate).profilePhoto == null) {
				this.Image.Image = UIImage.FromFile ("./Assets/profile.png");
			} else {
				this.Image.Image = ((AppDelegate)UIApplication.SharedApplication.Delegate).profilePhoto;
			}
			this.AddContent.SetBackgroundImage (UIImage.FromFile ("./Assets/addcontent.png"), UIControlState.Normal);
			TableView.ScrollsToTop = false;
			TableView.SeparatorColor = UIColor.FromRGB (38, 38, 38);
			TableView.AllowsMultipleSelection = false;
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			if (!AppDelegate.IsLoggedIn ()) {
				this.AddContent.Hidden = true;
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//AppDelegate appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
			//UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);

			if (AppDelegate.IsLoggedIn ()) {
				this.Login.Hidden = true;
				this.SignUp.Hidden = true;

				var request = new RestRequest ();
				request.RequestFinished += (object sender, RequestEndedArgs e) => {
					var data = (ProfileUpdateModel)JsonConvert.DeserializeObject(e.Result, typeof(ProfileUpdateModel));
					InvokeOnMainThread(delegate {
						this.Name.SetTitle(data.FirstName + " " + data.LastName, UIControlState.Normal);
						this.Settings.SetTitle("Logout", UIControlState.Normal);
						if(!string.IsNullOrEmpty(data.PictureUrl)) {
							AppDelegate.MakeImageFromURL(this.Image, data.PictureUrl);
						}
					});
				};
				request.Send (string.Format (RequestConfig.Profile, AppDelegate.GetProfileId()), "GET");
			} 
			else {
				this.Name.Hidden = true;
				this.Settings.Hidden = true;
			}

			this.Login.TouchUpInside += (object sender, EventArgs e) => {
				UINavigationController welcomeNav = new UINavigationController ();
				welcomeNav.NavigationBar.SetBackgroundImage (UIImage.FromFile ("./Assets/navbar.png"), 
				                                             MonoTouch.UIKit.UIBarMetrics.Default);
				UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
				WelcomeController welcome = (WelcomeController)board.InstantiateViewController ("welcomecontroller");
				UINavigationBar.Appearance.SetTitleTextAttributes 
					(new UITextAttributes { TextColor = UIColor.FromRGB(102, 102, 102) });

				welcomeNav.PushViewController (welcome, false);

				UIApplication.SharedApplication.KeyWindow.RootViewController = welcomeNav;
			};

			this.SignUp.TouchUpInside += (object sender, EventArgs e) => {
				//AccountSettingsController accSettings = (AccountSettingsController)board.InstantiateViewController ("accountSettingsController");
				//this.NavigationController.PushViewController(accSettings, true);

				UINavigationController welcomeNav = new UINavigationController ();
				welcomeNav.NavigationBar.SetBackgroundImage (UIImage.FromFile ("./Assets/navbar.png"), 
				                                             MonoTouch.UIKit.UIBarMetrics.Default);
				UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
				WelcomeController welcome = (WelcomeController)board.InstantiateViewController ("welcomecontroller");
				UINavigationBar.Appearance.SetTitleTextAttributes 
					(new UITextAttributes { TextColor = UIColor.FromRGB(102, 102, 102) });

				welcomeNav.PushViewController (welcome, false);

				UIApplication.SharedApplication.KeyWindow.RootViewController = welcomeNav;
			};

			this.Settings.TouchUpInside += (object sender, EventArgs e) => {
				AppDelegate.DeleteProfileId();

				UINavigationController welcomeNav = new UINavigationController ();
				welcomeNav.NavigationBar.SetBackgroundImage (UIImage.FromFile ("./Assets/navbar.png"), 
				                                             MonoTouch.UIKit.UIBarMetrics.Default);
				UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
				WelcomeController welcome = (WelcomeController)board.InstantiateViewController ("welcomecontroller");
				UINavigationBar.Appearance.SetTitleTextAttributes 
					(new UITextAttributes { TextColor = UIColor.FromRGB(102, 102, 102) });

				welcomeNav.PushViewController (welcome, false);

				UIApplication.SharedApplication.KeyWindow.RootViewController = welcomeNav;
			};

			this.AddContent.TouchUpInside += (object sender, EventArgs e) => {
				UINavigationController prefsNav = new UINavigationController ();
				prefsNav.NavigationBar.SetBackgroundImage (UIImage.FromFile ("./Assets/navbar.png"), 
				                                             MonoTouch.UIKit.UIBarMetrics.Default);
				UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
				var prefs = (PreferencesController)board.InstantiateViewController ("preferencescontroller");
				UINavigationBar.Appearance.SetTitleTextAttributes 
					(new UITextAttributes { TextColor = UIColor.FromRGB(102, 102, 102) });

				prefs.Title = "Welcome";
				prefsNav.PushViewController (prefs, false);
				UIApplication.SharedApplication.Delegate.Window.RootViewController = prefsNav;
			};
		}
	}
}
