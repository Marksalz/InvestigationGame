namespace InvestigationGame.Interface
{
    public interface ISensor
    {
        string Name { get; }
        bool Matches(string weakness);
    }
}