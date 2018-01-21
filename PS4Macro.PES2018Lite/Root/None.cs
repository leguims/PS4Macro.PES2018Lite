using PS4MacroAPI;
using System;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Root
{
    class None : Scene
    {
        public override string Name => "Root : None";


        public override bool Match(ScriptBase script)
        {
            Log.LogMessage(Name, "### " + DateTime.Now.ToString() + " ###########################################################");

            return false;
        }

        public override void OnMatched(ScriptBase script) { }
    }
}
