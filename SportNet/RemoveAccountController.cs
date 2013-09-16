// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace SportNet
{
	public partial class RemoveAccountController : UIViewController
	{
		public RemoveAccountController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewWillAppear (bool animated)
		{
			this.Submit.SetBackgroundImage(UIImage.FromFile ("./Assets/buttonlongwhite.png"), UIControlState.Normal);

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

			this.PasswordTextField.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};

		}
	}
}