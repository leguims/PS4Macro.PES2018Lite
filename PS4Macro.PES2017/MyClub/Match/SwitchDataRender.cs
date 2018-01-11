using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2017.Match
{
    class SwitchDataRender : Scene
    {
        public override string Name => "Match : Switch to data rendering";

        private static RectMap classic = new RectMap()
        {
            ID = "classic",
            Width = 1008,
            Height = 729,
            Hash = 140737488322304
        };

        private static RectMap classicFocus = new RectMap()
        {
            ID = "classic",
            X = 796,
            Y = 139,
            Width = 157,
            Height = 31,
            Hash = 70916344070144
        };

        private static RectMap data = new RectMap()
        {
            ID = "data",
            Width = 1008,
            Height = 729,
            Hash = 131270902251264
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            //Log.LogIt(script, Name, new List<RectMap> { classicFocus, data });
            Log.LogMatchTemplate(script, Name, new List<RectMap> { classicFocus });

            return script.MatchTemplate(classicFocus, 98) && !script.MatchTemplate(data, 98);
        }

        public override void OnMatched(ScriptBase script)
        {
            script.Press(new DualShockState() { Triangle = true });
            /* To restart AutomateMatch next time */
            MyClub.Sim.AutomateMatch.Instance.MatchDone();
        }
    }
}
