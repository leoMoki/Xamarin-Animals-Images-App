using System;
using Foundation;
using UIKit;

namespace ImagesApp.IOS.Common
{
    public class ImageCommon
    {
        public UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }


    }
}
