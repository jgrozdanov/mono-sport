// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace SportNet
{
	[Register ("NewsDetailController")]
	partial class NewsDetailController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel ArticleText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel Heading { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Image { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Heading != null) {
				Heading.Dispose ();
				Heading = null;
			}

			if (Image != null) {
				Image.Dispose ();
				Image = null;
			}

			if (ArticleText != null) {
				ArticleText.Dispose ();
				ArticleText = null;
			}
		}
	}
}
