using Microsoft.Windows.Controls;
using System.Windows;

namespace PersianToolkit
{
    /// <summary>
    /// کلاسی برای پراپرتی های کاربردی
    /// </summary>
    public class CalendarAttached
    {
        public static readonly DependencyProperty ShowHolidayProperty = DependencyProperty.RegisterAttached(
         "ShowHoliday", typeof(bool), typeof(CalendarAttached), new FrameworkPropertyMetadata(ValueBoxes.FalseBox, FrameworkPropertyMetadataOptions.Inherits));

        public static void SetShowHoliday(DependencyObject element, bool value)
        {
            element.SetValue(ShowHolidayProperty, value);
        }

        public static bool GetShowHoliday(DependencyObject element)
        {
            return (bool)element.GetValue(ShowHolidayProperty);
        }

        public static readonly DependencyProperty ShowConvertedDateProperty = DependencyProperty.RegisterAttached(
         "ShowConvertedDate", typeof(bool), typeof(CalendarAttached), new FrameworkPropertyMetadata(ValueBoxes.FalseBox, FrameworkPropertyMetadataOptions.Inherits));

        public static void SetShowConvertedDate(DependencyObject element, bool value)
        {
            element.SetValue(ShowConvertedDateProperty, value);
        }

        public static bool GetShowConvertedDate(DependencyObject element)
        {
            return (bool)element.GetValue(ShowConvertedDateProperty);
        }
     
        public static readonly DependencyProperty ClockConfirmProperty = DependencyProperty.RegisterAttached(
         "ClockConfirm", typeof(string), typeof(CalendarAttached), new FrameworkPropertyMetadata("تایید", FrameworkPropertyMetadataOptions.Inherits));

        public static void SetClockConfirm(DependencyObject element, string value)
        {
            element.SetValue(ClockConfirmProperty, value);
        }

        public static string GetClockConfirm(DependencyObject element)
        {
            return (string)element.GetValue(ClockConfirmProperty);
        }

        public static readonly DependencyProperty PMStringProperty = DependencyProperty.RegisterAttached(
         "PMString", typeof(string), typeof(CalendarAttached), new FrameworkPropertyMetadata("عصر", FrameworkPropertyMetadataOptions.Inherits));

        public static void SetPMString(DependencyObject element, string value)
        {
            element.SetValue(PMStringProperty, value);
        }

        public static string GetPMString(DependencyObject element)
        {
            return (string)element.GetValue(PMStringProperty);
        }

        public static readonly DependencyProperty AMStringProperty = DependencyProperty.RegisterAttached(
         "AMString", typeof(string), typeof(CalendarAttached), new FrameworkPropertyMetadata("صبح", FrameworkPropertyMetadataOptions.Inherits));

        public static void SetAMString(DependencyObject element, string value)
        {
            element.SetValue(AMStringProperty, value);
        }

        public static string GetAMString(DependencyObject element)
        {
            return (string)element.GetValue(AMStringProperty);
        }

    }
}
