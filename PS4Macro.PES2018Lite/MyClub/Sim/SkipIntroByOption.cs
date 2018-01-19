using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Sim
{
    class SkipIntroByOption : Scene
    {
        public override string Name => "Sim : Skip Intro By Option";

        private static RectMap teamName = new RectMap()
        { /* WARNING !! I DO NOT FIND THE FILE I USED ! OUPS ! */
            ID = "Sim-SkipIntroByOption-teamName",
            Width = 1008,
            Height = 729,
            Hash = 280923064987648
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { teamName });

            return script.MatchTemplate(teamName, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Options = true });
    }
}
