using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using ImagesApp.IOS.Common;
using ImagesApp.Services.Config;
using ImagesApp.Services.Models;
using ImagesApp.Services.Services;
using Plugin.Connectivity;
using UIKit;

namespace ImagesApp.IOS.ViewControllers
{
    public partial class CatsViewController : UIViewController
    {
        public CatsViewController(IntPtr handle) : base(handle)
        {
        }

        public CatsViewController() : base("CatsViewController", null)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            List<Cats> cats = await GetCat();

            GetCatsImages(cats);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private async Task<List<Cats>> GetCat()
        {
            List<Cats> result = null;

            ApiConfigCats apiCats = new ApiConfigCats()
            {
                Params = new Params()
                {
                    Size = "full",
                    MimeType = "jpg",
                    Format = "json",
                    HasBreeds = false, //array vazio com ele true
                    Order = "RANDOM",
                    Page = 0,
                    Limit = 25
                }
            };

            //Metodo para montar a url com parametros
            string url = apiCats.GetUrlParams(apiCats.Params);

            CatsService service = new CatsService();

            result = await service.Get(url);

            return result;
        }

        private void GetCatsImages(List<Cats> lstCats)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                ImageCommon imageCommon = new ImageCommon();
                //ProgressBar progress = null;

                foreach (var cat in lstCats)
                {

                    string urlFoto = cat.url;
                    UIImage foto = imageCommon.FromUrl(urlFoto);


                    UIImageView imageView = new UIImageView();
                    //UIImage image = Utilities.ToImage(item.ImageBytesArray);
                    imageView.Image = foto;
                    var screen = UIScreen.MainScreen.Bounds;
                    imageView.Frame = new CoreGraphics.CGRect(0, 400, screen.Size.Width, 300);
                    //mainStack.Add(imageView);

                    stackView.AddSubview(imageView);

                }
            }

        }



    }

}