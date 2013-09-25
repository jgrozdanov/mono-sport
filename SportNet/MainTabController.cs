using System;
using MonoTouch.UIKit;
using MonoTouch.SlideoutNavigation;
using System.Drawing;

namespace SportNet
{
	public class MainTabController : UITabBarController
	{
		private SlideoutNavigationController news;
		private SlideoutNavigationController pictures; 
		private SlideoutNavigationController video;
		private UITableViewController tableNews;
		private PicturesController tablePictures;
		private UINavigationController liveScore;

		public SlideoutNavigationController News {
			get 
			{
				return news;
			}
		}

		public SlideoutNavigationController Pictures {
			get 
			{
				return pictures;
			}
		}

		public MainTabController ()
		{
			news = new SlideoutNavigationController ();

			// instantiate the table view from the storyboard
			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
			// dashboard if some favourites saved otherwise the plain
			// table view
			if (((AppDelegate)UIApplication.SharedApplication.Delegate).HasPreferences) {
				tableNews = (HomeController)board.InstantiateViewController ("homecontroller");
			} 
			else {
				tableNews = (NewsController)board.InstantiateViewController ("newscontroller");
			}

			var menu = (MenuController)board.InstantiateViewController ("menucontroller");
			news.TopView = tableNews;
			news.MenuViewLeft = menu;

			pictures = new SlideoutNavigationController ();
			//tablePictures = (PicturesController)board.InstantiateViewController ("picturesController");
			tablePictures = new PicturesController ();
			menu = (MenuController)board.InstantiateViewController ("menucontroller");
			pictures.TopView = tablePictures;
			pictures.MenuViewLeft = menu;
			pictures.DisplayNavigationBarOnLeftMenu = false;

			liveScore = new UINavigationController ();
			LiveScoreViewController liveScoreScroll = (LiveScoreViewController)board.InstantiateViewController ("lscv");
			liveScore.PushViewController(liveScoreScroll, false);
			liveScore.NavigationBar.BarTintColor = UIColor.Black;

			video = new SlideoutNavigationController ();
			menu = (MenuController)board.InstantiateViewController ("menucontroller");
			video.TopView = new VideoController ();
			video.MenuViewLeft = menu;
			video.DisplayNavigationBarOnLeftMenu = false;

			ViewControllers = new UIViewController[] { news, pictures, video, liveScore };
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			news.LayerShadowing = true;
			news.DisplayNavigationBarOnLeftMenu = false;

			// set the logo in the navbar
			var imgView = new UIImageView { Image = UIImage.FromFile ("./Assets/logo.png") };
			imgView.Frame = new System.Drawing.RectangleF (0, 0, 40, 40);
			imgView.ContentMode = UIViewContentMode.ScaleAspectFit;
			news.TopView.NavigationItem.TitleView = imgView;

			imgView = new UIImageView { Image = UIImage.FromFile ("./Assets/logo.png") };
			imgView.Frame = new System.Drawing.RectangleF (0, 0, 40, 40);
			imgView.ContentMode = UIViewContentMode.ScaleAspectFit;
			video.TopView.NavigationItem.TitleView = imgView;

			imgView = new UIImageView { Image = UIImage.FromFile ("./Assets/logo.png") };
			imgView.Frame = new System.Drawing.RectangleF (0, 0, 40, 40);
			imgView.ContentMode = UIViewContentMode.ScaleAspectFit;
			pictures.TopView.NavigationItem.TitleView = imgView;

			// Global appearance properties
			UINavigationBar.Appearance.SetTitleTextAttributes 
				(new UITextAttributes { TextColor = UIColor.FromRGB(102, 102, 102) });
			UIBarButtonItem.Appearance.TintColor = UIColor.White;
			//UITabBar.Appearance.BackgroundImage = UIImage.FromFile ("./Assets/tabbar.png");
			//UITabBar.Appearance.SelectionIndicatorImage = UIImage.FromFile ("./Assets/tabselection.png");
			UITabBar.Appearance.BarTintColor = UIColor.Black;
			UITabBar.Appearance.TintColor = UIColor.White;

			news.TabBarItem = new UITabBarItem ("News", UIImage.FromFile ("./Assets/news-active.png"), UIImage.FromFile ("./Assets/news.png"));
			pictures.TabBarItem = new UITabBarItem ("Pictures", UIImage.FromFile("./Assets/pictures-active.png"), UIImage.FromFile("./Assets/pictures.png"));
			video.TabBarItem = new UITabBarItem ("Video", UIImage.FromFile("./Assets/video-active.png"), UIImage.FromFile("./Assets/video.png"));
			liveScore.TabBarItem = new UITabBarItem ("Livescore", UIImage.FromFile("./Assets/livescore-active.png"), UIImage.FromFile("./Assets/livescore.png"));

			tableNews.View.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			tableNews.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			tablePictures.View.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			tablePictures.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
		}
	}
}

