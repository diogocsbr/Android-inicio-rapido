﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.Res;
using System.IO;
using Java.IO;

namespace Phoneword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //ligar os controles
            EditText phoneNumber = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            translateButton.Click += TranslateButton_Click;

            //translateButton.Click += (sender, e) =>
            //{
            //    string translatedNumber = Core.PhoneWordTranslator.ToNumber(phoneNumber.Text);
            //    if ( string.IsNullOrWhiteSpace(translatedNumber))
            //    {
            //        translatedPhoneWord.Text = string.Empty;
            //    }
            //    else
            //    {
            //        translatedPhoneWord.Text = translatedNumber;
            //    }
            //};



            TextView txt = FindViewById<TextView>(Resource.Id.txtLerArquivo);

            string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("read_asset.txt")))
            {
                content = sr.ReadToEnd();
            }

            txt.Text = content;
        }

        private void TranslateButton_Click(object sender, System.EventArgs e)
        {
            EditText phoneNumber = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);

            string translatedNumber = Core.PhoneWordTranslator.ToNumber(phoneNumber.Text);
            if (string.IsNullOrWhiteSpace(translatedNumber))
            {
                translatedPhoneWord.Text = string.Empty;
            }
            else
            {
                translatedPhoneWord.Text = translatedNumber;
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            //salvar 
            base.OnPause();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}