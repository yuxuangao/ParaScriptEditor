using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaScriptEditor
{
    internal class Key
    {
        public string Name { get; set; }
        public String Description { get; set; }
        public Scope[] Scope { get; set; }
        public ValueType[] ValueType { get; set; }
        public Category Category { get; set; }

        public Key(string name, string description, Scope[] scope, ValueType[] valueType, Category category)
        {
            Name = name;
            Description = description;
            Scope = scope;
            ValueType = valueType;
            Category = category;
        }

        public Key(string name, string description, Scope[] scope, ValueType valueType, Category category)
            : this(name, description, scope, new ValueType[] { valueType }, category)
        {
        }

        public Key(string name, string description, Scope scope, ValueType[] valueType, Category category)
           : this(name, description, new Scope[] { scope }, valueType, category)
        {
        }

        public Key(string name, string description, Scope scope, ValueType valueType, Category category)
           : this(name, description, new Scope[] { scope }, new ValueType[] { valueType }, category)
        {
        }

        public string GetScopeString()
        {
            return string.Join('/', Scope);
        }

        public string GetValueTypeString()
        {
            return string.Join('/', ValueType);
        }

        public string GetCategoryString()
        {
            return Category.ToString();
        }
    }
}
