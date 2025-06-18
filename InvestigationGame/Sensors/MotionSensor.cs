using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    public class MotionSensor : ISensor, ISensorBroken
    {
        public string Name { get; } = "motion";
        private static int _activations = 0;
        private const int MaxActivations = 3;
        public bool IsBroken { get; set; } = false; 

        public bool Matches(Enums.SensorType weakness)
        {
            if (IsBroken) return false;
            //_activations++;
            return weakness == Enums.SensorType.Motion;
        }

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

        public void ResetActivation()
        {
            _activations = 0;
        }
    }
}