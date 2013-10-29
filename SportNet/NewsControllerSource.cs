using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using SportNet.Web.Models;
using Newtonsoft.Json;

namespace SportNet
{
	public class NewsControllerSource : UITableViewSource
	{
		private List<NewsModelItem> items;
		private List<NewsModelItem> featured;
		private NSString cellIdentifier = (NSString)"taskcell";
		private bool loading = false;
		public int NextPage { get; set; }
		public int CurrentCategory { get; set; }

		public NewsControllerSource (List<NewsModelItem> items, List<NewsModelItem> featured, int currentCategory)
		{
			this.items = items;
			this.featured = featured;
			NextPage = 1;
			CurrentCategory = currentCategory;
		}

		public override int RowsInSection(UITableView tableView, int section)
		{
			// all the items + the featured articles cell
			return items.Count + 1;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row != 0) {
				var cell = tableView.DequeueReusableCell (cellIdentifier) as NewsCell;
				if (cell == null) {
					cell = new NewsCell (cellIdentifier);
				}

				if (!string.IsNullOrEmpty (items [indexPath.Row - 1].Img)) {
					// set the cell props
					// we subtract one from the index because of the featured cell
					cell.SetNewsCell (items [indexPath.Row - 1].Title, items [indexPath.Row - 1].Category, 
					                  items [indexPath.Row - 1].Img);

				} 
				else {
					cell.SetNewsCell (items [indexPath.Row - 1].Title, items [indexPath.Row - 1].Category, UIImage.FromFile("./Assets/imgholder.png"));
				}

				cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
				return cell;
			} 
			else {
				var cell = tableView.DequeueReusableCell(cellIdentifier) as FeaturedCell;
				if (cell == null) {
					cell = new FeaturedCell (cellIdentifier);
				}
				for (int i = 0; i < 4; i++) {
					cell.SetFeaturedCell (featured);
				}
				cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
				return cell;
			}
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			// ignore the first row because an event handler is attached
			// to the featured article view
			if (indexPath.Row == 0) {
				return;
			}

			// the non webview article version
			//UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
			//NewsDetailController article = (NewsDetailController)board.InstantiateViewController ("newsdetail");
			//article.Data = items[indexPath.Row - 1];

			// the webview article version
			var webViewController = new UIViewController ();
			var button = new UIBarButtonItem ("Back", UIBarButtonItemStyle.Plain, null);

			var custom = new UIButton (new RectangleF (0, 0, 26, 15));
			custom.SetBackgroundImage(UIImage.FromFile("./Assets/back.png"), UIControlState.Normal);
			custom.TouchUpInside += (sender, e) => webViewController.NavigationController.PopViewControllerAnimated (true);
			button.CustomView = custom;
			webViewController.NavigationItem.LeftBarButtonItem = button;

			var spinner = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge);
			spinner.Center = new PointF (160, 160);
			spinner.HidesWhenStopped = true;

			var webView = new UIWebView (tableView.Bounds);
			webView.Opaque = false;
			webView.BackgroundColor = UIColor.Black;
			webView.AddSubview (spinner);
			spinner.StartAnimating ();
			webView.LoadRequest (new NSUrlRequest (new NSUrl (string.Format(RequestConfig.Article, items[indexPath.Row - 1].SmallId))));
			webViewController.View = webView;
			webViewController.Title = items[indexPath.Row - 1].Category;
			webView.LoadFinished += (object sender, EventArgs e) => {
				spinner.StopAnimating();
			};

			((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).
				News.InternalTopNavigation.PushViewController (webViewController,true);

			tableView.DeselectRow (indexPath, true);
		}

		public override void Scrolled (UIScrollView scrollView)
		{
			if (loading) {
				return;
			}

			PointF offset = scrollView.ContentOffset;
			RectangleF bounds = scrollView.Bounds;
			SizeF size = scrollView.ContentSize;
			UIEdgeInsets inset = scrollView.ContentInset;

			float y = offset.Y + bounds.Size.Height - inset.Bottom;
			float h = size.Height;

			if(y > h - 50) {
				var request = new RestRequest ();

				request.RequestFinished += (object sender, RequestEndedArgs e) => {
					InvokeOnMainThread(delegate {
						var data = (List<NewsModelItem>)JsonConvert.DeserializeObject(e.Result, typeof(List<NewsModelItem>));
						items.AddRange(new List<NewsModelItem>(data));
						loading = false;
						var tabController = (MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController;
						((NewsController)tabController.News.TopView).TableView.ReloadData();
						NextPage++;
					});
				};
				request.Send (string.Format(RequestConfig.NewsPaged, CurrentCategory, NextPage), "GET");
				loading = true;
			}
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row == 0) {
				return 300;
			} 
			else {
				return 120;
			} 
		}
	}
}

