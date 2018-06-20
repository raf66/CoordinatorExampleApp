using System;
using System.Collections.Generic;
using CoordinatorExampleApp.Models;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Views.ViewCells
{
    public partial class SideMenuHeaderViewCell : ViewCell
    {
        public static readonly BindableProperty SideMenuItemProperty = BindableProperty.Create("SideMenuItem", typeof(SideMenuHeader), typeof(SideMenuHeaderViewCell));

        public SideMenuHeaderViewCell()
        {
            InitializeComponent();
        }
    }
}
