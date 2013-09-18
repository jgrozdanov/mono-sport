// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface LiveScoreViewController : UIViewController {
	UINavigationBar *_navBar;
	UIImageView *_SportImage;
	UIImageView *_SportImageToday;
	UIScrollView *_SwitchTo;
	UIBarButtonItem *_Today;
	UITableView *_TodayTable;
	UIBarButtonItem *_Yesterday;
	UITableView *_YesterdayTable;
}

@property (nonatomic, retain) IBOutlet UINavigationBar *navBar;

@property (nonatomic, retain) IBOutlet UIImageView *SportImage;

@property (nonatomic, retain) IBOutlet UIImageView *SportImageToday;

@property (nonatomic, retain) IBOutlet UIScrollView *SwitchTo;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *Today;

@property (nonatomic, retain) IBOutlet UITableView *TodayTable;

@property (nonatomic, retain) IBOutlet UIBarButtonItem *Yesterday;

@property (nonatomic, retain) IBOutlet UITableView *YesterdayTable;

@end
