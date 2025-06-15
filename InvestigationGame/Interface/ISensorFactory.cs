using InvestigationGame.Sensors;

namespace InvestigationGame.Interface
{
    public interface ISensorFactory
    {
        ISensor CreateSensor(string type);
    }
}