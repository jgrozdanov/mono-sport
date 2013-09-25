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
		MonoTouch.UIKit.UINavigationBar navBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView SportImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView SportImageToday { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SwitchCategory { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView SwitchTo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem Today { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TodayTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem Yesterday { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView YesterdayCategories { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton YesterdaySwitchCategory { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView YesterdayTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Categories != null) {
				Categories.Dispose ();
				Categories = null;
			}

			if (navBar != null) {
				navBar.Dispose ();
				navBar = null;
			}

			if (SportImage != null) {
				SportImage.Dispose ();
				SportImage = null;
			}

			if (SportImageToday != null) {
				SportImageToday.Dispose ();
				SportImageToday = null;
			}

			if (SwitchCategory != null) {
				SwitchCategory.Dispose ();
				SwitchCategory = null;
			}

			if (SwitchTo != null) {
				SwitchTo.Dispose ();
				SwitchTo = null;
			}

			if (Today != null) {
				Today.Dispose ();
				Today = null;
			}

			if (TodayTable != null) {
				TodayTable.Dispose ();
				TodayTable = null;
			}

			if (Yesterday != null) {
				Yesterday.Dispose ();
				Yesterday = null;
			}

			if (YesterdayTable != null) {
				YesterdayTable.Dispose ();
				YesterdayTable = null;
			}

			if (YesterdayCategories != null) {
				YesterdayCategories.Dispose ();
				YesterdayCategories = null;
			}

			if (YesterdaySwitchCategory != null) {
				YesterdaySwitchCategory.Dispose ();
				YesterdaySwitchCategory = null;
			}
		}
	}
}
