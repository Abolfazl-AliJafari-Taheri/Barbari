using System.Windows;
using System.Windows.Media;

namespace PersianToolkit
{
    public class TitleElement
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.RegisterAttached(
            "Title", typeof(string), typeof(TitleElement), new PropertyMetadata(default(string)));

        public static void SetTitle(DependencyObject element, string value)
        {
            element.SetValue(TitleProperty, value);
        }

        public static string GetTitle(DependencyObject element)
        {
            return (string)element.GetValue(TitleProperty);
        }

        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.RegisterAttached(
            "Background", typeof(Brush), typeof(TitleElement), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetBackground(DependencyObject element, Brush value)
        {
            element.SetValue(BackgroundProperty, value);
        }

        public static Brush GetBackground(DependencyObject element)
        {
            return (Brush)element.GetValue(BackgroundProperty);
        }

        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.RegisterAttached(
            "Foreground", typeof(Brush), typeof(TitleElement), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetForeground(DependencyObject element, Brush value)
        {
            element.SetValue(ForegroundProperty, value);
        }

        public static Brush GetForeground(DependencyObject element)
        {
            return (Brush)element.GetValue(ForegroundProperty);
        }

        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.RegisterAttached(
            "BorderBrush", typeof(Brush), typeof(TitleElement), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetBorderBrush(DependencyObject element, Brush value)
        {
            element.SetValue(BorderBrushProperty, value);
        }

        public static Brush GetBorderBrush(DependencyObject element)
        {
            return (Brush)element.GetValue(BorderBrushProperty);
        }

        public static readonly DependencyProperty TitleAlignmentProperty = DependencyProperty.RegisterAttached(
            "TitleAlignment", typeof(TitleAlignment), typeof(TitleElement), new FrameworkPropertyMetadata(TitleAlignment.Top, FrameworkPropertyMetadataOptions.Inherits));

        public static void SetTitleAlignment(DependencyObject element, TitleAlignment value)
        {
            element.SetValue(TitleAlignmentProperty, value);
        }

        public static TitleAlignment GetTitleAlignment(DependencyObject element)
        {
            return (TitleAlignment)element.GetValue(TitleAlignmentProperty);
        }

        public static readonly DependencyProperty TitleWidthProperty = DependencyProperty.RegisterAttached(
            "TitleWidth", typeof(GridLength), typeof(TitleElement), new FrameworkPropertyMetadata(new GridLength(120.0), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetTitleWidth(DependencyObject element, GridLength value)
        {
            element.SetValue(TitleWidthProperty, value);
        }

        public static GridLength GetTitleWidth(DependencyObject element)
        {
            return (GridLength)element.GetValue(TitleWidthProperty);
        }
    }
}