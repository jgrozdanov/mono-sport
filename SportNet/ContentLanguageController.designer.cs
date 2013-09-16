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
	[Register ("ContentLanguageController")]
	partial class ContentLanguageController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView Divider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Divider != null) {
				Divider.Dispose ();
				Divider = null;
			}

			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
