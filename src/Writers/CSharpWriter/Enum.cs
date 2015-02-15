﻿using System.Collections.Generic;
using System.Linq;
using Vipr.Core.CodeModel;

namespace CSharpWriter
{
    public class Enum
    {
        public string Name { get; private set; }
        public IEnumerable<EnumMember> Members { get; private set; }
        public string UnderlyingType { get; private set; }

        public Enum(OdcmEnum odcmEnum)
        {
            Name = odcmEnum.Name;
            // if no Underlying type is specified then default to 'int'.
            UnderlyingType =
                odcmEnum.UnderlyingType == null
                    ? "int"
                    : NamesService.GetPrimitiveTypeKeyword(odcmEnum.UnderlyingType);
            Members = odcmEnum.Members.Select(m => new EnumMember(m));
        }
    }
}