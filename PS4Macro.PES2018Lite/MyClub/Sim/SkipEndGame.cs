using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Sim
{
    class SkipEndGame : Scene
    {
        public override string Name => "Sim : Skip End-Game";

        private static RectMap divisionHeaderFocus = new RectMap()
        {
            ID = "Sim-SkipEndGame-divisionHeaderFocus.png",
            X = 410,
            Y = 150,
            Width = 190,
            Height = 30,
            Hash = 35043082688757504
        };

        private static RectMap divisionFooterFocus = new RectMap()
        {
            ID = "Sim-SkipEndGame-divisionFooterFocus.png",
            X = 70,
            Y = 595,
            Width = 85,
            Height = 30,
            Hash = 18142489458196480
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { divisionHeaderFocus, divisionFooterFocus }, 95);

            return script.MatchTemplate(divisionHeaderFocus, 95) && script.MatchTemplate(divisionFooterFocus, 95);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Circle = true });
    }
}
