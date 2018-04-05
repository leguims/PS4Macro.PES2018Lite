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
            Hash = 3998993059459137407
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
            Hash = 9187062031147073536
        };

        private static RectMap teamDescriptionFocus = new RectMap()
        {
            ID = "Sim-SkipIntroByCross-teamDescriptionFocus.png",
            X = 444,
            Y = 111,
            Width = 120,
            Height = 17,
            Hash = 18154584086118144
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { newSeasonFocus, divisionHeader, divisionFooter, teamDescriptionFocus });

            return script.MatchTemplate(newSeasonFocus, 98)
                || script.MatchTemplate(divisionHeader, 98) && script.MatchTemplate(divisionFooter, 98)
                || script.MatchTemplate(teamDescriptionFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Circle = true });
    }
}
