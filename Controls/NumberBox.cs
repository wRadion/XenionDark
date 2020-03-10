using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace XenionDark.Controls
{
    public enum NumberType
    {
        Integer,
        Float
    }

    public enum NumberSign
    {
        Positive,
        Negative,
        Both
    }

    public class NumberBox : TextBox
    {
        public static DependencyPropertyKey IntegerValueProperty = DependencyProperty.RegisterReadOnly("IntegerValue", typeof(int), typeof(NumberBox), new PropertyMetadata(0));
        public static DependencyPropertyKey FloatValueProperty = DependencyProperty.RegisterReadOnly("FloatValue", typeof(decimal), typeof(NumberBox), new PropertyMetadata(0m));

        public static DependencyProperty NumberTypeProperty = DependencyProperty.Register("NumberType", typeof(NumberType), typeof(NumberBox), new PropertyMetadata(NumberType.Integer));
        public static DependencyProperty NumberSignProperty = DependencyProperty.Register("NumberSign", typeof(NumberSign), typeof(NumberBox), new PropertyMetadata(NumberSign.Positive));
        public static DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(decimal), typeof(NumberBox), new PropertyMetadata(decimal.MinValue));
        public static DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(decimal), typeof(NumberBox), new PropertyMetadata(decimal.MaxValue));
        public static DependencyProperty FloatPrecisionProperty = DependencyProperty.Register("FloatPrecision", typeof(int), typeof(NumberBox));

        public int IntegerValue
        {
            get => (int)GetValue(IntegerValueProperty.DependencyProperty);
            private set => SetValue(IntegerValueProperty, value);
        }

        public decimal FloatValue
        {
            get => (decimal)GetValue(FloatValueProperty.DependencyProperty);
            set => SetValue(FloatValueProperty, value);
        }

        public NumberType NumberType
        {
            get => (NumberType)GetValue(NumberTypeProperty);
            set => SetValue(NumberTypeProperty, value);
        }

        public NumberSign NumberSign
        {
            get => (NumberSign)GetValue(NumberSignProperty);
            set => SetValue(NumberSignProperty, value);
        }

        public decimal Minimum
        {
            get => (decimal)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public decimal Maximum
        {
            get => (decimal)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public int FloatPrecision
        {
            get => (int)GetValue(FloatPrecisionProperty);
            set => SetValue(FloatPrecisionProperty, value);
        }

        private string _textBefore;

        static NumberBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberBox), new FrameworkPropertyMetadata(typeof(NumberBox)));
        }

        private bool IsInteger(string text, out int value) => int.TryParse(text, out value);
        private bool IsFloat(string text, out decimal value) => decimal.TryParse(text, out value);
        private bool IsValueInRange(decimal value) => Minimum <= value && value <= Maximum;
        private bool IsFloatPrecisionValid(string text)
        {
            if (!text.Contains(".")) return true;
            return text.Split('.')[1].Length <= FloatPrecision;
        }
        private bool IsNumberSignValid(decimal value)
        {
            if (NumberSign == NumberSign.Positive)
                return value >= 0;
            if (NumberSign == NumberSign.Negative)
                return value <= 0;
            return true;
        }
        private string NewText(string textBefore, string text)
        {
            string newText = text;
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(text) || text == "-")
            {
                if (text == null)
                    text = string.Empty;
                text += "0";
            }

            if (NumberType == NumberType.Integer)
            {
                int value;
                isValid = IsInteger(text, out value) && IsNumberSignValid(value) && IsValueInRange(value);
                if (isValid)
                    IntegerValue = value;
            }
            else if (NumberType == NumberType.Float)
            {
                decimal value;
                isValid = IsFloat(text, out value) && IsNumberSignValid(value) && IsValueInRange(value) && IsFloatPrecisionValid(text);
                if (isValid)
                    FloatValue = value;
            }

            if (!isValid)
                return textBefore;

            return newText;
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            Text = NewText(_textBefore, Text);

            if (Text == _textBefore)
                CaretIndex = e.Changes.Last().Offset;

            _textBefore = Text;
        }

    }
}
