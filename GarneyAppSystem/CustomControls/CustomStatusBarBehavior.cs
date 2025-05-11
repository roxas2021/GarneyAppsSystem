using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GarneyAppSystem.CustomControls
{
    public class CustomStatusBarBehavior : Behavior<Page>
    {
        private static Color StatusColor = Color.FromRgb(red:0, green:0, blue:0);
        private static StatusBarStyle StatusStyle = StatusBarStyle.Default;

        public static readonly BindableProperty StatusBarColorProperty =
                               BindableProperty.CreateAttached(propertyName: "StatusBarColor", 
                                                                             typeof(Color), 
                                                                             typeof(CustomStatusBarBehavior),
                                                                             Color.FromRgb(red: 0, green: 0, blue: 0),
                                                                             propertyChanged: OnStatusBarColorChanged);

        public static readonly BindableProperty StatusBarStyleProperty =
                               BindableProperty.CreateAttached(propertyName: "StatusBarStyle",
                                                                             typeof(Color),
                                                                             typeof(CustomStatusBarBehavior),
                                                                             Color.FromRgb(red: 0, green: 0, blue: 0),
                                                                             propertyChanged: OnStatusBarStyleChanged);

        public static Color GetStatusBarColor(BindableObject view)
        {
            return (Color)view.GetValue(StatusBarColorProperty);
        }

        public static void SetStatusBarColor(BindableObject view, Color value)
        {
            view.SetValue(StatusBarColorProperty, value);
        }
        
        public static StatusBarStyle GetStatusBarStyle(BindableObject view)
        {
            return (StatusBarStyle)view.GetValue(StatusBarStyleProperty);
        }

        public static void SetStatusBarStyle(BindableObject view, StatusBarStyle value)
        {
            view.SetValue(StatusBarStyleProperty, value);
        }

        private static void OnStatusBarStyleChanged(BindableObject view, object oldValue, object newValue)
        {
            Page page = view as Page;
            if (page != null)
            {
                if ((StatusBarStyle)newValue != (StatusBarStyle)oldValue)
                {
                    StatusStyle = (StatusBarStyle)newValue;
                    AddBehavior(page);
                }
            }
        }

        private static void OnStatusBarColorChanged(BindableObject view, object oldValue, object newValue)
        {
            Page page = view as Page;
            if (page != null)
            {
                if((Color)newValue != (Color)oldValue)
                {
                    StatusColor = (Color)newValue;
                    AddBehavior(page);
                }
            }
        }

        private static void AddBehavior(Page page)
        {
            page.Behaviors.Add(new StatusBarBehavior
            {
                StatusBarColor = StatusColor,
                StatusBarStyle = StatusStyle
            });
        }
    }
}
