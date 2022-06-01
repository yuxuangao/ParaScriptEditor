using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaScriptEditor
{
    internal class FileReader
    {
        public static List<Item> Read(string filePath)
        {
            List<Item> result = new();
            Stack<Item> stack = new();

            string word = "";
            bool isWaitValue = false;
            bool isComment = false;

            string allText = File.ReadAllText(filePath);
            for (int i = 0; i < allText.Length; i++)
            {
                char c = allText[i];
                if (isComment)
                {
                    if (Const.changeLineChar.Contains(c))
                    {
                        isComment = false;
                    }
                }
                else if (c == Const.commentStart)
                {
                    isComment = true;
                }
                else if (!Const.wordEndChar.Contains(c))
                {
                    word += c;
                }
                else if (Const.compareChar.Contains(c))
                {
                    string compareSign = c.ToString();
                    if (i + 1 < allText.Length && Const.compareChar.Contains(allText[i + 1]))
                    {
                        compareSign += allText[i + 1];
                        i++;
                    }
                    Item item = new (word, compareSign);
                    if (stack.TryPeek(out Item? stackItem))
                    {
                        item.Parent = stackItem;
                        stackItem.ValueArray.Add(item);
                    }
                    else
                    {
                        result.Add(item);
                    }

                    isWaitValue = true;
                    word = "";
                }
                else if (c == Const.bracketLeft)
                {
                    if (stack.TryPeek(out Item? stackItem))
                    {
                        stack.Push(stackItem.ValueArray.Last());
                    } 
                    else
                    {
                        stack.Push(result.Last());    
                    }

                    isWaitValue = false;
                    word = "";
                }
                else if (c == Const.bracketRight)
                {
                    if (isWaitValue && word.Length > 0)
                    {
                        if (stack.TryPeek(out Item? stackItem))
                        {
                            stackItem.ValueArray.Last().Value = word;
                        }
                        else
                        {
                            result.Last().Value = word;
                        }
                    }

                    if (!stack.TryPop(out _))
                    {
                        throw new ReadFailException();
                    }

                    isWaitValue = false;
                    word = "";
                }
                else if (isWaitValue && word.Length > 0)
                {
                    if (stack.TryPeek(out Item? stackItem))
                    {
                        stackItem.ValueArray.Last().Value = word;
                    }
                    else
                    {
                        result.Last().Value = word;
                    }

                    isWaitValue = false;
                    word = "";
                }
            }

            return result;
        }

        public static bool ReadInput(string input, Item item)
        {
            if (input.Length < 0)
            {
                return false;
            }
            if (input.Contains(Const.bracketLeft) || input.Contains(Const.bracketRight))
            {
                return false;
            }

            int compareSignIndex = input.IndexOfAny(Const.compareChar);
            if (compareSignIndex < 0)
            {
                item.Key = input;
                item.CompareSign = "=";
                item.Value = null;
                return true;
            }

            if (item.ValueArray.Count > 0)
            {
                return false;
            }

            string compareSign = input[compareSignIndex].ToString();
            if (compareSignIndex + 1 < input.Length && Const.compareChar.Contains(input[compareSignIndex + 1]))
            {
                compareSign += input[compareSignIndex + 1];
            }
            string key = input[..compareSignIndex].Trim();
            string value = input[(compareSignIndex + compareSign.Length)..].Trim();
            if (key.Length <= 0 || value.Length <= 0)
            {
                return false;
            }

            item.Key = key;
            item.CompareSign = compareSign;
            item.Value = value;

            return true;
        }

        public static string Translate(Item item)
        {
            string result = "";
            if (Translation.logicCommandMap.ContainsKey(item.Key))
            {
                result += Translation.logicCommandMap[item.Key];
            }
            else if (Translation.triggerMap.ContainsKey(item.Key))
            {
                result += Translation.triggerMap[item.Key].Description;
            }
            else if (Translation.commandMap.ContainsKey(item.Key))
            {
                result += Translation.commandMap[item.Key].Description;
            }
            else
            {
                result += item.Key;
            }

            if (item.Value != null)
            {
                result += " " + item.CompareSign + " " + item.Value;
            }
            else if (!item.CompareSign.Equals("="))
            {
                result += " " + item.CompareSign;
            }
            
            return result;
        }
    }
}
