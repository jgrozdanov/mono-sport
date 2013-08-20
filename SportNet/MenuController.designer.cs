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
	[Register ("MenuController")]
	partial class MenuController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton AddContent { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Image { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Image != null) {
				Image.Dispose ();
				Image = null;
			}

			if (AddContent != null) {
				AddContent.Dispose ();
				AddContent = null;
			}
		}
	}
}
