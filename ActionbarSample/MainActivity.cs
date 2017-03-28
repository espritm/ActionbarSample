using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Util;

namespace App1
{
    [Activity(Label = "@string/titleBase", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout m_drawerLayout;
        NavigationView m_navigationView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.MainActivity);
            m_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.maintActivity_drawerlayout);
            m_navigationView = FindViewById<NavigationView>(Resource.Id.maintActivity_navigationView);

            SupportActionBar.Title = Resources.GetString(Resource.String.titleBase);

            //Display sandwich menu icon
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);

            //Handle NavigationView's item click
            m_navigationView.NavigationItemSelected += M_navigationView_NavigationItemSelected;

            //Add a header view to the NavigationView
            ConfigureNavigationViewHeader();
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

                //Handle sandwich menu icon click
                case Android.Resource.Id.Home:
                    m_drawerLayout.OpenDrawer(GravityCompat.Start);
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
        
        private void M_navigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            AddBadgeNotificationToMenuItem(e.MenuItem);

            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.leftmenu_profile:
                    break;

                case Resource.Id.leftmenu_shopping_list:
                    break;

                case Resource.Id.leftmenu_favorites:
                    break;

                case Resource.Id.leftmenu_params_option:
                    break;

                case Resource.Id.leftmenu_params_about:
                    break;
            }
            m_drawerLayout.CloseDrawer(GravityCompat.Start);
        }

        private void ConfigureNavigationViewHeader()
        {
            View viewHeader = LayoutInflater.Inflate(Resource.Layout.mainActivity_navigationView_header, null);

            ImageView imageviewUserAvatar = viewHeader.FindViewById<ImageView>(Resource.Id.mainActivity_navigationView_header_imageview_userAvatar);
            TextView textviewUserPseudo = viewHeader.FindViewById<TextView>(Resource.Id.mainActivity_navigationView_header_textview_UserPseudo);
            TextView textviewUserDesc = viewHeader.FindViewById<TextView>(Resource.Id.mainActivity_navigationView_header_textview_UserDesc);

            imageviewUserAvatar.SetImageResource(Resource.Drawable.photo_profil);
            textviewUserPseudo.Text = "Maxime Esprit";
            textviewUserDesc.Text = "A passionate mobile apps developer";
                        
            m_navigationView.AddHeaderView(viewHeader);
        }

        private void AddBadgeNotificationToMenuItem(IMenuItem menuItem)
        {
            TextView textviewBadgeNotif = (TextView)MenuItemCompat.GetActionView(m_navigationView.Menu.FindItem(menuItem.ItemId));

            //Red square with rounded corner and white text color
            textviewBadgeNotif.SetBackgroundResource(Resource.Drawable.left_menus_itemBadge);
            textviewBadgeNotif.SetTextColor(Color.White);
            textviewBadgeNotif.Gravity = GravityFlags.Center;

            //square size = 25 x 25 dp
            FrameLayout.LayoutParams lparams = (FrameLayout.LayoutParams)textviewBadgeNotif.LayoutParameters;
            lparams.Height = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 25, Resources.DisplayMetrics);
            lparams.Width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 25, Resources.DisplayMetrics);
            textviewBadgeNotif.LayoutParameters = lparams;

            //Show or hide badge notification
            if (textviewBadgeNotif.Text != "")
            {
                textviewBadgeNotif.Text = "";
                textviewBadgeNotif.Visibility = ViewStates.Gone;
            }
            else
            {
                textviewBadgeNotif.Text = "1";
                textviewBadgeNotif.Visibility = ViewStates.Visible;
            }
        }
    }
}

