using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/************************************************************************/
//Beam profile
using Spiricon.BeamGage.Automation;
using Spiricon.Interfaces.ConsoleService;
using Spiricon.TreePattern;
/************************************************************************/


namespace Monocle
{
    class BeamProfiler
    {
        // Declare the BeamGage Automation client
       private  AutomatedBeamGage beamGage;
   
       
       public void Run()
       {
           beamGage = new AutomatedBeamGage("ClientOne", false);

           //beamGage.Instance.Shutdown();
       }
    }
}
