using PS4MacroAPI;
using System.Threading;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Match
{
    class AcceptNewContract : Scene
    {
        public override string Name => "Match :Accept New Contract";

        private static RectMap extension = new RectMap()
        {
            ID = "extension",
            Width = 1008,
            Height = 729,
            Hash = 68442442891264
        };

        private static RectMap extensionFocusHeader = new RectMap()
        {
            ID = "extensionFocusHeader",
            X = 255,
            Y = 229,
            Width = 495,
            Height = 90,
            Hash = 28006088003583871
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { extension, extensionFocusHeader });

            return script.MatchTemplate(extension, 98) || script.MatchTemplate(extensionFocusHeader, 98);
        }

        public override void OnMatched(ScriptBase script)
        {
            // List of player to renew
            script.Press(new DualShockState() { DPad_Right = true });
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Accept to renew players");
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
        }
    }
}
