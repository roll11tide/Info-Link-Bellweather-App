using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;
using System.IO;
using System.Text;

using Java.Net;
using Android.Graphics;
using Java.IO;
using Android.Graphics.Drawables;
using Android.Util;

namespace Info_Link_Bellweather_App
{
    [Activity(Label = "Info_Link_Bellweather_App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Spinner chartSpinnerMonth;
        Spinner chartSpinnerType;
        ImageView imageView;
        string month = "12";
        string type = "allpower";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            chartSpinnerMonth = FindViewById<Spinner>(Resource.Id.spinner1);
            chartSpinnerMonth.ItemSelected += chartSpinnerMonth_ItemSelected;

            chartSpinnerType = FindViewById<Spinner>(Resource.Id.spinner2);
            chartSpinnerType.ItemSelected += chartSpinnerType_ItemSelected;

            PopulateSpinners();

            imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/AllPower12.png");
        }

        #region Event Handlers
        void chartSpinnerMonth_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            TextView textView4 = FindViewById<TextView>(Resource.Id.textView4);
            switch (e.Position.ToString())
            {
                case "0":
                    // 12 Month Selected
                    month = "12";
                    textView4.Text = "Rolling 12 month year-over-year % change in unit sales";
                    break;
                case "1":
                    // 3 Month Selected
                    month = "3";
                    textView4.Text = "Rolling 3 month year-over-year % change in unit sales";
                    break;
                default:
                    System.Console.WriteLine("---SPINNER FAULT---\r\nIndex out of range!");
                    break;
            }

            updateImageView();
        }

        void chartSpinnerType_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs f)
        {
            Spinner spinner = (Spinner)sender;
            switch (f.Position.ToString())
            {
                case "0":
                    // All Power Selected
                    type = "allpower";
                    break;
                case "1":
                    // Outboard Selected
                    type = "outboard";
                    break;
                case "2":
                    // Stern/Jet Selected
                    type = "sternjet";
                    break;
                case "3":
                    // PWC Selected
                    type = "pwc";
                    break;
                case "4":
                    // Sport Fish Selected
                    type = "sportfish";
                    break;
                case "5":
                    // Ski Boat Selected
                    type = "skiboat";
                    break;
                default:
                    System.Console.WriteLine("---SPINNER FAULT---\r\nIndex out of range!");
                    break;
            }

            updateImageView();
        }
        #endregion

        #region Functional Methods
        private void SetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            imageView.SetImageBitmap(imageBitmap);
        }

        void PopulateSpinners()
        {
            ArrayAdapter<string> chartMonthVarieties = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem);
            chartMonthVarieties.Add("12 Month");
            chartMonthVarieties.Add("3 Month");
            chartSpinnerMonth.Adapter = chartMonthVarieties;

            ArrayAdapter<string> chartTypeVarities = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem);
            chartTypeVarities.Add("All Power");
            chartTypeVarities.Add("Outboard");
            chartTypeVarities.Add("Stern/Jet");
            chartTypeVarities.Add("PWC");
            chartTypeVarities.Add("Sport Fish");
            chartTypeVarities.Add("Ski Boat");
            chartSpinnerType.Adapter = chartTypeVarities;
        }

        void updateImageView()
        {
            switch (month)
            {
                case "12":
                    switch(type)
                    {
                        case "allpower":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/AllPower12.png");
                            break;
                        case "outboard":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/Allout12.png");
                            break;
                        case "sternjet":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/Stern12.png");
                            break;
                        case "pwc":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/pwcs12.png");
                            break;
                        case "sportfish":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/SportFish12.png");
                            break;
                        case "skiboat":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/SkiBoat12.png");
                            break;
                        default:
                            System.Console.WriteLine("TYPE UNRECOGNIZED!");
                            break;
                    }
                    break;
                case "3":
                    switch (type)
                    {
                        case "allpower":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/AllPower3.png");
                            break;
                        case "outboard":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/Allout3.png");
                            break;
                        case "sternjet":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/Stern3.png");
                            break;
                        case "pwc":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/pwcs3.png");
                            break;
                        case "sportfish":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/SportFish3.png");
                            break;
                        case "skiboat":
                            SetImageBitmapFromUrl("http://www.info-link.com/newlink/wp-content/uploads/Bellwethergifs/SkiBoat3.png");
                            break;
                        default:
                            System.Console.WriteLine("TYPE UNRECOGNIZED!");
                            break;
                    }
                    break;
                default:
                    System.Console.WriteLine("MONTH UNRECOGNIZED!");
                    break;
            }
        }
        #endregion
    }
}