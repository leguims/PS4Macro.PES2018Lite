using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2017.Match
{
    class SkipMajorEvent : Scene
    {
        public override string Name => "Match : Skip Major Events";

        private static RectMap majorEvents = new RectMap()
        {
            ID = "majorEvents",
            X = 56,
            Y = 128,
            Width = 171,
            Height = 21,
            Hash = 35887386888208255
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { majorEvents });

            return script.MatchTemplate(majorEvents, 98);
        }

        public override void OnMatched(ScriptBase script)
        {
            script.Press(new DualShockState() { Options = true });

            /* Register Match and date */
            Log.Log2File(Name, "Ending match");
        }
    }
}
