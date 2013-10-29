using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Newtonsoft.Json;
using SportNet.Web.Models;

namespace SportNet
{
	public class VideoController : UITableViewController
	{
		private UIRefreshControl refresh;
		private UIActivityIndicatorView spinner;

		public UIActivityIndicatorView Spinner 
		{
			get {
				return spinner;
			}
		}

		public VideoController ()
		{

		}

		private void getData()
		{
			// load the articles and the menu from the server on a background thread
			var request = new RestRequest ();
			request.RequestFinished += (object sender, RequestEndedArgs e) => {
				InvokeOnMainThread(delegate {
					var data = (CategoryVideoModel)JsonConvert.DeserializeObject(e.Result, typeof(CategoryVideoModel));
					var menuController = (MenuController)((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).Video.MenuViewLeft;

					// add 'all sports' item to the categories list
					if(data.Parent.Link == 0) {
						data.Categories.Insert(0, new CategoriesMenuModelItem { Name = "All Sports", Link = 0 });
					}
					else {
						data.Categories.Insert(0, new CategoriesMenuModelItem { Name = "Back" , Link = data.Parent.Link });
					}

					TableView.Source = new VideoControllerSource(data.News, data.CategoryId);
					menuController.TableView.Source = new MenuControllerSource(data.Categories, "video");
					menuController.TableView.ReloadData();
					TableView.ReloadData();
					spinner.StopAnimating();
				});
			};
			request.Send (string.Format(RequestConfig.Videos, 0, 0), "GET");
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			spinner = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge);
			spinner.Center = new PointF (160, 160);
			spinner.HidesWhenStopped = true;
			TableView.AddSubview (spinner);
			spinner.StartAnimating ();

			// video controller specific adjustments
			TableView.ContentInset = new UIEdgeInsets (0, 0, 10, 0);
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			this.View.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			if(((AppDelegate)UIApplication.SharedApplication.Delegate).IsSeven) {
				this.AutomaticallyAdjustsScrollViewInsets = true;
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			refresh = new UIRefreshControl ();
			TableView.AddSubview (refresh);
			refresh.ValueChanged += (object sender, EventArgs e) => {
				getData();
				refresh.EndRefreshing();
			};

			TableView.ScrollsToTop = true;
			getData ();
		}
	}
}

