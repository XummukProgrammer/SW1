public class Locator
{
    private string _name;
    private LocatorBehaviour _behaviour;

    public string Name => _name;
    public LocatorBehaviour Behaviour => _behaviour;

    public void Init(string name, LocatorBehaviour behaviour)
    {
        _name = name;
        _behaviour = behaviour;
    }
}
