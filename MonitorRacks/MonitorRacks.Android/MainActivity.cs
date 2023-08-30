using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Graphics;
using Firebase.Messaging;
using Xamarin.Essentials;
using Android;
using Plugin.Fingerprint;

namespace MonitorRacks.Droid
{
    [Activity(Label = "MonitorRacks", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static readonly string Channel_ID = "TestChannel";
        internal static readonly int NotificationID = 101;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            CrossFingerprint.SetCurrentActivityResolver(() => this);

            Window.SetStatusBarColor(Color.Black);

            const int requestNotification = 0;
            string[] notiPermissions =
            {
                Manifest.Permission.PostNotifications
            };

            if((int)Build.VERSION.SdkInt < 33)
            {
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.PostNotifications) != (int)Permission.Granted)
            {
                RequestPermissions(notiPermissions, requestNotification);
            }

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    if (key == "NavigationID")
                    {
                        string idValue = Intent.Extras.GetString(key);
                        if (Preferences.ContainsKey("NavigationID"))
                            Preferences.Remove("NavigationID");

                        Preferences.Set("NavigationID", idValue);
                    }
                }
            }
            CreateNotificationChannel();
            FirebaseMessaging.Instance.SubscribeToTopic("ASLOGIC");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CreateNotificationChannel()
        {
            var channel = new NotificationChannel(Channel_ID, "Test Notfication Channel", NotificationImportance.Default);

            var notificaitonManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificaitonManager.CreateNotificationChannel(channel);
        }
    }
}