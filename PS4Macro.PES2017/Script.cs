using PS4MacroAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PS4Macro.PES2017
{
    public class Script : ScriptBase
    {
        /* Constructor */
        public Script()
        {
            Config.Name = "PES 2017 script";
            Config.TargetSize = new Size(1024, 768);
            Config.Scenes = new List<Scene>()
            {
                new Root.SkipIntro(),
                new Root.PressStart(),
                new Root.LaunchMyClub(),
                new Match.SwitchDataRender(),
                new Match.SkipHalfTime(),
                new Match.SkipMajorEvent(),
                new Match.SkipEndGame(),
                new Match.AcceptNewContract(),
                new Sim.ClubHouseScreen(),
                new Sim.ManageTeamScreen(),
                new Sim.SkipIntroByCross(),
                new Sim.SkipIntroByOption(),
                new Sim.SkipEndGame(),
            };
            // Print version
            Console.WriteLine("{0} version {1}", typeof(Script).Assembly.GetName().Name, typeof(Script).Assembly.GetName().Version);                    /* to print to the built-in console */
            System.Diagnostics.Debug.WriteLine("{0} version {1}", typeof(Script).Assembly.GetName().Name, typeof(Script).Assembly.GetName().Version);   /* to print to "Output" console in Visual Studio. */
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            /* Here, script's treatments */
            HandleScenes( scene =>
            {
                Console.WriteLine(scene.Name);
                System.Diagnostics.Debug.WriteLine(scene.Name);

            });
        }
    }
}
