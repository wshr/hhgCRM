using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Core.Atrributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Enum | AttributeTargets.Class, AllowMultiple = false)]
    public class LDisplayAttribute : System.ComponentModel.DisplayNameAttribute
    {
        // Methods
        public LDisplayAttribute()
        {
        }

        public LDisplayAttribute(string resourceId) : base(resourceId)
        {
        }

        private static string GetMessageFromResource(string resourceId)
        {
            return resourceId;
        }

        // Properties
        public override string DisplayName
        {
            get
            {
                return GetMessageFromResource(base.DisplayName);
            }
        }
    }
}
