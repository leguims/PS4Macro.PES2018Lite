using PS4MacroAPI;
using System.Threading;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Match
{
    class AcceptNewContract : Scene
    {
        public override string Name => "Match : Accept New Contract Player/Manager";

        private static RectMap extension = new RectMap()
        {
            ID = "Match-AcceptNewContract-extension.png",
            Width = 1008,
            Height = 729,
            Hash = 68442442891264
        };

        private static RectMap extensionFocusHeader = new RectMap()
        {
            ID = "Match-AcceptNewContract-extensionHeader.png",
            X = 255,
            Y = 229,
            Width = 495,
            Height = 90,
            Hash = 28006088003583871
        };

        private static RectMap extensionManager = new RectMap()
        {
            ID = "Match-AcceptManagerNewContract-extension.png",
            Width = 1008,
            Height = 729,
            Hash = 26938026426368
        };

        private static RectMap extensionManagerFocusHeader = new RectMap()
        {
            ID = "Match-AcceptManagerNewContract-extensionHeader.png",
            X = 278,
            Y = 289,
            Width = 450,
            Height = 40,
            Hash = 35747869642146625
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { extension, extensionFocusHeader, extensionManager, extensionManagerFocusHeader });

            return script.MatchTemplate(extension, 98) || script.MatchTemplate(extensionFocusHeader, 98)
                || script.MatchTemplate(extensionManager, 98) || script.MatchTemplate(extensionManagerFocusHeader, 98);
        }

        public override void OnMatched(ScriptBase script)
        {
            // List of player to renew
            script.Press(new DualShockState() { DPad_Right = true });
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Accept to renew players/Manager");
            // Cost and kind of money
            Thread.Sleep(5000);
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Pay with GP money");
            // Confirmation
            Thread.Sleep(5000);
            script.Press(new DualShockState() { DPad_Right = true });
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Confirm");
            // Transaction'status
            Thread.Sleep(5000);
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Skip transaction'status");

            /* Only for manager */
            if (script.MatchTemplate(extensionManagerFocusHeader, 98))
            {
                // Transaction'status 2
                Thread.Sleep(5000);
                script.Press(new DualShockState() { Cross = true });
                Log.LogMessage(Name, "Skip transaction'status 2");
            }
        }
    }
}
