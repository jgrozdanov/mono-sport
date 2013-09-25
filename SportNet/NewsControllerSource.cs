using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace SportNet
{
	public class NewsControllerSource : UITableViewSource
	{
		private NewsCellModel[] items;
		private NewsCellModel[] featured;
		private NSString cellIdentifier = (NSString)"taskcell";
		private bool loading;

		public NewsControllerSource (NewsCellModel[] items, NewsCellModel[] featured)
		{
			this.items = items;
			this.featured = featured;
		}

		public override int RowsInSection(UITableView tableView, int section)
		{
			// all the items + the featured articles cell
			return items.Length + 1;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row != 0) {
				var cell = tableView.DequeueReusableCell (cellIdentifier) as NewsCell;
				if (cell == null) {
					cell = new NewsCell (cellIdentifier);
				}
				// set the cell props
				// we subtract one from the index because of the featured cell
				cell.SetNewsCell (items [indexPath.Row - 1].Heading, items [indexPath.Row - 1].Category, 
				                  items [indexPath.Row - 1].ImageSource);
				cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
				return cell;
			} else {
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

		public NewsCellModel GetItem(int id)
		{
			// the first row is populated from another collection
			return items[id - 1];
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			// ignore the first row because an event handler is attached
			// to the featured article view
			if (indexPath.Row == 0) {
				return;
			}
			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
			NewsDetailController article = (NewsDetailController)board.InstantiateViewController ("newsdetail");
			article.Data = GetItem (indexPath.Row);
			((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).
				News.InternalTopNavigation.PushViewController (article,true);

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
				new UIAlertView("Loading...", "hold on", null, "OK", null).Show();
				loading = true;
			}
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row == 0) {
				return 300;
			} else {
				return 120;
			}
		}
	}
}

