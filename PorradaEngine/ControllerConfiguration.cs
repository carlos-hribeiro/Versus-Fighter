using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace PorradaEngine
{
    /// <summary>
    /// Engloba as teclas existentes
    /// </summary>
    public class ControllerConfiguration
    {

        //movimento
        public Keys Left{ get; set; }
        public Keys Right{ get; set; }

        //golpes
        public Keys HardPunch { get; set;}

    }
}
