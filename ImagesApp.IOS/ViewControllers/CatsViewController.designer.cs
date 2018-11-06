// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ImagesApp.IOS.ViewControllers
{
    [Register ("CatsViewController")]
    partial class CatsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scroll { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView stackView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (scroll != null) {
                scroll.Dispose ();
                scroll = null;
            }

            if (stackView != null) {
                stackView.Dispose ();
                stackView = null;
            }
        }
    }
}