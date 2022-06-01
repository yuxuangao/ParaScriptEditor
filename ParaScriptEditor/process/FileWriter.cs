using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaScriptEditor
{
    internal class FileWriter
    {
        public static bool HasError(Item item)
        {
            bool hasError = false;

            foreach (Item subItem in item.ValueArray)
            {
                hasError |= HasError(subItem);
            }

            if (item.Key.Length <= 0)
            {
                hasError = true;
            }
            else if (item.Value != null && item.ValueArray.Count > 0)
            {
                hasError = true;
            }
            else if (item.Value == null && item.ValueArray.Count <= 0)
            {
                hasError = true;
            }
            else if (item.Value != null && item.Value.Length <= 0)
            {
                hasError = true;
            }

            item.HasError = hasError;

            return hasError;
        }

        public static bool HasError(List<Item> itemList)
        {
            bool hasError = false;

            foreach (Item item in itemList)
            {
                hasError |= HasError(item);
            }

            return hasError;
        }

        public static void Save(List<Item> itemList, string filePath)
        {
            string content = "";

            foreach (Item item in itemList)
            {
                content += GetItemContent(item, "");
            }

            File.WriteAllText(filePath, content);
        }

        private static string GetItemContent(Item item, string indent)
        {
            string result = indent + item.Key;

            if (item.Value != null)
            {
                result += " " + item.CompareSign + " " + item.Value;
            }
            else if (item.ValueArray.Count <= 0)
            {
                result += " = { }";
            }
            else
            {
                result += " = {\r\n";
                foreach(Item subItem in item.ValueArray)
                {
                    result += GetItemContent(subItem, indent + "\t");
                }
                result += indent + "}";
            }

            return result + "\r\n";
        }
    }
}
