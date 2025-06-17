using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    public interface ICounterAttackAgent
    {
        List<ISensor> CounterAttack(List<ISensor> attachedSensors);
    }
}