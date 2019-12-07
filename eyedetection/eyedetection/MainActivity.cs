using System.Diagnostics;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;

using OpenCV.Android;
using OpenCV.Core;

namespace eyedetection
{
    [Activity(Label = "Eye Detection Robot", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        JavaCameraView javaCameraView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //make sure openCV is working fine
            if (OpenCVLoader.InitDebug())
            {
                System.Diagnostics.Debug.WriteLine("OpenCV Connected Successfully");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("OpenCV Not Working Or Loaded");
            }

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            javaCameraView = (JavaCameraView)FindViewById(Resource.Id.cameraView);
            javaCameraView.EnableView();

            FindViewById<Button>(Resource.Id.button1).Click += (e, o) =>
            {
                CreateAlert("Alert", "this is alert");
            };
        }

        public void CreateAlert(string title, string message)
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