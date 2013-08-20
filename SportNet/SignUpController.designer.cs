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
	[Register ("SignUpController")]
	partial class SignUpController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton CreateAccount { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField Email { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Facebook { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField FirstName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GooglePlus { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Image { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ImagePicker { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField LastName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField Password { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Twitter { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Image != null) {
				Image.Dispose ();
				Image = null;
			}

			if (ImagePicker != null) {
				ImagePicker.Dispose ();
				ImagePicker = null;
			}

			if (FirstName != null) {
				FirstName.Dispose ();
				FirstName = null;
			}

			if (LastName != null) {
				LastName.Dispose ();
				LastName = null;
			}

			if (Email != null) {
				Email.Dispose ();
				Email = null;
			}

			if (Password != null) {
				Password.Dispose ();
				Password = null;
			}

			if (CreateAccount != null) {
				CreateAccount.Dispose ();
				CreateAccount = null;
			}

			if (Facebook != null) {
				Facebook.Dispose ();
				Facebook = null;
			}

			if (Twitter != null) {
				Twitter.Dispose ();
				Twitter = null;
			}

			if (GooglePlus != null) {
				GooglePlus.Dispose ();
				GooglePlus = null;
			}
		}
	}
}
