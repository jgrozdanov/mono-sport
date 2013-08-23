// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SportNet
{
	[Register ("StartReadingView")]
	partial class StartReadingView
	{
		[Outlet]
		public MonoTouch.UIKit.UIButton StartReading { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StartReading != null) {
				StartReading.Dispose ();
				StartReading = null;
			}
		}
	}
}
