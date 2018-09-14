using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Daily3Goals
{
    public partial class MainPage : ContentPage
    {
        DateTime date;

        public MainPage()
        {
            date = DateTime.Now;

            InitializeComponent();
        }

        public string Date => date.ToString("dddd, MMMM dd, yyyy");
    }
}
