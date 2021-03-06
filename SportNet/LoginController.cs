// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SportNet.Web.Models;
using MonoTouch.FacebookConnect;
using Newtonsoft.Json;
using Google.Plus;

namespace SportNet
{
	public partial class LoginController : UIViewController
	{
		public LoginController (IntPtr handle) : base (handle)
		{
		}

		private FBLoginView fbLogin;

		public override void ViewWillAppear (bool animated)
		{
			this.Email.Background = UIImage.FromFile ("./Assets/input.png");
			this.Password.Background = UIImage.FromFile ("./Assets/input.png");
			this.Login.SetBackgroundImage (UIImage.FromFile ("./Assets/buttonlong.png"), UIControlState.Normal);

			this.Email.LeftView = new UIView (new RectangleF (0, 0, 5, 30));
			this.Email.LeftViewMode = UITextFieldViewMode.Always;
			this.Password.LeftView = new UIView (new RectangleF (0, 0, 5, 30));
			this.Password.LeftViewMode = UITextFieldViewMode.Always;

			var button = new UIBarButtonItem ("Back", UIBarButtonItemStyle.Plain, null);
			var custom = new UIButton (new RectangleF (0, 0, 26, 15));
			custom.SetBackgroundImage(UIImage.FromFile("./Assets/back.png"), UIControlState.Normal);
			custom.TouchUpInside += (sender, e) => NavigationController.PopViewControllerAnimated (true);
			button.CustomView = custom;

			this.NavigationItem.LeftBarButtonItem = button;
			this.NavigationController.SetNavigationBarHidden (false, false);

			// FACEBOOK LOGIN
			fbLogin = new FBLoginView (AppDelegate.Permissions);
			FacebookView.AddSubview (fbLogin);
			fbLogin.SizeToFit ();

			fbLogin.FetchedUserInfo += (object sender, FBLoginViewUserInfoEventArgs e) => {
				if (FBSession.ActiveSession.IsOpen) {
					var model = new FacebookProfile { Id = long.Parse (e.User.Id), Name = e.User.Name, 
						first_name = e.User.FirstName, last_name = e.User.LastName, 
						Birthday = e.User.Birthday, Email = e.User.ObjectForKey ("email").ToString (), UserName = e.User.Username
					};
					var request = new RestRequest ();
					request.RequestFinished += (object sendr, RequestEndedArgs ev) => {
						var jsonId = (int)JsonConvert.DeserializeObject (ev.Result, typeof(int));
						InvokeOnMainThread (delegate {
							AppDelegate.SaveProfileId(jsonId);
							var tabbar = new MainTabController();
							UIApplication.SharedApplication.Delegate.Window.RootViewController = tabbar;
						});
					};
					request.Send (RequestConfig.Facebook, "POST", model);
				}
			};

			fbLogin.ShowingLoggedOutUser += (object sender, EventArgs e) => {
				Console.WriteLine(e.ToString());
			};
			fbLogin.ShowingLoggedInUser += (object sender, EventArgs e) => {
				Console.WriteLine("Logged in.");
			};

			// GOOGLE LOGIN
			var signIn = SignIn.SharedInstance;
			signIn.ClientId = AppDelegate.GoogleClientId;
			signIn.Scopes = new [] { PlusConstants.AuthScopePlusLogin, PlusConstants.AuthScopePlusMe, 
									"https://www.googleapis.com/auth/userinfo.profile",
									"https://www.googleapis.com/auth/userinfo.email" };
			signIn.ShouldFetchGoogleUserEmail = true;
			signIn.ShouldFetchGoogleUserId = true;

			signIn.Finished += (object sender, SignInDelegateFinishedEventArgs e) => {
				if(e.Error != null) {
					InvokeOnMainThread(delegate {
						new UIAlertView("Error.", "Could not sign in.", null, "Ok", null).Show();	
					});
				}
				else {
					var request = new RestRequest();
					request.RequestFinished += (object sendr, RequestEndedArgs ev) => {
						var data = (GoogleClient)JsonConvert.DeserializeObject(ev.Result, typeof(GoogleClient));
						var request2 = new RestRequest();
						request2.RequestFinished += (object sndr, RequestEndedArgs evnt) => {
							var jsonId = (int)JsonConvert.DeserializeObject (evnt.Result, typeof(int));
							InvokeOnMainThread (delegate {
								AppDelegate.SaveProfileId(jsonId);
								var tabbar = new MainTabController();
								UIApplication.SharedApplication.Delegate.Window.RootViewController = tabbar;
							});
						};
						request2.Send(RequestConfig.Google, "POST", data);
					};
					request.Send(String.Format(RequestConfig.GoogleFetch, Uri.EscapeDataString(signIn.Authentication.AccessToken)), "GET");
				}
			};

			var signInButton = new SignInButton ();
			GoogleView.AddSubview (signInButton);
			signInButton.Frame = new RectangleF (0, 0, GoogleView.Frame.Size.Width - 8, GoogleView.Frame.Size.Height);
			signInButton.SizeToFit ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.ForgotPassword.TouchUpInside += (object sender, EventArgs e) => {
				var board = UIStoryboard.FromName ("MainStoryboard", null);
				var password = (ForgotPasswordController)board.InstantiateViewController ("forgotpassword");
				this.NavigationController.PushViewController(password, true);
			};

			this.Login.TouchUpInside += (object sender, EventArgs e) => {
				//((UIWindow)UIApplication.SharedApplication.Delegate.Window).RootViewController = 
				//	new MainTabController();
				var request = new RestRequest();
				var model = new LoginModel { Email = this.Email.Text, Password = this.Password.Text, RememberMe = true };
				request.Send(RequestConfig.Login, "POST", model);
				request.RequestFinished += (object send, RequestEndedArgs ev) => {
					var jsonId = (int)JsonConvert.DeserializeObject (ev.Result, typeof(int));
					InvokeOnMainThread (delegate {
						AppDelegate.SaveProfileId(jsonId);
						var tabbar = new MainTabController();
						UIApplication.SharedApplication.Delegate.Window.RootViewController = tabbar;
					});
				};
			};
		}
	}
}
