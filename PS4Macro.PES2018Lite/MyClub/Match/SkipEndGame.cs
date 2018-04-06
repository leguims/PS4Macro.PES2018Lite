using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Match
{
    class SkipEndGame : Scene
    {
        public override string Name => "Match : Skip End-Game";

        private static RectMap stats1FocusFooter = new RectMap()
        {
            ID = "Match-SkipEndGame-stats1FocusFooter.png",
            X = 450,
            Y = 115,
            Width = 108,
            Height = 24,
            Hash = 35043082688757504
        };

        private static RectMap experience = new RectMap()
        {
            ID = "Match-SkipEndGame-experience.png",
            X = 65,
            Y = 150,
            Width = 133,
            Height = 33,
            Hash = 18098508993099520
        };

        private static RectMap experienceLevelUpFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-experienceLevelUpFocus.png",
            X = 55,
            Y = 143,
            Width = 540,
            Height = 43,
            Hash = 34050745518848248
        };

        private static RectMap teamRankFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-teamRankFocus.png",
            X = 393,
            Y = 149,
            Width = 213,
            Height = 34,
            Hash = 2386487832182640
        };

        private static RectMap earnings1Focus = new RectMap()
        {
            ID = "Match-SkipEndGame-earnings1Focus.png",
            X = 404,
            Y = 187,
            Width = 197,
            Height = 30,
            Hash = 35886960288497535
        };

        private static RectMap earnings2Focus = new RectMap()
        { /* WARNING !! => Same as earnings1Focus */
            ID = "Match-SkipEndGame-earnings2Focus.png",
            X = 480,
            Y = 320,
            Width = 50,
            Height = 20,
            Hash = 35781412292483967
        };

        private static RectMap managerExtensionOption = new RectMap()
        {
            ID = "Match-SkipEndGame-managerExtensionOption.png",
            Width = 1008,
            Height = 729,
            Hash = 273713718128640
        };

        private static RectMap seasonResultsFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-seasonResultsFocus.png",
            X = 142,
            Y = 151,
            Width = 182,
            Height = 26,
            Hash = 14841251069823
        };

        private static RectMap seasonMaintainFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-seasonMaintainFocus.png",
            X = 360,
            Y = 313,
            Width = 138,
            Height = 18,
            Hash = 9187201402835861375
        };

        private static RectMap seasonMaintainEarningsFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-seasonMaintain-earningsFocus.png",
            X = 414,
            Y = 198,
            Width = 179,
            Height = 29,
            Hash = 35886960019013247
        };

        private static RectMap seasonPromoteFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-seasonPromoteFocus.png",
            X = 386,
            Y = 373,
            Width = 158,
            Height = 18,
            Hash = 9187201402835861375
        };

        private static RectMap seasonPromoteEarningsFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-seasonPromoteEarningsFocus.png",
            X = 389,
            Y = 189,
            Width = 229,
            Height = 27,
            Hash = 35886961298276223
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { stats1FocusFooter, experience, experienceLevelUpFocus, teamRankFocus,
                earnings1Focus, earnings2Focus, managerExtensionOption, seasonResultsFocus, seasonMaintainFocus,
                seasonMaintainEarningsFocus, seasonPromoteFocus, seasonPromoteEarningsFocus });

            return script.MatchTemplate(stats1FocusFooter, 98) 
                || script.MatchTemplate(experience, 95) 
                || script.MatchTemplate(experienceLevelUpFocus, 98) || script.MatchTemplate(teamRankFocus, 98)
                || script.MatchTemplate(earnings1Focus, 98) || script.MatchTemplate(earnings2Focus, 98)
                || script.MatchTemplate(managerExtensionOption, 98) || script.MatchTemplate(seasonResultsFocus, 98)
                || script.MatchTemplate(seasonMaintainFocus, 98) || script.MatchTemplate(seasonMaintainEarningsFocus, 98) 
                || script.MatchTemplate(seasonPromoteFocus, 98) || script.MatchTemplate(seasonPromoteEarningsFocus, 95);
        }

        public override void OnMatched(ScriptBase script)
        {
            script.Press(new DualShockState() { Circle = true });

            if (script.MatchTemplate(seasonMaintainFocus, 98))
            {
                /* Register End of season & date */
                Log.Log2File(Name, "End of season : Maintain");
            }
            else if (script.MatchTemplate(seasonPromoteFocus, 98))
            {
                /* Register End of season & date */
                Log.Log2File(Name, "End of season : Promote");
            }
        }
    }
}
