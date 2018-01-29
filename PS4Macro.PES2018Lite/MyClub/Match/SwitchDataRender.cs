using PS4MacroAPI;
using System.Threading;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Match
{
    class SwitchDataRender : Scene
    {
        public override string Name => "Match : Switch to data rendering";

        private static RectMap classicFocus = new RectMap()
        {
            ID = "Match-SwitchDataRender-classicFocus.png",
            X = 796,
            Y = 139,
            Width = 157,
            Height = 31,
            Hash = 70916344070144
        };

        private static RectMap data = new RectMap()
        {
            ID = "Match-SwitchDataRender-data.png",
            Width = 1008,
            Height = 729,
            Hash = 131270902251264
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { classicFocus, data });

            return script.MatchTemplate(classicFocus, 98) && !script.MatchTemplate(data, 98)    /* classic screen */
                || !script.MatchTemplate(classicFocus, 98) && script.MatchTemplate(data, 98);   /* data screen */
        }

        public override void OnMatched(ScriptBase script)
        {
            if(script.MatchTemplate(classicFocus, 98) && !script.MatchTemplate(data, 98))
            {
                script.Press(new DualShockState() { Triangle = true });
                /* To restart AutomateMatch next time */
                MyClub.Sim.AutomateMatch.Instance.MatchDone();

                /* Register Match and date */
                Log.Log2File(Name, "Starting match");
            }
            else if(!script.MatchTemplate(classicFocus, 98) && script.MatchTemplate(data, 98))
            {
                /* To keep PS4 alive while waiting end of match */
                script.Press(new DualShockState() { Square = true });
                Log.LogMessage(Name, "Waiting end of match ...");
                Thread.Sleep(5000);
            }
        }
    }
}
