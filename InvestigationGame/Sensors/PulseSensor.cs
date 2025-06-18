using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    /// <summary>
    /// A sensor that detects pulse signals.
    /// </summary>
    public class PulseSensor : ISensor, ISensorBroken
    {
        public string Name { get; } = "pulse";
        private static int _activations = 0;
        private const int MaxActivations = 3;
        public bool IsBroken { get; set; } = false;

        /// <summary>
        /// A method to check if the sensor matches a given weakness.
        /// </summary>
        /// <param name="weakness"></param>
        /// <returns></returns>
        public bool Matches(Enums.SensorType weakness)
        {
            if (IsBroken) return false;
            //_activations++;
            return weakness == Enums.SensorType.Pulse;
        }

        /// <summary>
        /// A method thst actiavates the sensor and increments the activation count.
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