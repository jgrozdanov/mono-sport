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
		MonoTouch.UIKit.UIView FacebookView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ForgotPassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView GoogleView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Login { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField Password { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Email != null) {
				Email.Dispose ();
				Email = null;
			}

			if (ForgotPassword != null) {
				ForgotPassword.Dispose ();
				ForgotPassword = null;
			}

			if (Login != null) {
				Login.Dispose ();
				Login = null;
			}

			if (Password != null) {
				Password.Dispose ();
				Password = null;
			}

			if (FacebookView != null) {
				FacebookView.Dispose ();
				FacebookView = null;
			}

			if (GoogleView != null) {
				GoogleView.Dispose ();
				GoogleView = null;
			}
		}
	}
}
