using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagesApp.IOS.Common;
using ImagesApp.Services.Config;
using ImagesApp.Services.Models;
using ImagesApp.Services.Services;
using Plugin.Connectivity;
using UIKit;

namespace ImagesApp.IOS.ViewControllers
{
    public partial class DogsViewController : UIViewController
    {
        public DogsViewController(IntPtr handle) : base(handle)
        {
        }

        public DogsViewController() : base("DogsViewController", null)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            List<Dogs> dogs = await GetDogs();

            GetDogsImages(dogs);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private async Task<List<Dogs>> GetDogs()
        {
            List<Dogs> result = null;

            ApiConfigDogs apiDogs = new ApiConfigDogs()
            {
                Params = new Params()
                {
                    Size = "full",
                    MimeType = "jpg",
                    Format = "json",
                    HasBreeds = false, //array vazio com ele true
                    Order = "RANDOM",
                    Page = 0,
                    Limit = 50
                }
            };

            //Metodo para montar a url com parametros
            string url = apiDogs.GetUrlParams(apiDogs.Params);

            DogsService service = new DogsService();

            result = await service.Get(url);

            return result;
        }

        private void GetDogsImages(List<Dogs> lstDogs)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                ImageCommon imageCommon = new ImageCommon();
                //ProgressBar progress = null;

                foreach (var dog in lstDogs)
                {

                    string urlFoto = dog.url;
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

