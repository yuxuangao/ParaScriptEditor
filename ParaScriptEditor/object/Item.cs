using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaScriptEditor
{
    internal class Item
    {
        public string Key { get; set; }
        public string? Value { get; set; }
        public List<Item> ValueArray { get; set; }
        public string CompareSign { get; set; }
        public Item? Parent { get; set; }
        public bool HasError { get; set; }

        public Item(string key, string compareSign)
        {
            this.Key = key;
            this.Value = null;
            this.ValueArray = new List<Item>();
            this.CompareSign = compareSign;
            this.HasError = false;
        }
        public Item(string key) : this(key, "")
        {
        }

        public Item() : this("")
        {
        }

        public Item Clone()
        {
            return new Item(this.Key, this.CompareSign)
            {
                Value = this.Value,
                ValueArray = this.ValueArray,
                Parent = this.Parent
            };
        }
    }
}
