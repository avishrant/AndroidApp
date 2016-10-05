using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp
{
    [Activity (Label ="Show Call History")]
    class CallHistory : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var phoneNums = Intent.Extras.GetStringArrayList("phone_nums") ?? new string[0];        //initilaising lists
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, phoneNums);    //shows
                                                                                                            // called numbers in a system included list
        }
    }
}