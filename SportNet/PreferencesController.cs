// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SportNet.Web.Models;
using Newtonsoft.Json;

namespace SportNet
{
	public partial class PreferencesController : UICollectionViewController
	{
		private UIActivityIndicatorView spinner;
		private bool attached;

		public PreferencesController (IntPtr handle) : base (handle)
		{
			spinner = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge);
			spinner.Center = new PointF (160, 160);
			spinner.HidesWhenStopped = true;
			CollectionView.AddSubview (spinner);
			spinner.StartAnimating ();
			attached = false;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			CollectionView.RegisterClassForCell (typeof(PreferenceCell), PreferenceCell.CellId);
			this.CollectionView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			this.CollectionView.AllowsMultipleSelection = true;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var request = new RestRequest ();
			request.RequestFinished += (object sender, RequestEndedArgs e) => {
				var data = (AddContentModel)JsonConvert.DeserializeObject(e.Result, typeof(AddContentModel));
				InvokeOnMainThread(delegate {
					AppDelegate.MainCategories = data;
					CollectionView.ReloadData();
					spinner.StopAnimating();
				});
			};
			request.Send (string.Format (RequestConfig.MainCategories, AppDelegate.GetProfileId ()), "GET");
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (PreferenceCell)collectionView.DequeueReusableCell (PreferenceCell.CellId, indexPath);
			AppDelegate.MakeImageFromURL (cell.Image, "http://www.sport.net" + AppDelegate.MainCategories.Categories [indexPath.Row].Thumb);
			cell.Category = AppDelegate.MainCategories.Categories[indexPath.Row].Name;
			cell.SetCellState (AppDelegate.MainCategories.Categories [indexPath.Row].Checked);
			return cell;
		}

		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			return AppDelegate.MainCategories.Categories.Count;
		}

		public override UICollectionReusableView GetViewForSupplementaryElement (UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
		{
			if (elementKind == (NSString)"UICollectionElementKindSectionHeader") {
				return (UICollectionReusableView)collectionView.DequeueReusableSupplementaryView 
					(UICollectionElementKindSection.Header, (NSString)"collectionheader", indexPath);
			} else {
				StartReadingView footer = (StartReadingView)collectionView.DequeueReusableSupplementaryView 
					(UICollectionElementKindSection.Footer, (NSString)"collectionfooter", indexPath);
				footer.StartReading.SetBackgroundImage (UIImage.FromFile ("./Assets/buttonlong.png"), UIControlState.Normal);
				if (!attached) {
					footer.StartReading.TouchUpInside += (object sender, EventArgs e) => {
						var tabbar = new MainTabController ();
						UIApplication.SharedApplication.Delegate.Window.RootViewController = tabbar;
					};
					attached = true;
				}
				return footer;
			}
		}

		public override void ItemSelected (UICollectionView collectionView, NSIndexPath indexPath)
		{
			//var cell = (PreferenceCell)collectionView.CellForItem (indexPath);
			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
			var prefs = (PreferencesSubController)board.InstantiateViewController ("preferencessub");
			prefs.CategoryId = AppDelegate.MainCategories.Categories [indexPath.Row].Id;
			prefs.ParentChecked = AppDelegate.MainCategories.Categories [indexPath.Row].Checked;
			prefs.Title = AppDelegate.MainCategories.Categories [indexPath.Row].Name;
			this.NavigationController.PushViewController (prefs, true);
		}
	}
}
