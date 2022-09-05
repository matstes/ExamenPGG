using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appscale
{
    public class ScaleApp
    {
        private double scale = 1.0;
        public double Scale 
            { 
            get { return scale; } 
            set { scale = value;} 
            }

        private double heightScale = 768.0;
        public double HeightScale
        {
            get { return scale* heightScale; }
        }
        private double widthScale = 464.0;
        public double WidthScale
        {
            get { return scale * widthScale; }
        }
    }
}
