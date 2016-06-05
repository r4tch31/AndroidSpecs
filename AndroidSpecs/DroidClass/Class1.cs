using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroidClass
{
    public class GetInfo
    {
        GraphicsDeviceManager graphics;

        public GetInfo(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
        }

        public string Info()
        {
            return graphics.GraphicsProfile.ToString();
        }
    }
}
