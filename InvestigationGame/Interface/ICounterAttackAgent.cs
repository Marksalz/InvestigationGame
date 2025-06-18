using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    /// <summary>
    /// An interface for agents that can counterattack weaknesses detected by sensors.
    /// </summary>
    public interface ICounterAttackAgent
    {
        List<ISensor> CounterAttack(List<ISensor> attachedSensors);
    }
}