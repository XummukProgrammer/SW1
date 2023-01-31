using System.Collections.Generic;

public class ResourcesManager
{
    private List<Resource> _resources = new List<Resource>();

    public Resource AddResource(MiniGame miniGame, string source, string name, int startValue, int minValue, int maxValue, ResourceChangePolicy changePolicy)
    {
        var resource = new Resource();
        resource.Init(miniGame, source, name, startValue, minValue, maxValue, changePolicy);
        _resources.Add(resource);
        return resource;
    }

    public void RemoveResource(Resource resource)
    {
        resource.Deinit();
        _resources.Remove(resource);
    }

    public Resource GetResourceByName(string source, string name)
    {
        foreach (var resource in _resources)
        {
            if (resource.Source == source && resource.Name == name)
            {
                return resource;
            }
        }

        return null;
    }

    public void Clear()
    {
        foreach (var resource in _resources)
        {
            resource.Deinit();
        }

        _resources.Clear();
    }

    public void Update()
    {
        foreach (var resource in _resources)
        {
            resource.Update();
        }
    }

    public void Deinit()
    {
        Clear();
    }
}
