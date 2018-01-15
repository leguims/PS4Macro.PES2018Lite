using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4Macro.PES2018Lite.MyClub.Sim
{
    /* SINGLETON */
    public sealed class AutomateMatch
    {
        /* <-- dedicated to make Singleton */
        private static readonly Lazy<AutomateMatch> lazy =
            new Lazy<AutomateMatch>(() => new AutomateMatch());

        public static AutomateMatch Instance { get { return lazy.Value; } }

        private AutomateMatch()
        {
            StateAutomate = State.initialized;
            TeamNumber = Team.unknown;
        }
        /* dedicated to make Singleton --> */

        /* *** INTERNAL **** */
        public string Name => "Sim : Automate For Match";
        private enum State { initialized, selectManageTeam, readTeamNumber, switchTeam, exitManageTeam, selectPlayNow, launchMatch, end };
        private State _state;
        private State StateAutomate { get => _state; set { Log.LogMessage(Name, "StateAutomate : " + _state.ToString() + " => " + value.ToString()); _state = value; } }

        /* *** EXTERNAL EVENTS **** */
        /* Carefull, there is no protection when switching state value */
        public enum Team { unknown, winOne, winTwo, loseOne, loseTwo };
        private Team _teamNumber;
        public Team TeamNumber { get => _teamNumber; set => _teamNumber = value; }

        public void SelectManageTeamDone() => StateAutomate = State.readTeamNumber;
        public void ReadTeamNumberDone(Team team)
        {
            StateAutomate = State.switchTeam;
            TeamNumber = team;
        }
        public void SwitchTeamDone() => StateAutomate = State.exitManageTeam;
        public void ExitManageTeamDone() => StateAutomate = State.selectPlayNow;
        public void SelectPlayNowDone() => StateAutomate = State.launchMatch;
        public void LaunchMatchDone() => StateAutomate = State.end;
        public void MatchDone() => StateAutomate = State.initialized;

        /* *** EXTERNAL ACTIONS **** */
        public enum ClubHouseAction { none, enterManageTeam, enterPlayNow };
        public ClubHouseAction ActionForClubHouse()
        {
            /* Return next action with internal 'StateAutomate' */
            switch (StateAutomate)
            {
                case State.exitManageTeam:
                case State.selectPlayNow:
                case State.launchMatch:
                    return ClubHouseAction.enterPlayNow;
                case State.initialized:
                case State.selectManageTeam:
                case State.readTeamNumber:
                case State.switchTeam:
                    return ClubHouseAction.enterManageTeam;
                case State.end:
                default:
                    return ClubHouseAction.none;
            }
        }

        public enum ManageTeamAction { none, readTeamNumber, switchTeams, exit };
        public ManageTeamAction ActionForManageTeam()
        {
            /* Return next action with internal 'StateAutomate' */
            switch (StateAutomate)
            {
                case State.initialized:
                case State.selectManageTeam:
                case State.readTeamNumber:
                    return ManageTeamAction.readTeamNumber;
                case State.switchTeam:
                    return ManageTeamAction.switchTeams;
                case State.exitManageTeam:
                case State.selectPlayNow:
                case State.launchMatch:
                    return ManageTeamAction.exit;
                case State.end:
                default:
                    return ManageTeamAction.none;
            }
        }
    }
}
