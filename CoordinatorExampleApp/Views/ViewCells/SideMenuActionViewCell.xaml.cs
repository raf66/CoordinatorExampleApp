using System;
using System.Collections.Generic;
using CoordinatorExampleApp.Models;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Views.ViewCells
{
    public partial class SideMenuActionViewCell : ViewCell
    {
        public static readonly BindableProperty SideMenuItemProperty = BindableProperty.Create("SideMenuItem", typeof(SideMenuAction), typeof(SideMenuActionViewCell));


        public SideMenuActionViewCell()
        {
            InitializeComponent();
        }
    }
}
