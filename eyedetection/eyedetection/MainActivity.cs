using System.Diagnostics;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Content;

using OpenCV.Android;
using OpenCV.Core;
using OpenCV.ImgProc;

namespace eyedetection
{

    [Activity(Label = "Eye Detection Robot", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, CameraBridgeViewBase.ICvCameraViewListener2
    {
        JavaCameraView javaCameraView;
        Mat mRGBA, mRGBAT;

        private class MyLoaderCallback : BaseLoaderCallback {
            MainActivity self;
            public MyLoaderCallback(MainActivity self, Context context) : base(context) { this.self = self; }
            public void onManagerConnected(int status)
            {
                switch(status)
                {
                    case BaseLoaderCallback.InterfaceConsts.Success:
                        self.javaCameraView.EnableView();
                        break;
                    default:
                        base.OnManagerConnected(status);
                        break;
                }
            }
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.Window.AddFlags(Android.Views.WindowManagerFlags.Fullscreen | Android.Views.WindowManagerFlags.TurnScreenOn | Android.Views.WindowManagerFlags.KeepScreenOn);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //getWindow().addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);

            javaCameraView = (JavaCameraView)FindViewById(Resource.Id.cameraView);
            javaCameraView.SetCvCameraViewListener2(this);
            javaCameraView.EnableView();

            if(OpenCVLoader.InitDebug())
            {
                System.Diagnostics.Debug.WriteLine("openCV Initialized");
            }
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

        public void OnCameraViewStarted(int width, int height)
        {
            mRGBA = new Mat(height, width, CvType.Cv8uc4);
        }

        public void OnCameraViewStopped()
        {
            mRGBA.Release();
        }

        public Mat OnCameraFrame(CameraBridgeViewBase.ICvCameraViewFrame inputFrame)
        {
            mRGBA = inputFrame.Rgba();
            mRGBAT = mRGBA.T();
            Core.Flip(mRGBA.T(), mRGBAT, 1);
            Imgproc.Resize(mRGBAT, mRGBAT, mRGBA.Size());
            return mRGBAT;
        }

        public void OnDestory()
        {
            if (javaCameraView != null)
            {
                javaCameraView.DisableView();
            }
        }
    }
}