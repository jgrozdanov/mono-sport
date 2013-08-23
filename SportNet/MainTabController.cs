using System;
using MonoTouch.UIKit;
using MonoTouch.SlideoutNavigation;
using System.Drawing;

namespace SportNet
{
	public class MainTabController : UITabBarController
	{
		private SlideoutNavigationController news;
		private UIViewController pictures; 
		private SlideoutNavigationController video;
		private NewsController table;

		public SlideoutNavigationController News {
			get 
			{
				return news;
			}
		}

		public MainTabController ()
		{
			news = new SlideoutNavigationController ();

			// instantiate the table view from the storyboard
			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
			table = (NewsController)board.InstantiateViewController ("newscontroller");
			var menu = (MenuController)board.InstantiateViewController ("menucontroller");
			news.TopView = table;
			news.MenuViewLeft = menu;

			pictures = new UIViewController ();

			video = new SlideoutNavigationController ();
			menu = (MenuController)board.InstantiateViewController ("menucontroller");
			video.TopView = new VideoController ();
			video.MenuViewLeft = menu;
			video.DisplayNavigationBarOnLeftMenu = false;

			ViewControllers = new UIViewController[] { news, pictures, video };
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

			// Global appearance properties
			UINavigationBar.Appearance.SetTitleTextAttributes 
				(new UITextAttributes { TextColor = UIColor.FromRGB(102, 102, 102) });
			UITabBar.Appearance.BackgroundImage = UIImage.FromFile ("./Assets/tabbar.png");
			UITabBar.Appearance.SelectionIndicatorImage = UIImage.FromFile ("./Assets/tabselection.png");

			news.TabBarItem = new UITabBarItem ();
			news.TabBarItem.Title = "News";
			news.TabBarItem.SetFinishedImages (UIImage.FromFile("./Assets/news-active.png"),
			                                      UIImage.FromFile("./Assets/news.png"));

			pictures.TabBarItem = new UITabBarItem ();
			pictures.TabBarItem.Title = "Pictures";
			pictures.TabBarItem.SetFinishedImages (UIImage.FromFile("./Assets/pictures-active.png"),
			                                       UIImage.FromFile("./Assets/pictures.png"));

			video.TabBarItem = new UITabBarItem ();
			video.TabBarItem.Title = "Video";
			video.TabBarItem.SetFinishedImages (UIImage.FromFile("./Assets/video-active.png"),
			                                       UIImage.FromFile("./Assets/video.png"));

			table.View.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			table.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
		}
	}
}

