using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SportNet.Web.Models;

namespace SportNet
{
	public class HomeControllerSource : UITableViewSource
	{
		private List<NewsModelItem> featured;
		List<CategoriesMenuModelItem> items;
		private NSString cellId = (NSString)"homecell";
		private NSString featuredCellId = (NSString)"featuredcell";

		public HomeControllerSource (List<NewsModelItem> feat, List<CategoriesMenuModelItem> cats)
		{
			featured = feat;
			items = cats;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Count + 1;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row != 0) {
				var cell = tableView.DequeueReusableCell (cellId);
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
				}
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				cell.TextLabel.Text = items [indexPath.Row - 1].Name;
				cell.TextLabel.Font = UIFont.FromName ("Helvetica-Bold", 14f);
				cell.TextLabel.TextColor = UIColor.White;
				cell.TextLabel.BackgroundColor = UIColor.Clear;
				cell.ContentView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("./Assets/cell.png"));
			
				return cell;
			} 
			else {
				var cell = tableView.DequeueReusableCell(featuredCellId) as FeaturedCell;
				if (cell == null) {
					cell = new FeaturedCell (featuredCellId);
				}
				cell.SetFeaturedCell (featured);
				cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
				return cell;
			}
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
			var tableNews = (NewsController)board.InstantiateViewController ("newscontroller");
			tableNews.Category = items [indexPath.Row - 1].Link;
			tableNews.Title = items [indexPath.Row - 1].Name;

			var button = new UIBarButtonItem ("Back", UIBarButtonItemStyle.Plain, null);
			var custom = new UIButton (new RectangleF (0, 0, 26, 15));
			custom.SetBackgroundImage(UIImage.FromFile("./Assets/back.png"), UIControlState.Normal);
			custom.TouchUpInside += (sender, e) => tableNews.NavigationController.PopViewControllerAnimated (true);
			button.CustomView = custom;
			tableNews.NavigationItem.LeftBarButtonItem = button;

			((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).
				News.InternalTopNavigation.PushViewController (tableNews,true);
			tableView.DeselectRow (indexPath, true);
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row == 0) {
				return 300;
			} else {
				return 44;
			}
		}
	}
}

