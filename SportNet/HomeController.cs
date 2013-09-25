// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public partial class HomeController : UITableViewController
	{
		private UIRefreshControl refresh;

		public HomeController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			var featured = new NewsCellModel[] {
				new NewsCellModel { Heading = "Tiger Woods Will End Weekend Woes with PGA Championship Victory", Category = "Golf", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Cristiano Ronaldo", Category = "Football", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Button: I haven't lost my enthusiasm", Category = "Formula 1", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Transfer news: Lyon doubt Newcastle's Bafetimbi Gomis deal will be completed", Category = "Football", ImageSource = "./Assets/article-pic.jpg" }
			};
			var leagues = new PreferenceModel[] {
				new PreferenceModel() { Title = "Spain", HasChild = true, Selected = false },
				new PreferenceModel() { Title = "France", HasChild = false, Selected = false },
				new PreferenceModel() { Title = "Italy", HasChild = true, Selected = false },
				new PreferenceModel() { Title = "Spain", HasChild = true, Selected = true },
				new PreferenceModel() { Title = "France", HasChild = false, Selected = false },
				new PreferenceModel() { Title = "Italy", HasChild = true, Selected = false },
				new PreferenceModel() { Title = "Spain", HasChild = true, Selected = false },
				new PreferenceModel() { Title = "France", HasChild = false, Selected = false },
				new PreferenceModel() { Title = "Italy", HasChild = true, Selected = false },
				new PreferenceModel() { Title = "Spain", HasChild = true, Selected = false },
				new PreferenceModel() { Title = "France", HasChild = false, Selected = false },
				new PreferenceModel() { Title = "Italy", HasChild = true, Selected = false }
			};

			this.TableView.Source = new HomeControllerSource (featured, leagues);
			refresh = new UIRefreshControl ();
			TableView.AddSubview (refresh);
			TableView.ScrollsToTop = true;
			// ios7 shit
			//TableView.ContentInset = new UIEdgeInsets (0, 0, 10, 0);
			this.AutomaticallyAdjustsScrollViewInsets = true;
		}
	}
}