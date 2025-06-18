using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Interface
{
    public interface ISensorBroken
    {
        bool IsBroken { get; set; }
        void Activate();
        void ResetActivation();
    }
}
