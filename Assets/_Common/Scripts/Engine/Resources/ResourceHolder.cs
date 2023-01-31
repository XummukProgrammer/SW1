public class ResourceHolder
{
    private MiniGame _miniGame;
    private Resource _resource;

    public Resource Resource => _resource;

    public void Create(MiniGame miniGame, string source, string name, int startValue, int minValue, int maxValue, ResourceChangePolicy changePolicy)
    {
        _miniGame = miniGame;

        _resource = _miniGame.EntryPoint.ResourcesManager.AddResource(miniGame, source, name, startValue, minValue, maxValue, changePolicy);
    }

    public void Remove()
    {
        if (_resource != null)
        {
            _miniGame.EntryPoint.ResourcesManager.RemoveResource(_resource);

            _resource = null;
        }
    }
}
