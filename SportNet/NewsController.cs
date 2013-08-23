// This file has been autogenerated from parsing an Objective-C header file added in Xcode.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace SportNet
{
	public partial class NewsController : UITableViewController
	{
		private UIRefreshControl refresh;

		public NewsController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			var articles = new NewsCellModel[] {
				new NewsCellModel { Heading = "Button: I haven't lost my enthusiasm", Category = "Formula 1", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Transfer news: Luis Suarez rocks Liverpool with news he will submit a transfer request ", Category = "Liverpool", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Button: I haven't lost my enthusiasm", Category = "Formula 1", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Hulkenberg vows to keep pushing", Category = "Sauber", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Button: I haven't lost my enthusiasm", Category = "Formula 1", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Cristiano Ronaldo", Category = "Football", ImageSource = "./Assets/article-pic.jpg" }
			};
			var featured = new NewsCellModel[] {
				new NewsCellModel { Heading = "Tiger Woods Will End Weekend Woes with PGA Championship Victory", Category = "Golf", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Cristiano Ronaldo", Category = "Football", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Button: I haven't lost my enthusiasm", Category = "Formula 1", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Transfer news: Lyon doubt Newcastle's Bafetimbi Gomis deal will be completed", Category = "Football", ImageSource = "./Assets/article-pic.jpg" }
			};
			TableView.Source = new NewsControllerSource (articles, featured);
			refresh = new UIRefreshControl ();
			TableView.AddSubview (refresh);
			TableView.ScrollsToTop = true;
		}
	}
}
