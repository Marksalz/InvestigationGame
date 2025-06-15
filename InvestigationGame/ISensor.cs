namespace InvestigationGame
{
    public interface ISensor
    {
        string Name { get; }
        bool Matches(string weakness);
    }
}