using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaScriptEditor
{
    internal class KeyTypeComboObject
    {
        public string Value { get; set; }
        public KeyType KeyType { get; set; }

        public KeyTypeComboObject(KeyType keyType, string value)
        {
            KeyType = keyType;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
