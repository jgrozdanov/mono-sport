using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SportNet.Web.Models;
using Newtonsoft.Json;

namespace SportNet
{
	public class VideoControllerSource : UITableViewSource
	{
		private List<VideoModelItem> items;
		private NSString cellId = (NSString)"videocell";
		private bool loading = false;
		public int NextPage { get; set; }
		public int CurrentCategory { get; set; }

		public VideoControllerSource (List<VideoModelItem> items, int category)
		{
			this.items = items;
			NextPage = 1;
			CurrentCategory = category;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId) as VideoCell;
			if (cell == null) {
				cell = new VideoCell (cellId);
			}
			cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			cell.SetVideoCell (items [indexPath.Row].Title, items [indexPath.Row].Category, items [indexPath.Row].Thumbnail);
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
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
			webView.LoadRequest (new NSUrlRequest (new NSUrl (string.Format(RequestConfig.Video, items[indexPath.Row].Id))));
			webViewController.View = webView;
			webViewController.Title = items[indexPath.Row].Category;
			webView.LoadFinished += (object sender, EventArgs e) => {
				spinner.StopAnimating();
			};

			((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).
				Video.InternalTopNavigation.PushViewController (webViewController,true);

			tableView.DeselectRow (indexPath, true);
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 171f;
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
						var data = (List<VideoModelItem>)JsonConvert.DeserializeObject(e.Result, typeof(List<VideoModelItem>));
						items.AddRange(new List<VideoModelItem>(data));
						loading = false;
						var tabController = (MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController;
						((VideoController)tabController.Video.TopView).TableView.ReloadData();
						NextPage++;
					});
				};
				request.Send (string.Format(RequestConfig.VideosPaged, CurrentCategory, NextPage), "GET");
				loading = true;
			}
		}
	}
}

