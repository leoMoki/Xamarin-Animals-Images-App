using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ImagesApp.Droid.Common;
using ImagesApp.Services.Config;
using ImagesApp.Services.Models;
using ImagesApp.Services.Services;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagesApp.Droid.Fragments
{
    public class FragmentCats : Fragment
    {
        LinearLayout llImages;
        AppCompatTextView txtTitle;

        public static FragmentCats NewInstance()
        {
            return new FragmentCats { Arguments = new Bundle() };
        }

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            List<Cats> lstCats = await GetCat();

            GetCatsImages(lstCats);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.fragment_cats, container, false);

            llImages = view.FindViewById<LinearLayout>(Resource.Id.llImages);
            txtTitle = view.FindViewById<AppCompatTextView>(Resource.Id.txtTitle);

            txtTitle.Text = GetString(Resource.String.cats);

            return view;
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

        private async void GetCatsImages(List<Cats> lstCats)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                ImageCommon imageCommon = new ImageCommon();
                //ProgressBar progress = null;

                foreach (var cat in lstCats)
                {
                    //loading para cada foto enquanto carrega
                    ProgressBar progress = new ProgressBar(Context);
                    llImages.AddView(progress);

                    string urlFoto = cat.url;
                    var bitmap = await imageCommon.GetImageBitmapFromUrlAsync(urlFoto);

                    //Criando o imageView para ser adicionado ao LinearLayout Dinamicamente
                    AppCompatImageView imgView = new AppCompatImageView(Context);
                    imgView.SetPadding(20, 20, 20, 20);
                    imgView.SetImageBitmap(bitmap);

                    //Adicionado o imageView ao LinearLayout
                    llImages.AddView(imgView);

                    //retira o loading
                    llImages.RemoveView(progress);

                }
            }
        }

    }
}