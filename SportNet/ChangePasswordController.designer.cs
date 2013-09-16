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
	[Register ("ChangePasswordController")]
	partial class ChangePasswordController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton Change { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField ConfirmPassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField CurrentPassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Divider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField NewPassword { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Change != null) {
				Change.Dispose ();
				Change = null;
			}

			if (NewPassword != null) {
				NewPassword.Dispose ();
				NewPassword = null;
			}

			if (ConfirmPassword != null) {
				ConfirmPassword.Dispose ();
				ConfirmPassword = null;
			}

			if (CurrentPassword != null) {
				CurrentPassword.Dispose ();
				CurrentPassword = null;
			}

			if (Divider != null) {
				Divider.Dispose ();
				Divider = null;
			}
		}
	}
}
