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
	[Register ("ForgotPasswordController")]
	partial class ForgotPasswordController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField Email { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Send { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Email != null) {
				Email.Dispose ();
				Email = null;
			}

			if (Send != null) {
				Send.Dispose ();
				Send = null;
			}
		}
	}
}
