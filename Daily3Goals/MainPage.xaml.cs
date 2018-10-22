using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Daily3Goals
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += (sender, e) => {
                var item = e.SelectedItem as MasterPageItem;
                if (item != null) {
                    // Set to new page
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    // Hide master page to display detail page
                    IsPresented = false;
                }
            };
        }
    }
}
