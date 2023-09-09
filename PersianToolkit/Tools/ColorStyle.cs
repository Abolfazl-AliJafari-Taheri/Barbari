using System.Windows;
using System.Windows.Media;

namespace PersianToolkit
{
    /// <summary>
    /// تغییر استایل مناسبت ها و رنگ بندی روزهای تقویم
    /// </summary>
    public class ColorStyle
    {

        public static readonly DependencyProperty HolidayContentStyleProperty = DependencyProperty.RegisterAttached(
            "HolidayContentStyle", typeof(Style), typeof(ColorStyle), new FrameworkPropertyMetadata(ResourceHelper.GetResource<Style>(ResourceHolidayContentStyleToken.LabelDefault), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetHolidayContentStyle(DependencyObject element, Style value)
        {
            element.SetValue(HolidayContentStyleProperty, value);
        }

        public static Style GetHolidayContentStyle(DependencyObject element)
        {
            return (Style)element.GetValue(HolidayContentStyleProperty);
        }

        public static readonly DependencyProperty ConvertedDateStyleProperty = DependencyProperty.RegisterAttached(
           "ConvertedDateStyle", typeof(Style), typeof(ColorStyle), new FrameworkPropertyMetadata(ResourceHelper.GetResource<Style>(ResourceHolidayContentStyleToken.LabelDefault), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetConvertedDateStyle(DependencyObject element, Style value)
        {
            element.SetValue(ConvertedDateStyleProperty, value);
        }

        public static Style GetConvertedDateStyle(DependencyObject element)
        {
            return (Style)element.GetValue(ConvertedDateStyleProperty);
        }

        public static readonly DependencyProperty SelectedDateBrushProperty = DependencyProperty.RegisterAttached(
            "SelectedDateBrush", typeof(Brush), typeof(ColorStyle), new FrameworkPropertyMetadata(default(Brushes), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetSelectedDateBrush(DependencyObject element, Brush value)
        {
            element.SetValue(SelectedDateBrushProperty, value);
        }

        public static Brush GetSelectedDateBrush(DependencyObject element)
        {
            return (Brush)element.GetValue(SelectedDateBrushProperty);
        }

        public static readonly DependencyProperty TodayDateBrushProperty = DependencyProperty.RegisterAttached(
            "TodayDateBrush", typeof(Brush), typeof(ColorStyle), new FrameworkPropertyMetadata(default(Brushes), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetTodayDateBrush(DependencyObject element, Brush value)
        {
            element.SetValue(TodayDateBrushProperty, value);
        }

        public static Brush GetTodayDateBrush(DependencyObject element)
        {
            return (Brush)element.GetValue(TodayDateBrushProperty);
        }

        public static readonly DependencyProperty HolidayDayBrushProperty = DependencyProperty.RegisterAttached(
            "HolidayDayBrush", typeof(Brush), typeof(ColorStyle), new FrameworkPropertyMetadata(default(Brushes), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetHolidayDayBrush(DependencyObject element, Brush value)
        {
            element.SetValue(HolidayDayBrushProperty, value);
        }

        public static Brush GetHolidayDayBrush(DependencyObject element)
        {
            return (Brush)element.GetValue(HolidayDayBrushProperty);
        }
    }
}
