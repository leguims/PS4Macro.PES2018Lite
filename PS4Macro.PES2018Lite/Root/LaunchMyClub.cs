using PS4MacroAPI;
using System;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Root
{
    class LaunchMyClub : Scene
    {
        public override string Name => "Root : Launch 'MyClub'";

        private static RectMap myClub = new RectMap()
        {
            ID = "myClub",
            Width = 1008,
            Height = 729,
            Hash = 31336081358592
        };

        private static RectMap myClubFocus = new RectMap()
        {
            ID = "myClubFocus",
            X = 55,
            Y = 190,
            Width = 289,
            Height = 361,
            Hash = 18859096170037247
        };

        private static RectMap myClubFocus2 = new RectMap()
        {
            ID = "myClubFocus2",
            X = 62,
            Y = 322,
            Width = 75,
            Height = 25,
            Hash = 9220964140883935103
        };

        private static RectMap noOnlineUpdate = new RectMap()
        {
            ID = "noOnlineUpdate",
            Width = 1008,
            Height = 729,
            Hash = 26938026426368
        };

        private static RectMap noOnlineUpdateFocus = new RectMap()
        {
            ID = "noOnlineUpdateFocus",
            X = 261,
            Y = 292,
            Width = 485,
            Height = 116,
            Hash = 35887507618889571
        };

        private static RectMap eventNewYearFocus = new RectMap()
        {
            ID = "eventNewYearFocus",
            X = 444,
            Y = 506,
            Width = 120,
            Height = 27,
            Hash = 9187131310043299967
        };

        private static RectMap dailyBonusFocus = new RectMap()
        {
            ID = "dailyBonusFocus",
            X = 409,
            Y = 151,
            Width = 191,
            Height = 31,
            Hash = 35887029006925695
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { myClubFocus2, noOnlineUpdateFocus, eventNewYearFocus, dailyBonusFocus });

            return script.MatchTemplate(myClubFocus2, 98) || script.MatchTemplate(noOnlineUpdateFocus, 98)
                || script.MatchTemplate(eventNewYearFocus, 98) || script.MatchTemplate(dailyBonusFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
