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
	[Register ("NotificationsController")]
	partial class NotificationsController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton BreakingStories { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Divider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GetNotifications { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton LiveScoreEvents { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton NewSources { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BreakingStories != null) {
				BreakingStories.Dispose ();
				BreakingStories = null;
			}

			if (Divider != null) {
				Divider.Dispose ();
				Divider = null;
			}

			if (GetNotifications != null) {
				GetNotifications.Dispose ();
				GetNotifications = null;
			}

			if (LiveScoreEvents != null) {
				LiveScoreEvents.Dispose ();
				LiveScoreEvents = null;
			}

			if (NewSources != null) {
				NewSources.Dispose ();
				NewSources = null;
			}
		}
	}
}
