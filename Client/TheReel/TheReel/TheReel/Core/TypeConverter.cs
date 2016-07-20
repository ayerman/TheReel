using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReel.Core
{
    public abstract class TypeConverter
    {
        public virtual bool CanConvertFrom(Type sourceType)
        {
            if (sourceType == null)
                throw new ArgumentNullException("sourceType");

            return sourceType == typeof(string);
        }

        [Obsolete("use ConvertFromInvariantString (string)")]
        public virtual object ConvertFrom(object o)
        {
            return null;
        }

        [Obsolete("use ConvertFromInvariantString (string)")]
        public virtual object ConvertFrom(CultureInfo culture, object o)
        {
            return null;
        }

        public virtual object ConvertFromInvariantString(string value)
        {
#pragma warning disable 0618 // retain until ConvertFrom removed
            return ConvertFrom(CultureInfo.InvariantCulture, value);
#pragma warning restore
        }
    }
}
