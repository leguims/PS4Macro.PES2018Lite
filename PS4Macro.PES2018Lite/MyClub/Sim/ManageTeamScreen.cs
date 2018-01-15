using PS4MacroAPI;
using System.Threading;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Sim
{
    class ManageTeamScreen : Scene
    {
        public override string Name => "Sim : Manage Team Screen";

        private static RectMap manageteam = new RectMap()
        {
            ID = "manageTeam",
            Width = 1008,
            Height = 729,
            Hash = 137426018008064
        };

        private static RectMap manageteamfocus1 = new RectMap()
        {
            ID = "manageteamfocus1",
            X = 75,
            Y = 210,
            Width = 74,
            Height = 74,
            Hash = 7947537377664062
        };

        private static RectMap manageteamfocus2 = new RectMap()
        {
            ID = "manageteamfocus2",
            X = 63,
            Y = 525,
            Width = 54,
            Height = 60,
            Hash = 9187515436292145281
        };

        private static RectMap manageteamfocus3 = new RectMap()
        {
            ID = "manageteamfocus3",
            X = 590,
            Y = 525,
            Width = 52,
            Height = 59,
            Hash = 18410861084870082688
        };

        private static RectMap team_WinOne_Focus = new RectMap()
        {
            ID = "team-Win1-Focus",
            X = 407,
            Y = 111,
            Width = 91,
            Height = 21,
            Hash = 28266779591343228
        };

        private static RectMap teamWinTwo_Focus = new RectMap()
        {
            ID = "team-WinTwo-Focus",
            X = 407,
            Y = 111,
            Width = 91,
            Height = 21,
            Hash = 12455815319355199
        };

        private static RectMap team_LoseOne_Focus = new RectMap()
        {
            ID = "team-Lose1-Focus",
            X = 408,
            Y = 111,
            Width = 98,
            Height = 21,
            Hash = 1130556661988604
        };

        private static RectMap team_LoseTwo_Focus = new RectMap()
        {
            ID = "team-LoseTwo-Focus",
            X = 408,
            Y = 111,
            Width = 100,
            Height = 21,
            Hash = 1130569597419519
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { manageteamfocus1, manageteamfocus2, manageteamfocus3 });

            return script.MatchTemplate(manageteamfocus1, 98) && script.MatchTemplate(manageteamfocus2, 98) && script.MatchTemplate(manageteamfocus3, 98);
        }

        public override void OnMatched(ScriptBase script)
        {
            MyClub.Sim.AutomateMatch.ManageTeamAction action = MyClub.Sim.AutomateMatch.Instance.ActionForManageTeam();
            switch (action)
            {
                case MyClub.Sim.AutomateMatch.ManageTeamAction.readTeamNumber:
                    Log.LogMessage(Name, "Read team number.");
                    Log.LogMatchTemplate(script, Name, new List<RectMap> { team_WinOne_Focus, teamWinTwo_Focus, team_LoseOne_Focus, team_LoseTwo_Focus });

                    MyClub.Sim.AutomateMatch.Team t;
                    if (script.MatchTemplate(team_WinOne_Focus, 98))
                        t = MyClub.Sim.AutomateMatch.Team.winOne;
                    else if (script.MatchTemplate(teamWinTwo_Focus, 98))
                        t = MyClub.Sim.AutomateMatch.Team.winTwo;
                    else if (script.MatchTemplate(team_LoseOne_Focus, 98))
                        t = MyClub.Sim.AutomateMatch.Team.loseOne;
                    else if (script.MatchTemplate(team_LoseTwo_Focus, 98))
                        t = MyClub.Sim.AutomateMatch.Team.loseTwo;
                    else
                        t = MyClub.Sim.AutomateMatch.Team.unknown;
                    if (t != MyClub.Sim.AutomateMatch.Team.unknown)
                    {
                        MyClub.Sim.AutomateMatch.Instance.ReadTeamNumberDone(t);
                        Log.LogMessage(Name, "Read team number = " + t.ToString()); Thread.Sleep(5000);
                    }
                    else
                    {
                        script.Press(new DualShockState() { Circle = true });
                        Log.LogMessage(Name, "Failed to read team number.");
                    }
                    break;
                case MyClub.Sim.AutomateMatch.ManageTeamAction.switchTeams:
                    MyClub.Sim.AutomateMatch.Team from, to;
                    from = MyClub.Sim.AutomateMatch.Instance.TeamNumber;
                    switch (from)
                    {
                        case MyClub.Sim.AutomateMatch.Team.loseOne:
                            to = MyClub.Sim.AutomateMatch.Team.loseTwo;
                            break;
                        case MyClub.Sim.AutomateMatch.Team.loseTwo:
                            to = MyClub.Sim.AutomateMatch.Team.loseOne;
                            break;
                        case MyClub.Sim.AutomateMatch.Team.winOne:
                            to = MyClub.Sim.AutomateMatch.Team.winTwo;
                            break;
                        case MyClub.Sim.AutomateMatch.Team.winTwo:
                            to = MyClub.Sim.AutomateMatch.Team.winOne;
                            break;
                        case MyClub.Sim.AutomateMatch.Team.unknown:
                        default:
                            to = MyClub.Sim.AutomateMatch.Team.unknown;
                            break;
                    }
                    Log.LogMessage(Name, "Switch from team " + from.ToString() + " to " + to.ToString() + ".");
                    SwitchTeam(script, to);
                    MyClub.Sim.AutomateMatch.Instance.SwitchTeamDone();
                    break;
                case MyClub.Sim.AutomateMatch.ManageTeamAction.exit:
                    Log.LogMessage(Name, "Exit manage team.");
                    script.Press(new DualShockState() { Circle = true });
                    MyClub.Sim.AutomateMatch.Instance.ExitManageTeamDone();
                    break;
                case MyClub.Sim.AutomateMatch.ManageTeamAction.none:
                default:
                    Log.LogMessage(Name, "No action to do.");
                    break;
            }
        }

        private void SwitchTeam(ScriptBase script, MyClub.Sim.AutomateMatch.Team team)
        {
            if (team == MyClub.Sim.AutomateMatch.Team.winTwo)
            {
                script.Press(new DualShockState() { Triangle = true });
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
                Thread.Sleep(5000);
                /* Select Team.win2 - Add short pause between same key */
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
            }
            if (team == MyClub.Sim.AutomateMatch.Team.winOne)
            {
                script.Press(new DualShockState() { Triangle = true });
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
                Thread.Sleep(5000);
                /* Select Team.win1 - Add short pause between same key */
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
            }
             if (team == MyClub.Sim.AutomateMatch.Team.loseTwo)
            {
                script.Press(new DualShockState() { Triangle = true });
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
                Thread.Sleep(5000);
                /* Select Team.lose2 - Add short pause between same key */
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
            }
            else if (team == MyClub.Sim.AutomateMatch.Team.loseOne)
            {
                script.Press(new DualShockState() { Triangle = true });
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
                Thread.Sleep(5000);
                /* Select Team.lose1 - Add short pause between same key */
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
            }

            Log.LogMessage(Name, "Switch to team " + team.ToString() + " : OK.");
        }
    }
}
