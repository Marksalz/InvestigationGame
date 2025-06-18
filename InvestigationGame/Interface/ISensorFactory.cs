

namespace InvestigationGame.Interface
{
    /// <summary>
    /// A factory interface for creating sensors.
    /// </summary>
    public interface ISensorFactory
    {
        ISensor CreateSensor(Enums.SensorType type);
    }
}