using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private static readonly List<string> phoneNums = new List<string>();
        private string translatedNum = string.Empty;
        private EditText phoneNumText;
        private Button transButton;                 // Global elements to bind interface buttons
        private Button CallButton;
        private Button History;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //assigning global elements
            phoneNumText = FindViewById<EditText>(Resource.Id.phoneNum);
            transButton = FindViewById<Button>(Resource.Id.btnTranslate);
            CallButton = FindViewById<Button>(Resource.Id.btnCall);
            History = FindViewById<Button>(Resource.Id.btnHistory);

            CallButton.Enabled = false;

            //assigning click events
            transButton.Click += TransButton_Click;
            CallButton.Click += CallButton_Click;
            History.Click += History_Click;
        }
        //click events ==>

        private void History_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CallHistory));
            intent.PutStringArrayListExtra("phone_nums", phoneNums);
            StartActivity(intent);
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            var callDialog = new AlertDialog.Builder(this); //creating alert dialog
            callDialog.SetMessage("call " + translatedNum + "?");   //message on dialog
            callDialog.SetNeutralButton("Call", delegate
           {
               phoneNums.Add(translatedNum);                    //when call button on dialog is clicked, 
               History.Enabled = true;                             //launches system call activity
               var callIntent = new Intent(Intent.ActionCall);
               callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNum));   //translates value in edittext 
               StartActivity(callIntent);                                           //and starts call
           });
            callDialog.SetNegativeButton("Cancel", delegate { });           //well, cancel
            callDialog.Show();                                          // code that actually launches the alert dialog
        }

        private void TransButton_Click(object sender, EventArgs e)
        {
            translatedNum = NumTranslator.ToNum(phoneNumText.Text);                 //passes value in edittext to a method in another class
            if (string.IsNullOrWhiteSpace (translatedNum))
            {
                CallButton.Text = "Call";
                CallButton.Enabled = false;

            }
            else
            {
                CallButton.Text = "Call " + translatedNum;
                CallButton.Enabled = true;
            }
        }
    }
}

