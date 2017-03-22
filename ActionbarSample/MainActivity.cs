using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace App1
{
    [Activity(Label = "@string/titleBase", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
        }

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.cloche:
                    if (SupportActionBar.Title == Resources.GetString(Resource.String.titleRenamed))
                        SupportActionBar.Title = Resources.GetString(Resource.String.titleBase);
                    else
                        SupportActionBar.Title = Resources.GetString(Resource.String.titleRenamed);
                    break;

                case Resource.Id.moreoption:
                    //...
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}

