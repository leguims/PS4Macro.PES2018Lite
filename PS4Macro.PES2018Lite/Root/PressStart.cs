using PS4MacroAPI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4Macro.PES2018Lite.Root
{
    class PressStart : Scene
    {
        public override string Name => "Root : Press start";
        public static bool Debug = false; /* true; */

        private static RectMap pressStartScreen = new RectMap()
        {
            /* Remote screen size : 1024 x 768 */
            ID = "Root-PressStart-pressStartScreen.png",
            Width = 1008,
            Height = 729,
            Hash = 140737488291840
        };

            public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { pressStartScreen });

            return script.MatchTemplate(pressStartScreen, 98);
        }

        public override void OnMatched(ScriptBase script) => script.Press(new DualShockState() { Circle = true });
    }
}
