using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SportNet.Web.Models;
using Newtonsoft.Json;

namespace SportNet
{
	public class PicturesControllerSource : UITableViewSource
	{
		private List<GalleryItemModel> items;
		private NSString cellId = (NSString)"picturescell";
		private bool loading = false;
		public int NextPage { get; set; }
		public int CurrentCategory { get; set; }

		public PicturesControllerSource (List<GalleryItemModel> items, int category)
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

			if (indexPath.Row == 0) {
				var cell = tableView.DequeueReusableCell (cellId) as PicturesFeaturedCell;
				if (cell == null) {
					cell = new PicturesFeaturedCell (cellId);
				}
				cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
				cell.SetPicturesFeaturedCell (items [indexPath.Row].Title, items [indexPath.Row].Category, items [indexPath.Row].Thumbnail, 
				                              items [indexPath.Row].PicturesCount );
				return cell;


			} else {
				var cell = tableView.DequeueReusableCell (cellId) as PicturesControllerCell;
				if (cell == null) {
					cell = new PicturesControllerCell (cellId);
				}
				cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
				cell.SetPictureCell (items [indexPath.Row].Title, items [indexPath.Row].Category, items [indexPath.Row].Thumbnail, 
				                     items [indexPath.Row].PicturesCount);
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
						var data = (List<GalleryItemModel>)JsonConvert.DeserializeObject(e.Result, typeof(List<GalleryItemModel>));
						items.AddRange(new List<GalleryItemModel>(data));
						loading = false;
						var tabController = (MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController;
						((PicturesController)tabController.Pictures.TopView).TableView.ReloadData();
						NextPage++;
					});
				};
				request.Send (string.Format(RequestConfig.VideosPaged, CurrentCategory, NextPage), "GET");
				loading = true;
			}
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
			PicturesCollectionController gallery = (PicturesCollectionController)board.InstantiateViewController ("picturesCollectionController");

			var request = new RestRequest ();
			request.RequestFinished += (object sender, RequestEndedArgs e) => {
				InvokeOnMainThread(delegate {
					var data = (GalleryArticleModel)JsonConvert.DeserializeObject(e.Result, typeof(GalleryArticleModel));
					gallery.Items = data;
					gallery.Title = data.CategoryName;
					gallery.Spinner.StopAnimating ();
					gallery.CollectionView.ReloadData();
				});
			};
			request.Send (string.Format (RequestConfig.PicturesArticle, items [indexPath.Row].Id), "GET");

			((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).
				Pictures.InternalTopNavigation.PushViewController (gallery,true);
		}
	}
}

