using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    /// <summary>
    /// A class representing a motion sensor in the Investigation Game.
    /// </summary>
    public class MotionSensor : ISensor, ISensorBroken
    {
        public string Name { get; } = "motion";
        private static int _activations = 0;
        private const int MaxActivations = 3;
        public bool IsBroken { get; set; } = false;

        /// <summary>
        /// A method to check if the sensor matches a weakness type.
        /// </summary>
        /// <param name="weakness"></param>
        /// <returns></returns>
        public bool Matches(Enums.SensorType weakness)
        {
            if (IsBroken) return false;
            //_activations++;
            return weakness == Enums.SensorType.Motion;
        }

        /// <summary>
        /// A method to activate the sensor and track its activations.
        /// </summary>
        public void Activate()
        {
            if (IsBroken)
            {
                Console.WriteLine($"Activated: {_activations} times.");
                return;
            }
            _activations++;
            if (_activations >= MaxActivations)
            {
                IsBroken = true;
                Console.WriteLine($"Activated: {_activations} times.");
            }
            else
            {
                Console.WriteLine($"Activated: {_activations} times.");
            }
        }

        /// <summary>
        /// A method to reset the activation count of the sensor.
        /// </summary>
        public void ResetActivation()
        {
            _activations = 0;
        }
    }
}