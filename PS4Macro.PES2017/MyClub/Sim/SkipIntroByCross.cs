using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2017.Sim
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
            Log.LogMatchTemplate(script, Name, new List<RectMap> { newSeasonFocus, teamDescriptionFocus });

            return script.MatchTemplate(newSeasonFocus, 98) || script.MatchTemplate(teamDescriptionFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
