using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    /// <summary>
    /// A class representing a motion sensor in the Investigation Game.
    /// </summary>
    public class AudioSensor : ISensor
    {
        public string Name { get; } = "audio";

        /// <summary>
        /// A method to check if the sensor matches a specific weakness type.
        /// </summary>
        /// <param name="weakness"></param>
        /// <returns></returns>
        public bool Matches(Enums.SensorType weakness)
        {
            return weakness == Enums.SensorType.Audio;
        }
    }
}