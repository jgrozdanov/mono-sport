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
	[Register ("PictureHeaderVIew")]
	partial class PictureHeaderVIew
	{
		[Outlet]
		public MonoTouch.UIKit.UIImageView photo { get; set; }

		[Outlet]
		public MonoTouch.UIKit.UILabel picturesCount { get; set; }

		[Outlet]
		public MonoTouch.UIKit.UILabel title { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (title != null) {
				title.Dispose ();
				title = null;
			}

			if (photo != null) {
				photo.Dispose ();
				photo = null;
			}

			if (picturesCount != null) {
				picturesCount.Dispose ();
				picturesCount = null;
			}
		}
	}
}
