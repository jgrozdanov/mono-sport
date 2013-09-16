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
	[Register ("AccountSettingsController")]
	partial class AccountSettingsController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton aboutApp { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton changePassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton contentLang { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton editProfile { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel email { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel firstName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Image { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lastName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton notifications { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton removeAcc { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView ScrollableArea { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton signOut { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (signOut != null) {
				signOut.Dispose ();
				signOut = null;
			}

			if (aboutApp != null) {
				aboutApp.Dispose ();
				aboutApp = null;
			}

			if (removeAcc != null) {
				removeAcc.Dispose ();
				removeAcc = null;
			}

			if (contentLang != null) {
				contentLang.Dispose ();
				contentLang = null;
			}

			if (notifications != null) {
				notifications.Dispose ();
				notifications = null;
			}

			if (changePassword != null) {
				changePassword.Dispose ();
				changePassword = null;
			}

			if (editProfile != null) {
				editProfile.Dispose ();
				editProfile = null;
			}

			if (email != null) {
				email.Dispose ();
				email = null;
			}

			if (lastName != null) {
				lastName.Dispose ();
				lastName = null;
			}

			if (firstName != null) {
				firstName.Dispose ();
				firstName = null;
			}

			if (Image != null) {
				Image.Dispose ();
				Image = null;
			}

			if (ScrollableArea != null) {
				ScrollableArea.Dispose ();
				ScrollableArea = null;
			}
		}
	}
}
