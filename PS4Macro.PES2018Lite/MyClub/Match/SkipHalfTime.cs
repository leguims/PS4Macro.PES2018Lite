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
            Hash = 229797921753856
        };

        private static RectMap stats1Goals = new RectMap()
        {
            ID = "Match-SkipHalfTime-stats1Goals.png",
            X = 480,
            Y = 200,
            Width = 50,
            Height = 15,
            Hash = 13577036912016896
        };

        private static RectMap stats2Header = new RectMap()
        {
            ID = "Match-SkipHalfTime-stats2Header.png",
            X = 455,
            Y = 113,
            Width = 99,
            Height = 27,
            Hash = 27161783340859138
        };

        private static RectMap stats2SecondeHalftime = new RectMap()
        {
            ID = "Match-SkipHalfTime-stats2SecondeHalftime.png",
            X = 464,
            Y = 512,
            Width = 80,
            Height = 70,
            Hash = 7197829459242090367
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { stats1Header, stats1Goals, stats2Header, stats2SecondeHalftime });

            return script.MatchTemplate(stats1Header, 98) && script.MatchTemplate(stats1Goals, 98)
                || script.MatchTemplate(stats2Header, 98) && script.MatchTemplate(stats2SecondeHalftime, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
