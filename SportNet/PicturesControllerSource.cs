using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class PicturesControllerSource : UITableViewSource
	{
		private PicturesCellModel[] items;
		private NSString cellId = (NSString)"picturescell";

//		public PicturesControllerSource ()
//		{
//		}
		public PicturesControllerSource (PicturesCellModel[] items)
		{
			this.items = items;
		}
		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

			if (indexPath.Row == 0) {
				var cell = tableView.DequeueReusableCell (cellId) as PicturesFeaturedCell;
				if (cell == null) {
					cell = new PicturesFeaturedCell (cellId);
				}
				cell.SetPicturesFeaturedCell (items [indexPath.Row].Heading, items [indexPath.Row].Category, items [indexPath.Row].ImageSource, 
				                              items [indexPath.Row].PhotoSource, items [indexPath.Row].PicturesCount );
				return cell;


			} else {
				var cell = tableView.DequeueReusableCell (cellId) as PicturesControllerCell;
				if (cell == null) {
					cell = new PicturesControllerCell (cellId);
				}
				cell.SetPictureCell (items [indexPath.Row].Heading, items [indexPath.Row].Category, items [indexPath.Row].ImageSource, 
				                     items [indexPath.Row].PhotoSource, items [indexPath.Row].PicturesCount);
				return cell;


			}
		}
		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row == 0) 
				return 285f;
			else
				return 120f;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			// ignore the first row because an event handler is attached
			// to the featured article vie
			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
			PicturesCollectionController gallery = (PicturesCollectionController)board.InstantiateViewController ("picturesCollectionController");
			gallery.ImageSources = new string[items [indexPath.Row].PicturesCount];
			gallery.Title = items [indexPath.Row].Category;
			gallery.HeadLine = items [indexPath.Row].Heading;
			gallery.NumberOfPictures = string.Format("{0}", items [indexPath.Row].PicturesCount);
		

			((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).
				Pictures.InternalTopNavigation.PushViewController (gallery,true);
		}

	}
}

