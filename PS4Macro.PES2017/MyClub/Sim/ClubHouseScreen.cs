using PS4MacroAPI;
using System.Threading;
using System.Collections.Generic;

namespace PS4Macro.PES2017.Sim
{
    class ClubHouseScreen : Scene
    {
        public override string Name => "Sim : Club House Screen";

        private static RectMap clubHouse = new RectMap()
        {
            ID = "clubHouse",
            Width = 1008,
            Height = 729,
            Hash = 33535104614144
        };

        private static RectMap clubHouseFocus = new RectMap()
        {
            ID = "clubHouseFocus",
            X = 280,
            Y = 160,
            Width = 223,
            Height = 16,
            Hash = 248651682955879295
        };

        private static PixelMap clubHouseSelected = new PixelMap()
        {
            ID = "clubHouseSelected",
            X = 315,
            Y = 168,
            Color = 0xbcc4c4
        };

        private static RectMap manageTeam = new RectMap()
        {
            ID = "manageTeam",
            Width = 1008,
            Height = 729,
            Hash = 33535104614144
        };

        private static RectMap manageTeamFocus = new RectMap()
        {
            ID = "manageTeamFocus",
            X = 368,
            Y = 321,
            Width = 227,
            Height = 24,
            Hash = 9187070900410728319
        };

        private static PixelMap playNowSelected = new PixelMap()
        {
            ID = "playNowSelected",
            X = 330,
            Y = 415,
            Color = 0x18fdff
        };

        private static PixelMap manageTeamSelected = new PixelMap()
        {
            ID = "manageTeamSelected",
            X = 620,
            Y = 415,
            Color = 0x18fdff
        };

        private static PixelMap memberSelected = new PixelMap()
        {
            ID = "memberSelected",
            X = 930,
            Y = 290,
            Color = 0x18fdff
        };

        private static PixelMap trainingSelected = new PixelMap()
        {
            ID = "trainingSelected",
            X = 930,
            Y = 415,
            Color = 0x18fdff
        };

        private static PixelMap historySelected = new PixelMap()
        {
            ID = "historySelected",
            X = 330,
            Y = 545,
            Color = 0x18fdff
        };

        private static PixelMap planSelected = new PixelMap()
        {
            ID = "planSelected",
            X = 620,
            Y = 545,
            Color = 0x18fdff
        };

        private static PixelMap shopSelected = new PixelMap()
        {
            ID = "shopSelected",
            X = 780,
            Y = 545,
            Color = 0x18fdff
        };

        private static PixelMap mailSelected = new PixelMap()
        {
            ID = "mailSelected",
            X = 930,
            Y = 545,
            Color = 0x18fdff
        };

        private static PixelMap noSelected = new PixelMap()
        {
            ID = "noSelected",
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { clubHouseFocus });
            Log.LogMatchTemplate(script, Name, new List<PixelMap> { clubHouseSelected });

            return script.MatchTemplate(clubHouseFocus, 98) && script.MatchTemplate(clubHouseSelected, 98);
        }

        public override void OnMatched(ScriptBase script)
        {
            MyClub.Sim.AutomateMatch.ClubHouseAction action = MyClub.Sim.AutomateMatch.Instance.ActionForClubHouse();
            switch (action)
            {
                case MyClub.Sim.AutomateMatch.ClubHouseAction.enterManageTeam:
                    Log.LogMessage(Name, "Enter to 'Manage Team'.");
                    
                    if (script.MatchTemplate(manageTeamSelected, 98))
                    {
                        script.Press(new DualShockState() { Cross = true });
                        MyClub.Sim.AutomateMatch.Instance.SelectManageTeamDone();
                    }
                    else
                        SelectManageTeam(script);
                    break;
                case MyClub.Sim.AutomateMatch.ClubHouseAction.enterPlayNow:
                    Log.LogMessage(Name, "Enter to 'Play Now'.");

                    if (script.MatchTemplate(playNowSelected, 98))
                    {
                        script.Press(new DualShockState() { Cross = true });
                        MyClub.Sim.AutomateMatch.Instance.LaunchMatchDone();
                    }
                    else
                        SelectPlayNow(script);
                    break;
                case MyClub.Sim.AutomateMatch.ClubHouseAction.none:
                default:
                    Log.LogMessage(Name, "No action to do.");
                    break;
            }
        }

        private PixelMap SelectManageTeam(ScriptBase script)
        {
            PixelMap from = noSelected, to = manageTeamSelected;

            if (script.MatchTemplate(playNowSelected, 98))
            {
                script.Press(new DualShockState() { DPad_Right = true });
                from = playNowSelected;
            }
            else if (script.MatchTemplate(manageTeamSelected, 98))
            {
                from = manageTeamSelected;
            }
            else if (script.MatchTemplate(memberSelected, 98))
            {
                script.Press(new DualShockState() { DPad_Left = true });
                from = memberSelected;
            }
            else if (script.MatchTemplate(trainingSelected, 98))
            {
                script.Press(new DualShockState() { DPad_Left = true });
                from = trainingSelected;
            }
            else if (script.MatchTemplate(historySelected, 98))
            {
                script.Press(new DualShockState() { DPad_Right = true });
                script.Press(new DualShockState() { DPad_Up = true });
                from = historySelected;
            }
            else if (script.MatchTemplate(planSelected, 98))
            {
                script.Press(new DualShockState() { DPad_Up = true });
                from = planSelected;
            }
            else if (script.MatchTemplate(shopSelected, 98))
            {
                script.Press(new DualShockState() { DPad_Up = true });
                script.Press(new DualShockState() { DPad_Left = true });
                from = shopSelected;
            }
            else if (script.MatchTemplate(mailSelected, 98))
            {
                script.Press(new DualShockState() { DPad_Up = true });
                script.Press(new DualShockState() { DPad_Left = true });
                from = mailSelected;
            }

            Log.LogMessage(Name, "Go from '" + from.ID + "' to '" + to.ID + "'");
            return from;
        }

        private PixelMap SelectPlayNow(ScriptBase script)
        {
            PixelMap from = noSelected, to = playNowSelected;
            from = SelectManageTeam(script);
            script.Press(new DualShockState() { DPad_Left = true });

            Log.LogMessage(Name, "Go from '" + from.ID + "' to '" + to.ID + "'");
            return from;
        }
    }
}
