using PS4MacroAPI;
using System;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Root
{
    class SkipIntro : Scene
    {
        public override string Name => "Root : Skip Intro";

        private static RectMap konami = new RectMap()
        {
            ID = "Root-SkipIntro-konami.png",
            Width = 1008,
            Height = 729,
            Hash = 281474976710400
        };

        private static RectMap konamiFocus = new RectMap()
        {
            ID = "Root-SkipIntro-konamiFocus.png",
            X = 281,
            Y = 327,
            Width = 443,
            Height = 76,
            Hash = 6881340176051876703
        };

        private static RectMap thePitchIsOurs = new RectMap()
        {
            ID = "Root-SkipIntro-thePitchIsOurs.png",
            Width = 1008,
            Height = 729,
            Hash = 267332091904
        };

        private static RectMap onlineNewsHeaderFocus = new RectMap()
        {
            ID = "Root-SkipIntro-onlineNewsHeaderFocus.png",
            X = 143,
            Y = 153,
            Width = 246,
            Height = 28,
            Hash = 984610506751747
        };

        private static RectMap onlineUpdatePlayersFocus = new RectMap()
        {
            ID = "Root-SkipIntro-onlineUpdatePlayersFocus.png",
            X = 56,
            Y = 144,
            Width = 896,
            Height = 42,
            Hash = 8477777955094078
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { konami, konamiFocus, thePitchIsOurs, onlineNewsHeaderFocus, onlineUpdatePlayersFocus });

            return script.MatchTemplate(konami, 98) && script.MatchTemplate(konamiFocus, 98) 
                || script.MatchTemplate(thePitchIsOurs, 98)
                || script.MatchTemplate(onlineNewsHeaderFocus, 98)
                || script.MatchTemplate(onlineUpdatePlayersFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
