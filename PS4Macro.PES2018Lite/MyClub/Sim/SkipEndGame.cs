using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Sim
{
    class SkipEndGame : Scene
    {
        public override string Name => "Sim : Skip End-Game";

        private static RectMap division = new RectMap()
        {
            ID = "division",
            Width = 1008,
            Height = 729,
            Hash = 68719468314368
        };

        private static RectMap divisionHeader = new RectMap()
        {
            ID = "divisionHeader",
            Width = 1008,
            Height = 188,
            Hash = 1073708927
        };

        private static RectMap divisionFooter = new RectMap()
        {
            ID = "divisionFooter",
            X = 0,
            Y = 566,
            Width = 1008,
            Height = 163,
            Hash = 9187062031147073536
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { divisionHeader, divisionFooter });

            return script.MatchTemplate(divisionHeader, 98) && script.MatchTemplate(divisionFooter, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
