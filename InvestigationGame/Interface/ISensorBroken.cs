using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Interface
{
    /// <summary>
    /// A sensor interface for sensors for sensors that can be broken.
    /// </summary>
    public interface ISensorBroken
    {
        bool IsBroken { get; set; }
        void Activate();
        void ResetActivation();
    }
}
