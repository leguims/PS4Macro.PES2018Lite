using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2017.Match
{
    class SkipHalfTime : Scene
    {
        public override string Name => "Match : Skip Half-Time";

        private static RectMap stats1 = new RectMap()
        {
            ID = "stats1",
            Width = 1008,
            Height = 729,
            Hash = 139086048231168
        };

        private static RectMap stats1Header = new RectMap()
        {
            ID = "stats1Header",
            X = 461,
            Y = 156,
            Width = 86,
            Height = 22,
            Hash = 229797921753856
        };

        private static RectMap stats2Header = new RectMap()
        {
            ID = "stats2Header",
            X = 455,
            Y = 113,
            Width = 99,
            Height = 27,
            Hash = 27161783340859138
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { stats1Header, stats2Header });

            return script.MatchTemplate(stats1Header, 98) || script.MatchTemplate(stats2Header, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
