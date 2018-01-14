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

        private static RectMap team1Focus = new RectMap()
        {
            ID = "team1Focus",
            X = 491,
            Y = 112,
            Width = 12,
            Height = 20,
            Hash = 2053187362082027647
        };

        private static RectMap team2Focus = new RectMap()
        {
            ID = "team2Focus",
            X = 491,
            Y = 112,
            Width = 12,
            Height = 20,
            Hash = 1764926229666064254
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
                    Log.LogMatchTemplate(script, Name, new List<RectMap> { team1Focus, team2Focus });

                    MyClub.Sim.AutomateMatch.Team t;
                    if (script.MatchTemplate(team1Focus, 98))
                        t = MyClub.Sim.AutomateMatch.Team.one;
                    else if (script.MatchTemplate(team2Focus, 98))
                        t = MyClub.Sim.AutomateMatch.Team.two;
                    else
                        t = MyClub.Sim.AutomateMatch.Team.unknown;
                    if (t != MyClub.Sim.AutomateMatch.Team.unknown)
                    {
                        MyClub.Sim.AutomateMatch.Instance.ReadTeamNumberDone(t);
                        Log.LogMessage(Name, "Read team number = " + t.ToString());
                    }
                    else
                    {
                        script.Press(new DualShockState() { Circle = true });
                        Log.LogMessage(Name, "Failed to read team number.");
                    }
                    break;
                case MyClub.Sim.AutomateMatch.ManageTeamAction.switchTeams:
                    Log.LogMessage(Name, "Switch to team " + MyClub.Sim.AutomateMatch.Instance.TeamNumber.ToString() + ".");
                    SwitchTeam(script, MyClub.Sim.AutomateMatch.Instance.TeamNumber);
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
            if (team == MyClub.Sim.AutomateMatch.Team.one)
            {
                script.Press(new DualShockState() { Triangle = true });
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
                Thread.Sleep(5000);
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
            }
            else if (team == MyClub.Sim.AutomateMatch.Team.two)
            {
                script.Press(new DualShockState() { Triangle = true });
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
                Thread.Sleep(5000);
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { DPad_Down = true });
                script.Press(new DualShockState() { Cross = true });
            }

            Log.LogMessage(Name, "Switch to team " + MyClub.Sim.AutomateMatch.Instance.TeamNumber.ToString() + " : OK.");
        }
    }
}
