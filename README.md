# PS4Macro.PES2017

Bot script for PES2017 simulator mode using [PS4 Macro](https://github.com/komefai/PS4Macro).

#### Screenshot

None

#### Demo Video

None

## Features

- Launch MyClub
- Launch match
- Skip all screen
- Renew player/manager with GP money
- Switch team every match (need 2 teams)
- log into file time for starting and ending match

## Install & Compile
1. From [PS4 Macro](https://github.com/komefai/PS4Macro), copy the file PS4MacroAPI.dll to [repository root]\PS4Macro.PES2018Lite\dll
2. Compile the solution

## Usage

1. Open PS4Macro.PES2018Lite.dll in PS4 Macro.
2. Press play

### Scenario level up and down

Name 4 teams :
- "Win1" and "WinTwo" (usually strongest teams to level up)
- "Lose1" and "LoseTwo" (usually weakest teams to level down)
The loop will switch between these two teams every match (Win1<=>WinTwo or Lose1<=>LoseTwo). It gives recovery time to players. Usually, use "Lose*" teams to level down and "Win*" to level up. But if your strongest team is "lose1", it will level up !

In "class ManageTeamScreen", you have to adjust (X, Y) coordinates with your club length name, specifically the X. The RecMap to adjsut are :
- team_WinOne_Focus
- teamWinTwo_Focus
- team_LoseOne_Focus
- team_LoseTwo_Focus

In "class ManageTeamScreen", you have to modify the method "SwitchTeam" to adjust the number of "digital pad down" to apply to select each team.

## To-Do List

- Rename picture name for traceability to C# code.
- Stop play when cash is lower than 10.000
- Display history (cash, renew players name/cost, match score, list of opponent players/level, cash earning)
- Display debug on nice window
- Use OCR instead of picture recognition


## Resources

None

## Credits

- [PS4 Macro](https://github.com/komefai/PS4Macro)
