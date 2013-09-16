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
	[Register ("AboutAppController")]
	partial class AboutAppController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView BackgroundView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Facebook { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GooglePlus { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Policy { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView ScrollableArea { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton TermsOfUse { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Twitter { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton WriteReview { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BackgroundView != null) {
				BackgroundView.Dispose ();
				BackgroundView = null;
			}

			if (Facebook != null) {
				Facebook.Dispose ();
				Facebook = null;
			}

			if (GooglePlus != null) {
				GooglePlus.Dispose ();
				GooglePlus = null;
			}

			if (Policy != null) {
				Policy.Dispose ();
				Policy = null;
			}

			if (ScrollableArea != null) {
				ScrollableArea.Dispose ();
				ScrollableArea = null;
			}

			if (TermsOfUse != null) {
				TermsOfUse.Dispose ();
				TermsOfUse = null;
			}

			if (Twitter != null) {
				Twitter.Dispose ();
				Twitter = null;
			}

			if (WriteReview != null) {
				WriteReview.Dispose ();
				WriteReview = null;
			}
		}
	}
}
