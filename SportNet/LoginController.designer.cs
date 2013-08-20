// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SportNet
{
	[Register ("LoginController")]
	partial class LoginController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField Email { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Facebook { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ForgotPassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GooglePlus { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Login { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField Password { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Twitter { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Email != null) {
				Email.Dispose ();
				Email = null;
			}

			if (Facebook != null) {
				Facebook.Dispose ();
				Facebook = null;
			}

			if (ForgotPassword != null) {
				ForgotPassword.Dispose ();
				ForgotPassword = null;
			}

			if (GooglePlus != null) {
				GooglePlus.Dispose ();
				GooglePlus = null;
			}

			if (Login != null) {
				Login.Dispose ();
				Login = null;
			}

			if (Password != null) {
				Password.Dispose ();
				Password = null;
			}

			if (Twitter != null) {
				Twitter.Dispose ();
				Twitter = null;
			}
		}
	}
}
