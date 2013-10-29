using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;
using SportNet.Web.Models;

namespace SportNet
{
	public class FeaturedCell : UITableViewCell
	{
		private class TouchView : UIView 
		{
			public int Index { get; set; }
			public int SmallId { get; set; } 
			public string Category { get; set; }

			public override void TouchesEnded (NSSet touches, UIEvent evt)
			{
				base.TouchesEnded (touches, evt);

//				UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
//				NewsDetailController article = (NewsDetailController)board.InstantiateViewController ("newsdetail");

				var webViewController = new UIViewController ();
				var button = new UIBarButtonItem ("Back", UIBarButtonItemStyle.Plain, null);

				var custom = new UIButton (new RectangleF (0, 0, 26, 15));
				custom.SetBackgroundImage(UIImage.FromFile("./Assets/back.png"), UIControlState.Normal);
				custom.TouchUpInside += (sender, e) => webViewController.NavigationController.PopViewControllerAnimated (true);
				button.CustomView = custom;
				webViewController.NavigationItem.LeftBarButtonItem = button;

				var webView = new UIWebView (Window.Bounds);
				webView.Opaque = false;
				webView.BackgroundColor = UIColor.Black;
				webView.LoadRequest (new NSUrlRequest (new NSUrl (string.Format(RequestConfig.Article, SmallId))));
				webViewController.View = webView;
				webViewController.Title = Category;

				((MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController).
					News.InternalTopNavigation.PushViewController (webViewController,true);
			}
		} 

		// article holder
		private class FeaturedArticle
		{
			public TouchView Article { get; set; }
			public UIView HeadingView { get; set; }
			public UILabel Heading { get; set; }
			public UILabel Category { get; set; }
			public UIImageView Image { get; set; }

			public FeaturedArticle() 
			{
				Article = new TouchView();
				HeadingView = new UIView();

				Heading = new UILabel();
				Heading.TextColor = UIColor.White;
				Heading.Font = UIFont.FromName ("Helvetica-Bold", 17f);
				Heading.BackgroundColor = UIColor.Clear;
				Heading.Lines = 2;

				Category = new UILabel ();
				Category.TextColor = UIColor.Red;
				Category.Font = UIFont.FromName ("Helvetica", 12f);
				Category.BackgroundColor = UIColor.Clear;

				Image = new UIImageView ();
				Image.ContentMode = UIViewContentMode.ScaleAspectFill;
				Image.ClipsToBounds = true;

				HeadingView.BackgroundColor = UIColor.FromRGBA (0, 0, 0, 120);

				HeadingView.AddSubview(Heading);
				HeadingView.AddSubview(Category);
				Article.AddSubview(Image);
				Article.AddSubview(HeadingView);
			}

			public void SetFeaturedArticle(NewsModelItem item)
			{
				this.Heading.Text = item.Title;
				this.Category.Text = item.Category;
				AppDelegate.MakeImageFromURL (this.Image, item.Img);
				Article.SmallId = item.SmallId;
				Article.Category = item.Category;
			}
		}

		private FeaturedArticle[] articles;
		private UIScrollView scrollView;
		private UIPageControl pageControl;

		public FeaturedCell (NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;
			articles = new FeaturedArticle[4];
			scrollView = new UIScrollView ();
			pageControl = new UIPageControl ();
			for (int i = 0; i < 4; i++) {
				articles [i] = new FeaturedArticle ();
				scrollView.AddSubview (articles [i].Article);
			}
			scrollView.PagingEnabled = true;
			scrollView.ShowsHorizontalScrollIndicator = false;

			ContentView.AddSubview (scrollView);
			ContentView.AddSubview (pageControl);
		}

		public void SetFeaturedCell(List<NewsModelItem> items)
		{
			int i = 0;
			foreach(var item in items) {
				articles [i].SetFeaturedArticle (item);
				i++;
			}
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			float scrollOffset = ((AppDelegate)UIApplication.SharedApplication.Delegate).FeaturedScrollOffset;
			scrollView.ScrollsToTop = false;
			scrollView.Frame = new RectangleF(18, 10, ContentView.Bounds.Width - 36, ContentView.Bounds.Height - 20);
			scrollView.ContentSize = new SizeF ((ContentView.Bounds.Width - 36) * 4, ContentView.Bounds.Height - 20);
			scrollView.SetContentOffset (new PointF (scrollOffset, 0), true);
			scrollView.Scrolled += (object sender, EventArgs e) => {
				var pageWidth = scrollView.Frame.Size.Width;
				var fractionalPage = scrollView.ContentOffset.X / pageWidth;
				pageControl.CurrentPage = Convert.ToInt32(fractionalPage);
				((AppDelegate)UIApplication.SharedApplication.Delegate).FeaturedScrollOffset = scrollView.ContentOffset.X;
			};

			pageControl.Frame = new RectangleF (ContentView.Bounds.Width / 2 - 25, 0, 50, 30);
			pageControl.Pages = 4;
			pageControl.CurrentPage = Convert.ToInt32(scrollOffset / scrollView.Frame.Size.Width);
			pageControl.CurrentPageIndicatorTintColor = UIColor.Red;
			pageControl.PageIndicatorTintColor = UIColor.FromRGB (102, 102, 102);

			float positionLeft = 0;
			for (int i = 0; i < 4; i++) {
				articles[i].Article.Frame = new RectangleF (positionLeft, 20, ContentView.Bounds.Width - 36, ContentView.Bounds.Height - 20);
				articles[i].Image.Frame = new RectangleF (0, 0, ContentView.Bounds.Width - 36, ContentView.Bounds.Height - 20);
				articles[i].HeadingView.Frame = new RectangleF (0, 180, ContentView.Bounds.Width - 36, 80);
				articles[i].Category.Frame = new RectangleF(18, 10, ContentView.Bounds.Width - 36, 12);
				articles[i].Heading.Frame = new RectangleF(18, 23, ContentView.Bounds.Width - 56, 16);
				articles[i].Heading.SizeToFit ();
				positionLeft += (ContentView.Bounds.Width - 36);
			}
		}
	}
}

