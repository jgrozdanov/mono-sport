using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.SlideoutNavigation;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using SportNet.Web.Models;
using Newtonsoft.Json;

namespace SportNet
{
	public class MenuControllerSource : UITableViewSource
	{
		private List<CategoriesMenuModelItem> categories;
		private NSString cellid = (NSString)"category";
		private string controlled;

		public MenuControllerSource (List<CategoriesMenuModelItem> categories, string controlled)
		{
			this.categories = categories;
			this.controlled = controlled;
		}

		private void changeNewsCategory(NSIndexPath indexPath)
		{
			var controller = (SlideoutNavigationController)((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).News;
			var news = (NewsController)controller.TopView;
			var request = new RestRequest ();
			((NewsController)controller.TopView).Spinner.StartAnimating ();
			//controller.Hide ();

			request.RequestFinished += (object sender, RequestEndedArgs e) => {
				InvokeOnMainThread(delegate {
					var data = (CategoryModel)JsonConvert.DeserializeObject(e.Result, typeof(CategoryModel));
					var menuController = (MenuController)((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).News.MenuViewLeft;

					// slice the news list into featured and normal articles
					var featured = (List<NewsModelItem>)data.News;
					featured = featured.Where(c => !string.IsNullOrEmpty(c.Img)).Take(4).ToList();
					foreach(var i in featured) {
						data.News.Remove(i);
					}

					// add 'all sports' item to the categories list
					if(data.CategoryId == 0) {
						data.Categories.Insert(0, new CategoriesMenuModelItem { Name = "All Sports", Link = 0 });
					}
					else {
						data.Categories.Insert(0, new CategoriesMenuModelItem { Name = "Back" , Link = data.Parent.Link });
					}

					news.TableView.Source = new NewsControllerSource(data.News, featured, data.CategoryId);
					menuController.TableView.Source = new MenuControllerSource(data.Categories, "news");
					menuController.TableView.ReloadData();
					news.TableView.ReloadData();
					try {
						news.TableView.ScrollToRow(NSIndexPath.FromRowSection(0, 0), UITableViewScrollPosition.Top, false);
					}
					catch (Exception) {}
					news.Spinner.StopAnimating();
				});
			};
			request.Send(string.Format(RequestConfig.News(), categories[indexPath.Row].Link, 0), "GET");
		}

		private void changeVideoCategory(NSIndexPath indexPath)
		{
			var controller = (SlideoutNavigationController)((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).Video;
			var video = (VideoController)controller.TopView;
			var request = new RestRequest ();
			((VideoController)controller.TopView).Spinner.StartAnimating ();
			//controller.Hide ();

			request.RequestFinished += (object sender, RequestEndedArgs e) => {
				InvokeOnMainThread(delegate {
					var data = (CategoryVideoModel)JsonConvert.DeserializeObject(e.Result, typeof(CategoryVideoModel));
					var menuController = (MenuController)((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).Video.MenuViewLeft;

					// add 'all sports' item to the categories list
					if(data.CategoryId == 0) {
						data.Categories.Insert(0, new CategoriesMenuModelItem { Name = "All Sports", Link = 0 });
					}
					else {
						data.Categories.Insert(0, new CategoriesMenuModelItem { Name = "Back" , Link = data.Parent.Link });
					}

					video.TableView.Source = new VideoControllerSource(data.News, data.CategoryId);
					menuController.TableView.Source = new MenuControllerSource(data.Categories, "video");
					menuController.TableView.ReloadData();
					video.TableView.ReloadData();
					try {
						video.TableView.ScrollToRow(NSIndexPath.FromRowSection(0, 0), UITableViewScrollPosition.Top, false);
					}
					catch(Exception) {}
					video.Spinner.StopAnimating();
				});
			};
			request.Send(string.Format(RequestConfig.Videos, categories[indexPath.Row].Link, 0), "GET");
		}

		private void changePicturesCategory(NSIndexPath indexPath)
		{
			var controller = (SlideoutNavigationController)((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).Pictures;
			var pictures = (PicturesController)controller.TopView;
			var request = new RestRequest ();
			((PicturesController)controller.TopView).Spinner.StartAnimating ();
			//controller.Hide ();

			request.RequestFinished += (object sender, RequestEndedArgs e) => {
				InvokeOnMainThread(delegate {
					var data = (CategoryPicturesModel)JsonConvert.DeserializeObject(e.Result, typeof(CategoryPicturesModel));
					var menuController = (MenuController)((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).Pictures.MenuViewLeft;

					// add 'all sports' item to the categories list
					if(data.Parent.Link == 0) {
						data.Categories.Insert(0, new CategoriesMenuModelItem { Name = "All Sports", Link = 0 });
					}
					else {
						data.Categories.Insert(0, new CategoriesMenuModelItem { Name = "Back" , Link = data.Parent.Link });
					}

					pictures.TableView.Source = new PicturesControllerSource(data.News, data.CategoryId);
					menuController.TableView.Source = new MenuControllerSource(data.Categories, "pictures");
					menuController.TableView.ReloadData();
					pictures.TableView.ReloadData();
					pictures.Spinner.StopAnimating();
				});
			};
			request.Send (string.Format(RequestConfig.Pictures, categories[indexPath.Row].Link, 0), "GET");
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return categories.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellid);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellid);
			}
			cell.BackgroundColor = UIColor.Black;
			cell.ContentView.BackgroundColor = UIColor.Black;
			cell.TextLabel.BackgroundColor = UIColor.Clear;
			cell.TextLabel.Text = categories [indexPath.Row].Name;
			cell.TextLabel.Font = UIFont.FromName ("Helvetica-Bold", 17f);
			cell.TextLabel.TextColor = UIColor.FromRGB (102, 102, 102);
			cell.TextLabel.Frame = new RectangleF (60, 0, 100, 20);
			cell.SelectionStyle = UITableViewCellSelectionStyle.Gray;
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
			if (controlled == "news") {
				changeNewsCategory (indexPath);
			} 
			else if (controlled == "video") {
				changeVideoCategory (indexPath);
			} 
			else if (controlled == "pictures") {
				changePicturesCategory (indexPath);
			}
		}

		public override int IndentationLevel (UITableView tableView, NSIndexPath indexPath)
		{
			return 2;
		}
	}
}

