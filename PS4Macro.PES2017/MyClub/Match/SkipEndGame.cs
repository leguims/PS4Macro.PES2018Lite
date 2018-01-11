using PS4MacroAPI;
using System.Collections.Generic;

namespace PS4Macro.PES2017.Match
{
    class SkipEndGame : Scene
    {
        public override string Name => "Match : Skip End-Game";

        private static RectMap stats1 = new RectMap()
        {
            ID = "stats1",
            Width = 1008,
            Height = 729,
            Hash = 17873391532998462
        };

        private static RectMap stats1FocusHeader = new RectMap()
        {
            ID = "stats1FocusHeader",
            X = 436,
            Y = 108,
            Width = 135,
            Height = 78,
            Hash = 35887507612573468
        };

        private static RectMap stats1FocusFooter = new RectMap()
        {
            ID = "stats1FocusFooter",
            X = 147,
            Y = 507,
            Width = 713,
            Height = 78,
            Hash = 31365953601105767
        };

        private static RectMap experience = new RectMap()
        {
            ID = "experience",
            Width = 1008,
            Height = 729,
            Hash = 140187724087296
        };

        private static RectMap experienceLevelUp = new RectMap()
        {
            ID = "experienceLevelUp",
            Width = 1008,
            Height = 729,
            Hash = 280315099684864
        };

        private static RectMap teamRank = new RectMap()
        {
            ID = "teamRank",
            X = 329,
            Y = 151,
            Width = 342,
            Height = 32,
            Hash = 140185576636000
        };

        private static RectMap earnings1 = new RectMap()
        {
            ID = "earnings1",
            Width = 1008,
            Height = 729,
            Hash = 68442442891264
        };

        private static RectMap earnings1Focus = new RectMap()
        {
            ID = "earnings1Focus",
            X = 366,
            Y = 187,
            Width = 277,
            Height = 32,
            Hash = 35886960019144575
        };

        private static RectMap earnings2Focus = new RectMap()
        {
            ID = "earnings2Focus",
            X = 366,
            Y = 210,
            Width = 277,
            Height = 32,
            Hash = 35886960019144575
        };

        private static RectMap managerExtension = new RectMap()
        {
            ID = "managerExtension",
            Width = 1008,
            Height = 729,
            Hash = 278111764639744
        };

        private static RectMap seasonResults = new RectMap()
        {
            ID = "seasonResults",
            Width = 1008,
            Height = 729,
            Hash = 68719468297728
        };

        private static RectMap seasonResultsFocus = new RectMap()
        {
            ID = "seasonResultsFocus",
            X = 142,
            Y = 151,
            Width = 253,
            Height = 26,
            Hash = 1647111536511
        };

        private static RectMap seasonMaintain = new RectMap()
        {
            ID = "seasonMaintain",
            Width = 1008,
            Height = 729,
            Hash = 26938026426368
        };

        private static RectMap seasonMaintainFocus = new RectMap()
        {
            ID = "seasonMaintainFocus",
            X = 368,
            Y = 313,
            Width = 188,
            Height = 18,
            Hash = 9187201402835861375
        };

        private static RectMap seasonPromote = new RectMap()
        {
            ID = "seasonPromote",
            Width = 1008,
            Height = 729,
            Hash = 68719468281856
        };

        private static RectMap seasonPromoteFocus = new RectMap()
        {
            ID = "seasonPromoteFocus",
            X = 386,
            Y = 373,
            Width = 158,
            Height = 18,
            Hash = 9187201402835861375
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { stats1, stats1FocusHeader, stats1FocusFooter, experience, experienceLevelUp,
                earnings1Focus, earnings2Focus, managerExtension, seasonResultsFocus, seasonMaintainFocus });

            return script.MatchTemplate(stats1FocusFooter, 98) || script.MatchTemplate(experience, 98) 
                || script.MatchTemplate(experienceLevelUp, 98) || script.MatchTemplate(teamRank, 98)
                || script.MatchTemplate(earnings1Focus, 98) || script.MatchTemplate(earnings2Focus, 98)
                || script.MatchTemplate(managerExtension, 98) || script.MatchTemplate(seasonResultsFocus, 98)
                || script.MatchTemplate(seasonMaintainFocus, 98) || script.MatchTemplate(seasonPromoteFocus, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Cross = true });
    }
}
