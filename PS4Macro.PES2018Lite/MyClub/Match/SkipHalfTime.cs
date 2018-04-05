using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Match
{
    class SkipHalfTime : Scene
    {
        public override string Name => "Match : Skip Half-Time";

        private static RectMap stats1Header = new RectMap()
        {
            ID = "Match-SkipHalfTime-stats1Header.png",
            X = 461,
            Y = 156,
            Width = 86,
            Height = 22,
            Hash = 8020935033954304
        };

        private static RectMap stats1Goals = new RectMap()
        {
            ID = "Match-SkipHalfTime-stats1Goals.png",
            X = 460,
            Y = 200,
            Width = 40,
            Height = 16,
            Hash = 27161783340850944
        };

        private static RectMap stats2Header = new RectMap()
        {
            ID = "Match-SkipHalfTime-stats2Header.png",
            X = 455,
            Y = 115,
            Width = 43,
            Height = 20,
            Hash = 28542769676910350
        };

        private static RectMap stats2SecondeHalftime = new RectMap()
        {
            ID = "Match-SkipHalfTime-stats2SecondeHalftime.png",
            X = 475,
            Y = 565,
            Width = 60,
            Height = 15,
            Hash = 9187201713574586751
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { stats1Header, stats1Goals, stats2Header, stats2SecondeHalftime });

            return script.MatchTemplate(stats1Header, 95) && script.MatchTemplate(stats1Goals, 95)
                || script.MatchTemplate(stats2Header, 95) && script.MatchTemplate(stats2SecondeHalftime, 95);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Circle = true });
    }
}
