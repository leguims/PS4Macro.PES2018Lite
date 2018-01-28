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
            X = 147,
            Y = 507,
            Width = 713,
            Height = 78,
            Hash = 31365953601105767
        };

        private static RectMap experience = new RectMap()
        {
            ID = "Match-SkipEndGame-experience.png",
            Width = 1008,
            Height = 729,
            Hash = 140187724087296
        };

        private static RectMap experienceLevelUpFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-experienceLevelUpFocus.png",
            X = 55,
            Y = 143,
            Width = 540,
            Height = 43,
            Hash = 33910008047466616
        };

        private static RectMap teamRankFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-teamRankFocus.png",
            X = 329,
            Y = 151,
            Width = 342,
            Height = 32,
            Hash = 140185576636000
        };

        private static RectMap earnings1Focus = new RectMap()
        {
            ID = "Match-SkipEndGame-earnings1Focus.png",
            X = 366,
            Y = 187,
            Width = 277,
            Height = 32,
            Hash = 35886960019144575
        };

        private static RectMap earnings2Focus = new RectMap()
        { /* WARNING !! => Same as earnings1Focus */
            ID = "Match-SkipEndGame-earnings2Focus.png",
            X = 366,
            Y = 210,
            Width = 277,
            Height = 32,
            Hash = 35886960019144575
        };

        private static RectMap managerExtensionOption = new RectMap()
        {
            ID = "Match-SkipEndGame-managerExtensionOption.png",
            Width = 1008,
            Height = 729,
            Hash = 278111764639744
        };

        private static RectMap seasonResultsFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-seasonResultsFocus.png",
            X = 142,
            Y = 151,
            Width = 253,
            Height = 26,
            Hash = 1647111536511
        };

        private static RectMap seasonMaintainFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-seasonMaintainFocus.png",
            X = 368,
            Y = 313,
            Width = 188,
            Height = 18,
            Hash = 9187201402835861375
        };

        private static RectMap seasonMaintainEarningsFocus = new RectMap()
        {
            ID = "Match-SkipEndGame-seasonMaintain-earningsFocus.png",
            X = 399,
            Y = 189,
            Width = 210,
            Height = 21,
            Hash = 9187201403311389034
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

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { stats1FocusFooter, experience, experienceLevelUpFocus, teamRankFocus,
                earnings1Focus, earnings2Focus, managerExtensionOption, seasonResultsFocus, seasonMaintainFocus, seasonMaintainEarningsFocus, seasonPromoteFocus });

            return script.MatchTemplate(stats1FocusFooter, 98) 
                || script.MatchTemplate(experience, 98) 
                || script.MatchTemplate(experienceLevelUpFocus, 98) || script.MatchTemplate(teamRankFocus, 98)
                || script.MatchTemplate(earnings1Focus, 98) || script.MatchTemplate(earnings2Focus, 98)
                || script.MatchTemplate(managerExtensionOption, 98) || script.MatchTemplate(seasonResultsFocus, 98)
                || script.MatchTemplate(seasonMaintainFocus, 98) || script.MatchTemplate(seasonMaintainEarningsFocus, 98) 
                || script.MatchTemplate(seasonPromoteFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
