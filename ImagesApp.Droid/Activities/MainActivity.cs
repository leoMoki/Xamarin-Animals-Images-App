using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ImagesApp.Droid.Common;
using ImagesApp.Droid.Fragments;

namespace ImagesApp.Droid.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
        //, BottomNavigationView.IOnNavigationItemSelectedListener
    {       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
                        
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            //navigation.SetOnNavigationItemSelectedListener(this);

            navigation.NavigationItemSelected += Navigation_NavigationItemSelected;

            //Carrega o fragment cats como default inicial
            if (savedInstanceState == null)
            {
                NavigationCommon.OpenFragment(this, FragmentCats.NewInstance()); ;
            }
        }

        private void Navigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            Android.Support.V4.App.Fragment fragment = null;

            switch (e.Item.ItemId)
            {
                case Resource.Id.navigation_home:
                    fragment = FragmentCats.NewInstance();
                    break;

                case Resource.Id.navigation_dashboard:
                    fragment = FragmentDogs.NewInstance();
                    break;

                default:
                    fragment = FragmentCats.NewInstance();
                    break;
            }
            NavigationCommon.OpenFragment(this, fragment);
        }

        //public bool OnNavigationItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Resource.Id.navigation_home:
        //            textMessage.SetText(Resource.String.title_home);
        //            return true;
        //        case Resource.Id.navigation_dashboard:
        //            textMessage.SetText(Resource.String.title_dashboard);
        //            return true;
        //        //case Resource.Id.navigation_notifications:
        //        //    textMessage.SetText(Resource.String.title_notifications);
        //        //    return true;
        //    }
        //    return false;
        //}
    }
}

