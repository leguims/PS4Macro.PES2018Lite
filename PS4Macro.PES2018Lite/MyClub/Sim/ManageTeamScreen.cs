using PS4MacroAPI;
using System.Threading;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Sim
{
    class ManageTeamScreen : Scene
    {
        public override string Name => "Sim : Manage Team Screen";

        private static RectMap manageteamfocus1 = new RectMap()
        {
            ID = "Sim-ManageTeamScreen-manageteamfocus1.png",
            X = 79,
            Y = 212,
            Width = 66,
            Height = 73,
            Hash = 7949736401058878
        };

        private static RectMap manageteamfocus2 = new RectMap()
        {
            ID = "Sim-ManageTeamScreen-manageteamfocus2.png",
            X = 68,
            Y = 529,
            Width = 43,
            Height = 51,
            Hash = 68437053160960
        };

        private static RectMap manageteamfocus3 = new RectMap()
        {
            ID = "Sim-ManageTeamScreen-manageteamfocus3.png",
            X = 594,
            Y = 529,
            Width = 44,
            Height = 50,
            Hash = 31045067881472
        };

        private static RectMap team_WinOne_Focus = new RectMap()
        {
            ID = "Sim-ManageTeamScreen-team-Win1-Focus.png",
            X = 290,
            Y = 110,
            Width = 60,
            Height = 25,
            Hash = 31931456158530816
        };

        private static RectMap teamWinTwo_Focus = new RectMap()
        {
            ID = "Sim-ManageTeamScreen-team-WinTwo-Focus.png",
            X = 290,
            Y = 110,
            Width = 95,
            Height = 25,
            Hash = 30505398200925952
        };

        private static RectMap team_LoseOne_Focus = new RectMap()
        {
            ID = "Sim-ManageTeamScreen-team-Lose1-Focus.png",
            X = 290,
            Y = 110,
            Width = 70,
            Height = 25,
            Hash = 282846140825344
        };

        private static RectMap team_LoseTwo_Focus = new RectMap()
        {
            ID = "Sim-ManageTeamScreen-team-LoseTwo-Focus.png",
            X = 290,
            Y = 110,
            Width = 105,
            Height = 25,
            Hash = 1130845553295104
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { manageteamfocus1, manageteamfocus2, manageteamfocus3 }, 95);

            return script.MatchTemplate(manageteamfocus1, 95) && script.MatchTemplate(manageteamfocus2, 95) && script.MatchTemplate(manageteamfocus3, 95);
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
                        script.Press(new DualShockState() { Cross = true });
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
                    script.Press(new DualShockState() { Cross = true });
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
            script.Press(new DualShockState() { Triangle = true });
            script.Press(new DualShockState() { DPad_Down = true });
            script.Press(new DualShockState() { Circle = true });
            /*while (!script.MatchTemplate(script.CaptureFrame(), ????, 98))
            {
                Thread.Sleep(1000);
                Log.LogMessage(Name, "Waiting for 'Select team menu'");
            }*/
            // TODO : CAPTURE THE PICTURE !!
            Thread.Sleep(5000);

            if (team == MyClub.Sim.AutomateMatch.Team.winTwo)
            {
                /* Select Team.win2 - Add short pause between same key */
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Circle = true });
            }
            if (team == MyClub.Sim.AutomateMatch.Team.winOne)
            {
                /* Select Team.win1 - Add short pause between same key */
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Circle = true });
            }
             if (team == MyClub.Sim.AutomateMatch.Team.loseTwo)
            {
                /* Select Team.lose2 - Add short pause between same key */
                script.Press(new DualShockState() { DPad_Down = true });
                Thread.Sleep(100);
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Circle = true });
            }
            else if (team == MyClub.Sim.AutomateMatch.Team.loseOne)
            {
                /* Select Team.lose1 - Add short pause between same key */
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Circle = true });
            }

            Log.LogMessage(Name, "Switch to team " + team.ToString() + " : OK.");
        }
    }
}
