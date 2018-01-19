using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Sim
{
    class SkipIntroByCross : Scene
    {
        public override string Name => "Sim : Skip Intro By Cross";

        private static RectMap newSeasonFocus = new RectMap()
        {
            ID = "Sim-SkipIntroByCross-newSeasonFocus.png",
            X = 361,
            Y = 301,
            Width = 286,
            Height = 20,
            Hash = 9187192606750703487
        };

        private static RectMap divisionHeader = new RectMap()
        {
            ID = "Sim-SkipIntroByCross-divisionHeader.png",
            Width = 1008,
            Height = 188,
            Hash = 1073708927
        };

        private static RectMap divisionFooter = new RectMap()
        {
            ID = "Sim-SkipIntroByCross-divisionFooter.png",
            X = 0,
            Y = 566,
            Width = 1008,
            Height = 163,
            Hash = 9187167584464666624
        };

        private static RectMap teamDescriptionFocus = new RectMap()
        {
            ID = "Sim-SkipIntroByCross-teamDescriptionFocus.png",
            X = 438,
            Y = 111,
            Width = 133,
            Height = 18,
            Hash = 140185576636160
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { newSeasonFocus, divisionHeader, divisionFooter, teamDescriptionFocus });

            return script.MatchTemplate(newSeasonFocus, 98)
                || script.MatchTemplate(divisionHeader, 98) && script.MatchTemplate(divisionFooter, 98)
                || script.MatchTemplate(teamDescriptionFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
