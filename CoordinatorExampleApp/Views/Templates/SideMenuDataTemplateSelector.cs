using System;
using CoordinatorExampleApp.Models;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Views.Templates
{
    public class SideMenuDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SideMenuActionTemplate { get; set; }
        public DataTemplate SideMenuHeaderTemplate { get; set; }

        public SideMenuDataTemplateSelector()
        {
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item == null)
                return null;

            if (item is SideMenuAction)
                return SideMenuActionTemplate;

            if (item is SideMenuHeader)
                return SideMenuHeaderTemplate;

            return null;
        }
    }
}
