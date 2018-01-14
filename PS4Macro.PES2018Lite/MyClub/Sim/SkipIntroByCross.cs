using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Sim
{
    class SkipIntroByCross : Scene
    {
        public override string Name => "Sim : Skip Intro By Cross";

        private static RectMap newSeason = new RectMap()
        {
            ID = "newSeason",
            Width = 1008,
            Height = 729,
            Hash = 68717320814080
        };

        private static RectMap newSeasonFocus = new RectMap()
        {
            ID = "newSeasonFocus",
            X = 361,
            Y = 301,
            Width = 286,
            Height = 20,
            Hash = 9187192606750703487
        };

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
            Hash = 9187167584464666624
        };

        private static RectMap teamDescription = new RectMap()
        {
            ID = "teamDescription",
            Width = 1008,
            Height = 729,
            Hash = 2320398559706880
        };

        private static RectMap teamDescriptionFocus = new RectMap()
        {
            ID = "teamDescriptionFocus",
            X = 438,
            Y = 111,
            Width = 133,
            Height = 18,
            Hash = 140185576636160
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { newSeasonFocus, divisionFooter, teamDescriptionFocus });

            return script.MatchTemplate(newSeasonFocus, 98)
                || script.MatchTemplate(divisionHeader, 98) || script.MatchTemplate(divisionFooter, 98)
                || script.MatchTemplate(teamDescriptionFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
