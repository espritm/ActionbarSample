using Android.App;
using Android.Content;
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

            SetContentView(Resource.Layout.MainActivity);

            SupportActionBar.Title = Resources.GetString(Resource.String.titleBase);
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
                case Resource.Id.share:
                    Intent sendShareIntent = new Intent(Intent.ActionSend)
                        .SetType("text/plain")
                        .PutExtra(Intent.ExtraText, "www.maximeesprit.com");

                    StartActivity(sendShareIntent);
                    break;

                case Resource.Id.moreoption:
                    if (SupportActionBar.Title == Resources.GetString(Resource.String.titleRenamed))
                        SupportActionBar.Title = Resources.GetString(Resource.String.titleBase);
                    else
                        SupportActionBar.Title = Resources.GetString(Resource.String.titleRenamed);
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}

