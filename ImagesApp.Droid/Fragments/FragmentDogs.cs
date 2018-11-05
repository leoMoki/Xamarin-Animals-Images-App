using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using ImagesApp.Droid.Common;
using ImagesApp.Services.Config;
using ImagesApp.Services.Models;
using ImagesApp.Services.Services;
using Plugin.Connectivity;

namespace ImagesApp.Droid.Fragments
{
    public class FragmentDogs : Fragment
    {
        LinearLayout llImages;
        AppCompatTextView txtTitle;

        public static FragmentDogs NewInstance()
        {
            return new FragmentDogs { Arguments = new Bundle() };
        }

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            List<Dogs> lstCats = await GetDogs();
            
            GetDogsImages(lstCats);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_dogs, container, false);

            llImages = view.FindViewById<LinearLayout>(Resource.Id.llImages);

            txtTitle = view.FindViewById<AppCompatTextView>(Resource.Id.txtTitle);

            txtTitle.Text = GetString(Resource.String.dogs);

            return view;
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

        private async void GetDogsImages(List<Dogs> lstCats)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                ImageCommon imageCommon = new ImageCommon();

                foreach (var cat in lstCats)
                {
                    //loading para cada foto enquanto carrega
                    ProgressBar progress = new ProgressBar(Context);
                    llImages.AddView(progress);

                    string urlFoto = cat.url;
                    var bitmap = await imageCommon.GetImageBitmapFromUrlAsync(urlFoto);

                    //Criando o imageView para ser adicionado ao LinearLayout Dinamicamente
                    AppCompatImageView imgView = new AppCompatImageView(Context);
                    imgView.SetImageBitmap(bitmap);
                    imgView.SetPadding(20, 20, 20, 20);

                    //Adicionado o imageView ao LinearLayout
                    llImages.AddView(imgView);

                    //retira o loading
                    llImages.RemoveView(progress);


                }
            }
        }

        

    }
}