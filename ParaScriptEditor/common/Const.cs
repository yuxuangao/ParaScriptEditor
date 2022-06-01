using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaScriptEditor
{
    internal class Const
    {
        public static readonly char[] spaceChar = { ' ', '\t' };
        public static readonly char[] changeLineChar = { '\r', '\n' };
        public static readonly char[] compareChar = { '=', '<', '>' };
        public static readonly char bracketLeft = '{';
        public static readonly char bracketRight = '}';
        public static readonly char[] wordEndChar = spaceChar.Concat(changeLineChar).Concat(compareChar)
            .Concat(new char[] { bracketLeft, bracketRight }).ToArray();
        public static readonly char commentStart = '#';
    }

    enum KeyType
    {
        all, logicCommand, trigger, command
    }

    enum Scope
    {
        any, character, title, province, artifact, bloodline, general, war, offmap
    }

    enum ValueType
    {
        any, boolean, intValue, clause, artifact, artifactType, character, province, title, bloodline,
        doubleValue, minorTitle, jobTitle, society, winterType, continent, floatValue, culture, cultureGroup,
        date, deathReason, disease, stringValue, none, government, culturegfx, flag, cb, region
    }

    enum Category
    {
        characters, titles, control, realm, alternateStart, artifacts, provinces, health, bloodlines, religion,
        traits, rulers, societies, marriage, wars, clans, culture
    }
}
