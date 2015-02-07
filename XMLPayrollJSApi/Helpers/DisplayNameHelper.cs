using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace XMLPayrollJSApi.Helpers
{
    public static class DisplayNameHelper
    {
        public static string GetDisplayName(object obj, string propertyName)
        {
            if (obj == null) return null;
            return GetDisplayName(obj.GetType(), propertyName);

        }

        public static string GetDisplayName(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName);
            if (property == null) return null;

            return GetDisplayName(property);
        }

        public static string GetDisplayName(PropertyInfo property)
        {
            var attrName = GetAttributeDisplayName(property);
            if (!string.IsNullOrEmpty(attrName))
                return attrName;

            var metaName = GetMetaDisplayName(property);
            if (!string.IsNullOrEmpty(metaName))
                return metaName;

            return property.Name.ToString(CultureInfo.InvariantCulture);
        }





        private static string GetAttributeDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(
                typeof(DisplayNameAttribute), true);
            if (atts.Length == 0)
                return null;
            var displayNameAttribute = atts[0] as DisplayNameAttribute;
            return displayNameAttribute != null ? displayNameAttribute.DisplayName : null;
        }

        private static string GetMetaDisplayName(PropertyInfo property)
        {
            if (property.DeclaringType != null)
            {
                var atts = property.DeclaringType.GetCustomAttributes(
                    typeof(MetadataTypeAttribute), true);
                if (atts.Length == 0)
                    return null;

                var metaAttr = atts[0] as MetadataTypeAttribute;
                if (metaAttr != null)
                {
                    var metaProperty =
                        metaAttr.MetadataClassType.GetProperty(property.Name);
                    return metaProperty == null ? null : GetAttributeDisplayName(metaProperty);
                }
            }
            return null;
        }

        /// <summary>
        /// Εκτυπώνει το meta description property ενός enumeration
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi == null) return value.ToString();
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            var s = attributes;

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        /// <summary>
        /// Εκτυπώνει το meta description property ενός enumeration
        /// </summary>
        /// <param name="StrType"></param>
        /// <param name="StrValue"></param>
        /// <returns>string</returns>
        public static string GetEnumDescription(string StrType, string StrValue)
        {
            var type = Type.GetType(StrType);
            var value = (Enum)Enum.Parse(type, StrValue);
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            var s = attributes;

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        

        public static string GetEnumVocativeDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var x = Attribute.GetCustomAttribute(fi, typeof(VocativeDescriptionAttribute)) as VocativeDescriptionAttribute;
            return x != null ? x.VocativeDescription : value.ToString();
        }

        public static string GetEnumStringValue(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var x = Attribute.GetCustomAttribute(fi, typeof(StringValueAttribute)) as StringValueAttribute;
            return x != null ? x.StringValue : value.ToString();
        }


        /// <summary>
        /// Επσιτρέφει μια λίστα από <key, value> ζεύγη με τις τιμές και τις περιγραφές όλων των
        /// τιμών που περιλαμβάνει ένα enumeration.
        /// </summary>
        /// <param name="enumType">Ο τύπος του enumeration για τον οποίο γίνεται η επιστροφή</param>
        /// <returns>Μια λίστα από <int, string> ζεύγη</returns>
        /// <remarks>Με κλήση της συγκεκριμένης ρουτίνας υποκαθιστούμε ουσιαστικά την ανάκτηση των δεδομένων
        /// του αντίστοιχου lut από τη βάση.</remarks>
        public static List<KeyValuePair<int, string>> GetEnumKeyValuePairs(Type enumType)
        {
            var list = new List<KeyValuePair<int, string>>();
            foreach (var value in Enum.GetValues(enumType))
            {
                string description = value.ToString();
                FieldInfo fieldInfo = value.GetType().GetField(description);
                var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).First();
                if (attribute != null)
                {
                    description = (attribute as DescriptionAttribute).Description;
                }
                list.Add(new KeyValuePair<int, string>(Convert.ToInt32(value), description));
            }
            return list;
        }

        /// <summary>
        /// Κάνει ότι και η αμέσως από πάνω συνάρτηση με τη διαφορά ότι στο <key, value> το key είναι enum αντί για int.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static object GetEnumDescriptions(Type enumType)
        {
            var list = new List<KeyValuePair<Enum, string>>();
            foreach (Enum value in Enum.GetValues(enumType))
            {
                string description = value.ToString();
                FieldInfo fieldInfo = value.GetType().GetField(description);
                var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).First();
                if (attribute != null)
                {
                    description = (attribute as DescriptionAttribute).Description;
                }
                list.Add(new KeyValuePair<Enum, string>(value, description));
            }
            return list;
        }


        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            return default(T);
        }

    }
}