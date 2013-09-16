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
	[Register ("EditProfileController")]
	partial class EditProfileController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton Chose { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Divider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField EmailTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField FirstNameTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Image { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField LastNameTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton MakeProfilePublic { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView ScrollableArea { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView SecondDivider { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Chose != null) {
				Chose.Dispose ();
				Chose = null;
			}

			if (Divider != null) {
				Divider.Dispose ();
				Divider = null;
			}

			if (EmailTextField != null) {
				EmailTextField.Dispose ();
				EmailTextField = null;
			}

			if (FirstNameTextField != null) {
				FirstNameTextField.Dispose ();
				FirstNameTextField = null;
			}

			if (Image != null) {
				Image.Dispose ();
				Image = null;
			}

			if (LastNameTextField != null) {
				LastNameTextField.Dispose ();
				LastNameTextField = null;
			}

			if (MakeProfilePublic != null) {
				MakeProfilePublic.Dispose ();
				MakeProfilePublic = null;
			}

			if (ScrollableArea != null) {
				ScrollableArea.Dispose ();
				ScrollableArea = null;
			}

			if (SecondDivider != null) {
				SecondDivider.Dispose ();
				SecondDivider = null;
			}
		}
	}
}
