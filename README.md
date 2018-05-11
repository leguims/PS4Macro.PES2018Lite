# PS4Macro.PES2018

Bot script for PES2017 simulator mode using [PS4 Macro](https://github.com/komefai/PS4Macro).

This project will end with new version of PES 2019. PES 2019 release date for PS4 is August 30 ([source](https://www.express.co.uk/entertainment/gaming/957401/PES-2019-release-date-PS4-Xbox-One-Switch-FIFA-19)).

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

## Available versions

- French : [V1.0-fr](https://github.com/leguims/PS4Macro.PES2018Lite/releases/tag/V1.0)
- English : [V1.0-en](https://github.com/leguims/PS4Macro.PES2018Lite/releases/tag/V1.0-en) by [hara88](https://github.com/hara88)

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

## Translate another version

I give you an example for "Root-LaunchMyClub-myClubFocus.png":

1. If file is named like "XXX**Focus**.png", it means that is a focused part of the file "XXX.png". In this example, "Root-LaunchMyClub-myClub**Focus**.png" is a part of "**Root-LaunchMyClub-myClub.png**".
1. You have to make the screenshot of your PES version as same as possible of "**Root-LaunchMyClub-myClub.png**".
1. Search which C# file uses the screenshot "**Root-LaunchMyClub-myClubFocus.png**" :arrow_right: **PS4Macro.PES2018Lite\PS4Macro.PES2018Lite\Root\LaunchMyClub.cs**
1. Find the RectMap using this picture :arrow_right: **myClubFocus**
    ```csharp
            private static RectMap myClubFocus = new RectMap()
            {
                ID = "Root-LaunchMyClub-myClubFocus.png",
                X = 62,
                Y = 322,
                Width = 75,
                Height = 25,
                Hash = 9220964140883935103
            };
    ```
1. Case "**XXX.png**" :
    1. Take the picture as it is.
1. Case "XXX**Focus**.png" :
    1. Crop the picture to have the "Focus" version
    1. Take coordonate of the focus part : X, Y is for the left-upper corner of area to crop.
    1. Take size of the focus part : Width, Height is for the width and height of area to crop.
1. This picture, is the one to use with de PS4Macro tools to compute checksum.
1. Update the attribute "Hash" in the RectMap with your own checksum .

Now, the program is updated with your own screenshot.

## To-Do List

- [x] Rename picture name for traceability to C# code.
- [ ] Stop play when cash is lower than 10.000
- [ ] Display history (cash, renew players name/cost, match score, list of opponent players/level, cash earning)
- [ ] Display debug on nice window
- [ ] Use OCR instead of picture recognition


## Resources

None

## Credits

- [PS4 Macro](https://github.com/komefai/PS4Macro)
