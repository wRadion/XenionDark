using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace XenionDark.Controls
{
    public enum NumberSign
    {
        Both,
        Positive,
        Negative
    }

    public class NumberBoxInteger : TextBox
    {
        public const string IntegerRegex = "^-?\\d*$";

        public static DependencyPropertyKey IsValidPropertyKey = DependencyProperty.RegisterReadOnly("IsValid", typeof(bool), typeof(NumberBoxInteger), new PropertyMetadata(true));

        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(NumberBoxInteger));
        public static DependencyProperty NumberSignProperty = DependencyProperty.Register("NumberSign", typeof(NumberSign), typeof(NumberBoxInteger), new PropertyMetadata(NumberSign.Both));
        public static DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(NumberBoxInteger), new PropertyMetadata(int.MinValue));
        public static DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(NumberBoxInteger), new PropertyMetadata(int.MaxValue));

        public bool IsValid
        {
            get => (bool)GetValue(IsValidPropertyKey.DependencyProperty);
            private set => SetValue(IsValidPropertyKey, value);
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public NumberSign NumberSign
        {
            get => (NumberSign)GetValue(NumberSignProperty);
            set => SetValue(NumberSignProperty, value);
        }

        public int Minimum
        {
            get => (int)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public int Maximum
        {
            get => (int)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        private string _lastText;
        private int _lastValidValue;

        static NumberBoxInteger()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberBoxInteger), new FrameworkPropertyMetadata(typeof(NumberBoxInteger)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (NumberSign == NumberSign.Positive && (Maximum < 0 || Minimum < 0))
                throw new ArgumentOutOfRangeException("Minimum or Maximum value cannot be negative because the NumberSign is positive.");
            if (NumberSign == NumberSign.Negative && (Maximum > 0 || Minimum > 0))
                throw new ArgumentOutOfRangeException("Minimum or Maximum value cannot be positive because the NumberSign is negative.");
            if (Minimum > Maximum)
                throw new ArgumentException("Minimum value cannot be greater than Maximum value.");

            CheckValue();
        }

        private void CheckValue()
        {
            if ((NumberSign == NumberSign.Positive && Value >= 0) || (NumberSign == NumberSign.Negative && Value <= 0) || NumberSign == NumberSign.Both)
            {
                if (Value <= Minimum)
                    Value = Minimum;
                else if (Value >= Maximum)
                    Value = Maximum;
            }
            else
            {
                if (NumberSign == NumberSign.Positive)
                    Value = Minimum;
                else if (NumberSign == NumberSign.Negative)
                    Value = Maximum;
            }

            Text = Value.ToString();
            _lastValidValue = Value;
        }

        private void CheckText()
        {
            if (string.IsNullOrWhiteSpace(Text) || Text == "-")
                Value = Minimum;
            else if (Regex.IsMatch(Text, IntegerRegex))
            {
                if (int.TryParse(Text, out int value) && ((NumberSign == NumberSign.Positive && value >= 0) || (NumberSign == NumberSign.Negative && value <= 0) || NumberSign == NumberSign.Both))
                {
                    if (value <= Minimum)
                        Value = Minimum;
                    else if (value >= Maximum)
                        Value = Maximum;
                    else
                        Value = value;
                }
                else // case where int is too large or too small
                {
                    if (Text.StartsWith("-"))
                        Value = Minimum;
                    else
                        Value = Maximum;
                }
            }
            else
                Value = _lastValidValue;

            Text = Value.ToString();
            _lastValidValue = Value;
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if (!Regex.IsMatch(Text, IntegerRegex))
            {
                Text = _lastText;
                CaretIndex = e.Changes.Last().Offset;
            }
            else
            {
                IsValid = int.TryParse(Text, out int value) && ((NumberSign == NumberSign.Positive && value >= 0) || (NumberSign == NumberSign.Negative && value <= 0) || NumberSign == NumberSign.Both) && Minimum <= value && value <= Maximum;
                if (IsValid)
                    Value = value;
            }

            _lastText = Text;
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            CheckText();
            base.OnLostFocus(e);
        }

    }
}
