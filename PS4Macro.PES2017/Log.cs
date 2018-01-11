using PS4MacroAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4Macro.PES2017
{
    class Log
    {
        private static bool _debug = true; /* false; */
        public static bool Debug() { return _debug; }
        public static void LogMatchTemplate(ScriptBase script, string name, List<RectMap> listRectMap)
        {
            if (_debug)
            {
                foreach (var item in listRectMap)
                {
                    if (script.MatchTemplate(item, 98))
                    {
                        Console.WriteLine("{0} : RectMap '{1}' return {2}", name, item.ID, script.MatchTemplate(item, 98).ToString());                     /* to print to the built-in console */
                        System.Diagnostics.Debug.WriteLine("{0} : RectMap '{1}' return {2}", name, item.ID, script.MatchTemplate(item, 98).ToString());    /* to print to "Output" console in Visual Studio. */
                    }
                }
            }
        }
        public static void LogMatchTemplate(ScriptBase script, string name, List<PixelMap> listPixelMap)
        {
            if (_debug)
            {
                foreach (var item in listPixelMap)
                {
                    if (script.MatchTemplate(item, 98))
                    {
                        Console.WriteLine("{0} : PixelMap '{1}' return {2}", name, item.ID, script.MatchTemplate(item, 98).ToString());                     /* to print to the built-in console */
                        System.Diagnostics.Debug.WriteLine("{0} : PixelMap '{1}' return {2}", name, item.ID, script.MatchTemplate(item, 98).ToString());    /* to print to "Output" console in Visual Studio. */
                    }
                }
            }
        }
        public static void LogMessage(string name, string text)
        {
            if (_debug)
            {
                Console.WriteLine("{0} : {1}", name, text);                     /* to print to the built-in console */
                System.Diagnostics.Debug.WriteLine("{0} : {1}", name, text);    /* to print to "Output" console in Visual Studio. */
            }
        }
    }
}
