using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PersianToolkit.Time
{
    public class CirclePanel : Panel
    {
        public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register(
            "Diameter", typeof(double), typeof(CirclePanel), new FrameworkPropertyMetadata(170.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double Diameter
        {
            get => (double)GetValue(DiameterProperty);
            set => SetValue(DiameterProperty, value);
        }

        public static readonly DependencyProperty KeepVerticalProperty = DependencyProperty.Register(
            "KeepVertical", typeof(bool), typeof(CirclePanel), new FrameworkPropertyMetadata(ValueBoxes.FalseBox, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public bool KeepVertical
        {
            get => (bool)GetValue(KeepVerticalProperty);
            set => SetValue(KeepVerticalProperty, value);
        }

        public static readonly DependencyProperty OffsetAngleProperty = DependencyProperty.Register(
            "OffsetAngle", typeof(double), typeof(CirclePanel), new FrameworkPropertyMetadata(ValueBoxes.Double0Box, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double OffsetAngle
        {
            get => (double)GetValue(OffsetAngleProperty);
            set => SetValue(OffsetAngleProperty, value);
        }

        // ReSharper disable once RedundantAssignment
        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Count == 0)
            {
                return new Size(Diameter, Diameter);
            }

            availableSize = new Size(Diameter, Diameter);
            int i = 0;
            double perDeg = 360.0 / Children.Count;
            double radius = Diameter / 2;
            foreach (UIElement element in Children)
            {
                element.Measure(availableSize);
                double centerX = element.DesiredSize.Width / 2.0;
                double centerY = element.DesiredSize.Height / 2.0;
                double angle = perDeg * i++ + OffsetAngle;
                RotateTransform transform = new RotateTransform
                {
                    CenterX = centerX,
                    CenterY = centerY,
                    Angle = KeepVertical ? 0 : angle
                };
                element.RenderTransform = transform;
                double r = Math.PI * angle / 180.0;
                double x = radius * Math.Cos(r);
                double y = radius * Math.Sin(r);
                double rectX = x + availableSize.Width / 2 - centerX;
                double rectY = y + availableSize.Height / 2 - centerY;
                element.Arrange(new Rect(rectX, rectY, element.DesiredSize.Width, element.DesiredSize.Height));
            }
            return availableSize;
        }
    }
}
