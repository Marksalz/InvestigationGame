using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    public interface ICounterAttackAgent
    {
        void CounterAttack(List<ISensor> attachedSensors);
    }
}