using Android.Graphics.Drawables;
using GarneyAppSystem.CustomControls;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarneyAppSystem.Platforms
{
    public static class EntryMapper
    {
        public static void Map(IElementHandler handler, IElement view)
        {
            if (view is StandardEntry)
            {
                var casted = (EntryHandler)handler;
                var viewData = (StandardEntry)view;

                var gd = new GradientDrawable();

                gd.SetCornerRadius((int)handler.MauiContext?.Context.ToPixels(viewData.CornerRadius));
                gd.SetStroke((int)handler.MauiContext?.Context.ToPixels(viewData.BorderThickness), viewData.BorderColor.ToPlatform());
                gd.SetColor(viewData.BackgroundColor.ToPlatform());

                casted.PlatformView?.SetBackground(gd);

                var padTop = (int)handler.MauiContext?.Context.ToPixels(viewData.Padding.Top);
                var padBottom = (int)handler.MauiContext?.Context.ToPixels(viewData.Padding.Bottom);
                var padLeft = (int)handler.MauiContext?.Context.ToPixels(viewData.Padding.Left);
                var padRight = (int)handler.MauiContext?.Context.ToPixels(viewData.Padding.Right);

                casted.PlatformView?.SetPadding(padLeft, padRight, padTop, padBottom);
            }
        }
    }
}
