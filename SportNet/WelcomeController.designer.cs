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
	[Register ("WelcomeController")]
	partial class WelcomeController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView BackgroundView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Login { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Register { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BackgroundView != null) {
				BackgroundView.Dispose ();
				BackgroundView = null;
			}

			if (Register != null) {
				Register.Dispose ();
				Register = null;
			}

			if (Login != null) {
				Login.Dispose ();
				Login = null;
			}
		}
	}
}
