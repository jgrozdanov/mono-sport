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
	[Register ("RemoveAccountController")]
	partial class RemoveAccountController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField PasswordTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Submit { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PasswordTextField != null) {
				PasswordTextField.Dispose ();
				PasswordTextField = null;
			}

			if (Submit != null) {
				Submit.Dispose ();
				Submit = null;
			}
		}
	}
}
