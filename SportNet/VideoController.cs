using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class VideoController : UITableViewController
	{
		public VideoController ()
		{
			var articles = new NewsCellModel[] {
				new NewsCellModel { Heading = "Button: I haven't lost my enthusiasm", Category = "Formula 1", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Transfer news: Luis Suarez rocks Liverpool with news he will submit a transfer request ", Category = "Liverpool", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Button: I haven't lost my enthusiasm", Category = "Formula 1", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Hulkenberg vows to keep pushing", Category = "Sauber", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Button: I haven't lost my enthusiasm", Category = "Formula 1", ImageSource = "./Assets/article-pic.jpg" },
				new NewsCellModel { Heading = "Cristiano Ronaldo", Category = "Football", ImageSource = "./Assets/article-pic.jpg" }
			};

			TableView.Source = new VideoControllerSource (articles);
			TableView.AddSubview (new UIRefreshControl ());
			TableView.ScrollsToTop = true;
			TableView.ContentInset = new UIEdgeInsets (0, 0, 10, 0);
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			this.View.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			this.AutomaticallyAdjustsScrollViewInsets = true;
		}
	}
}

