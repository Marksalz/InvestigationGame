namespace InvestigationGame.Interface
{
    /// <summary>
    /// A interface for sensors that can detect weaknesses in agents.
    /// </summary>
    public interface ISensor
    {
        string Name { get; }
        bool Matches(Enums.SensorType weakness);
    }
}