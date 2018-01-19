using PS4MacroAPI;
using System;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Root
{
    class LaunchMyClub : Scene
    {
        public override string Name => "Root : Launch 'MyClub'";

        private static RectMap myClubFocus = new RectMap()
        {
            ID = "Root-LaunchMyClub-myClubFocus.png",
            X = 62,
            Y = 322,
            Width = 75,
            Height = 25,
            Hash = 9220964140883935103
        };

        private static RectMap noOnlineUpdateFocus = new RectMap()
        {
            ID = "Root-LaunchMyClub-noOnlineUpdateFocus.png",
            X = 261,
            Y = 292,
            Width = 485,
            Height = 116,
            Hash = 35887507618889571
        };

        private static RectMap eventNewYearFocus = new RectMap()
        {
            ID = "Root-LaunchMyClub-eventNewYearFocus.png",
            X = 444,
            Y = 506,
            Width = 120,
            Height = 27,
            Hash = 9187131310043299967
        };

        private static RectMap dailyBonusFocus = new RectMap()
        {
            ID = "Root-LaunchMyClub-dailyBonusFocus.png",
            X = 409,
            Y = 151,
            Width = 191,
            Height = 31,
            Hash = 35887029006925695
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { myClubFocus, noOnlineUpdateFocus, eventNewYearFocus, dailyBonusFocus });

            return script.MatchTemplate(myClubFocus, 98) || script.MatchTemplate(noOnlineUpdateFocus, 98)
                || script.MatchTemplate(eventNewYearFocus, 98) || script.MatchTemplate(dailyBonusFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
