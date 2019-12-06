using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace eyedetection
{
    [Activity(Label = "Eye Detection Robot", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            FindViewById<Button>(Resource.Id.button1).Click += (e, o) =>
            {
                CreatePopUp("yeet", "yeet");
            };

        }

        public void CreatePopUp(string title, string message)
        {
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.Create();
            alert.Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}