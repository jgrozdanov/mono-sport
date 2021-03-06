// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace SportNet
{
	public partial class NotificationsController : UIViewController
	{
		public NotificationsController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewWillAppear (bool animated)
		{
			this.GetNotifications.SetBackgroundImage(UIImage.FromFile ("./Assets/settings-unchecked.png"), UIControlState.Normal);
			this.BreakingStories.SetBackgroundImage(UIImage.FromFile ("./Assets/settings-unchecked.png"), UIControlState.Normal);
			this.NewSources.SetBackgroundImage(UIImage.FromFile ("./Assets/settings-unchecked.png"), UIControlState.Normal);
			this.LiveScoreEvents.SetBackgroundImage(UIImage.FromFile ("./Assets/settings-unchecked.png"), UIControlState.Normal);
			this.Divider.Image = UIImage.FromFile ("./Assets/divider.png");


			var button = new UIBarButtonItem ("Back", UIBarButtonItemStyle.Plain, null);
			var custom = new UIButton (new RectangleF (0, 0, 26, 15));
			custom.SetBackgroundImage(UIImage.FromFile("./Assets/back.png"), UIControlState.Normal);
			custom.TouchUpInside += (sender, e) => NavigationController.PopViewControllerAnimated (true);
			button.CustomView = custom;

			this.NavigationItem.LeftBarButtonItem = button;
			this.NavigationController.SetNavigationBarHidden (false, false);

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}
	}
}
