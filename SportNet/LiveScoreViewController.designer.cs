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
	[Register ("LiveScoreViewController")]
	partial class LiveScoreViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView Categories { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel DateToday { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView SportImageToday { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SportToday { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SwitchCategory { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView SwitchTo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TodayTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Categories != null) {
				Categories.Dispose ();
				Categories = null;
			}

			if (SportImageToday != null) {
				SportImageToday.Dispose ();
				SportImageToday = null;
			}

			if (SportToday != null) {
				SportToday.Dispose ();
				SportToday = null;
			}

			if (DateToday != null) {
				DateToday.Dispose ();
				DateToday = null;
			}

			if (SwitchCategory != null) {
				SwitchCategory.Dispose ();
				SwitchCategory = null;
			}

			if (SwitchTo != null) {
				SwitchTo.Dispose ();
				SwitchTo = null;
			}

			if (TodayTable != null) {
				TodayTable.Dispose ();
				TodayTable = null;
			}
		}
	}
}
