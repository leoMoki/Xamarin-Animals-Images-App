using Android.Support.V4.App;

namespace ImagesApp.Droid.Common
{
    public class NavigationCommon
    {
        public static void OpenFragment(FragmentActivity Activity, Fragment fragment)
        {
            if (fragment != null)
            {
                Activity.SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .AddToBackStack(null)
                .Commit();
            }
        }
    }
}