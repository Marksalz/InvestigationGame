using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Sensors
{
    /// <summary>
    /// A class representing a motion sensor in the Investigation Game.
    /// </summary>
    public class MagneticSensor : ISensor
    {
        public string Name { get; } = "magnetic";
        private int _counterCancelUses = 0;
        private const int MaxCancels = 2;

        public bool Matches(Enums.SensorType weakness)
        {
            return weakness == Enums.SensorType.Magnetic;
        }

        /// <summary>
        /// A method to attempt to cancel a counter-attack using the magnetic sensor.
        /// </summary>
        /// <param name="weakness"></param>
        /// <returns></returns>
        public bool TryCancelCounterAttack(Enums.SensorType weakness)
        {
            if (_counterCancelUses < MaxCancels && Matches(weakness))
            {
                _counterCancelUses++;
                return true;
            }
            return false;
        }
    }
}