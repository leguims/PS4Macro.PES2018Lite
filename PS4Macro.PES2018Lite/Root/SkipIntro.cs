using PS4MacroAPI;
using System;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Root
{
    class SkipIntro : Scene
    {
        public override string Name => "Root : Skip Intro";

        private static RectMap konamiFS_ko = new RectMap()
        {
            ID = "konamiFS_ko",
            Width = 1008,
            Height = 729,
            Hash = 140737488291840
        };

        private static RectMap konami = new RectMap()
        {
            ID = "konami",
            Width = 1008,
            Height = 729,
            Hash = 281474976710400
        };

        private static RectMap konamiFocus = new RectMap()
        {
            ID = "konamiFocus",
            X = 281,
            Y = 327,
            Width = 443,
            Height = 76,
            Hash = 6881340176051876703
        };

        private static RectMap thePitchIsOursFS_ko = new RectMap()
        {
            ID = "thePitchIsOursFS_ko",
            Width = 1008,
            Height = 729,
            Hash = 8584986722532864
        };

        private static RectMap thePitchIsOurs = new RectMap()
        {
            ID = "thePitchIsOurs",
            Width = 1008,
            Height = 729,
            Hash = 267332091904
        };

        private static RectMap onlineNews = new RectMap()
        {
            ID = "onlineNews",
            Width = 1008,
            Height = 729,
            Hash = 68719468281856
        };

        private static RectMap onlineNewsHeader = new RectMap()
        {
            ID = "onlineNewsHeader",
            Width = 1008,
            Height = 210,
            Hash = 2139062143
        };

        private static RectMap onlineNewsHeaderFocus = new RectMap()
        {
            ID = "onlineNewsHeaderFocus",
            X = 143,
            Y = 153,
            Width = 246,
            Height = 28,
            Hash = 984610506751747
        };

        private static RectMap onlineUpdatePlayers = new RectMap()
        {
            ID = "onlineUpdatePlayers",
            Width = 1008,
            Height = 729,
            Hash = 68719468314368
        };

        private static RectMap onlineUpdatePlayersFocus = new RectMap()
        {
            ID = "onlineUpdatePlayersFocus",
            X = 56,
            Y = 144,
            Width = 896,
            Height = 42,
            Hash = 8477777955094078
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { konamiFocus, thePitchIsOurs, onlineNewsHeaderFocus, onlineUpdatePlayersFocus });

            return script.MatchTemplate(konami, 98) && script.MatchTemplate(konamiFocus, 98) 
                || script.MatchTemplate(thePitchIsOurs, 98)
                || script.MatchTemplate(onlineNewsHeaderFocus, 98)
                || script.MatchTemplate(onlineUpdatePlayersFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
