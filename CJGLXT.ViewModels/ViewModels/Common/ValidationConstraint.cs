using System;
using System.Collections.Generic;
using System.Text;

namespace CJGLXT.ViewModels.ViewModels.Common
{
    public interface IValidationConstraint<T>
    {
        Func<T, bool> Validate { get; }
        string Message { get; }
    }

    public class ValidationConstraint<T> : IValidationConstraint<T>
    {
        public ValidationConstraint(string message, Func<T, bool> validate)
        {
            Message = message;
            Validate = validate;
        }

        public Func<T, bool> Validate { get; set; }
        public string Message { get; set; }
    }

    public class RequiredConstraint<T> : IValidationConstraint<T>
    {
        public RequiredConstraint(string propertyName, Func<T, object> propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (value != null)
            {
                return !String.IsNullOrWhiteSpace(value.ToString());
            }
            return true;
        }

        string IValidationConstraint<T>.Message => $"Property '{PropertyName}' cannot be empty.";
    }

    public class NullableOrOtherConstraint<T> : IValidationConstraint<T>
    {
        public NullableOrOtherConstraint(string propertyName, Func<T, object> propertyValue,IEnumerable<IValidationConstraint<T>> other)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Other = other;
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }
        public IEnumerable<IValidationConstraint<T>> Other { get; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (!String.IsNullOrWhiteSpace(value.ToString()))
            {
                foreach (var v in Other)
                {
                    if (!v.Validate(model))
                    {
                        _otherMessage = v.Message;
                        return false;
                    }
                }
            }
            return true;
        }

        private string _otherMessage;
        string IValidationConstraint<T>.Message=> this._otherMessage;
    }

    public class RequiredGreaterThanZeroConstraint<T> : IValidationConstraint<T>
    {
        public RequiredGreaterThanZeroConstraint(string propertyName, Func<T, object> propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (value != null)
            {
                if (Int32.TryParse(value.ToString(), out int d))
                {
                    return d > 0;
                }
            }
            return false;
        }

        string IValidationConstraint<T>.Message => $"Property '{PropertyName}' must be greater than zero.";
    }

    public class PositiveConstraint<T> : IValidationConstraint<T>
    {
        public PositiveConstraint(string propertyName, Func<T, object> propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (value != null)
            {
                if (Int32.TryParse(value.ToString(), out int d))
                {
                    return d >= 0;
                }
            }
            return false;
        }

        string IValidationConstraint<T>.Message => $"Property '{PropertyName}' must be positive.";
    }

    public class NonZeroConstraint<T> : IValidationConstraint<T>
    {
        public NonZeroConstraint(string propertyName, Func<T, object> propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (value != null)
            {
                if (Int32.TryParse(value.ToString(), out int d))
                {
                    return d != 0;
                }
            }
            return false;
        }

        string IValidationConstraint<T>.Message => $"Property '{PropertyName}' cannot be zero.";
    }

    public class GreaterThanConstraint<T> : IValidationConstraint<T>
    {
        public GreaterThanConstraint(string propertyName, Func<T, object> propertyValue, int value)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Value = value;
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }
        public int Value { get; set; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (value != null)
            {
                if (Int32.TryParse(value.ToString(), out int d))
                {
                    return d > Value;
                }
            }
            return false;
        }

        string IValidationConstraint<T>.Message => $"Property '{PropertyName}' must be greater than {Value}.";
    }

    public class NonGreaterThanConstraint<T> : IValidationConstraint<T>
    {
        public NonGreaterThanConstraint(string propertyName, Func<T, object> propertyValue, int value, string valueDesc = null)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Value = value;
            ValueDesc = valueDesc ?? Value.ToString();
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }
        public int Value { get; set; }
        public string ValueDesc { get; set; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (value != null)
            {
                if (Int32.TryParse(value.ToString(), out int d))
                {
                    return d <= Value;
                }
            }
            return false;
        }

        string IValidationConstraint<T>.Message => $"Property '{PropertyName}' cannot be greater than {ValueDesc}.";
    }

    public class LessThanConstraint<T> : IValidationConstraint<T>
    {
        public LessThanConstraint(string propertyName, Func<T, object> propertyValue, int value)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Value = value;
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }
        public int Value { get; set; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (value != null)
            {
                if (Int32.TryParse(value.ToString(), out int d))
                {
                    return d < Value;
                }
            }
            return false;
        }

        string IValidationConstraint<T>.Message => $"Property '{PropertyName}' must be less than {Value}.";
    }

    public class OneOfConstraint<T> : IValidationConstraint<T>
    {
        public OneOfConstraint(string propertyName, Func<T, object> propertyValue, IEnumerable<object> values)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Values = values;
        }

        public string PropertyName { get; set; }
        public Func<T, object> PropertyValue { get; set; }
        public IEnumerable<object> Values { get; set; }

        Func<T, bool> IValidationConstraint<T>.Validate => ValidateProperty;

        private bool ValidateProperty(T model)
        {
            var value = PropertyValue(model);
            if (value != null)
            {
                foreach (var v in Values)
                {
                    if (object.Equals(value, v))
                        return true;
                }
            }
            return false;
        }

        string IValidationConstraint<T>.Message
        {
            get
            {
                StringBuilder str=new StringBuilder();
                str.Append($"Property '{PropertyName}' must be one of those value(s): ");
                foreach (var v in Values)
                {
                    str.Append(v.ToString()).Append(" , ");
                }
                return str.ToString();
            }
        }
    }
}
