using System.Collections.Generic;

public class LocatorManager
{
    private List<Locator> _locators = new List<Locator>();

    public void AddLocator(Locator locator)
    {
        _locators.Add(locator);
    }

    public Locator GetLocatorByName(string name)
    {
        foreach (var locator in _locators)
        {
            if (locator.Name == name)
            {
                return locator;
            }
        }

        return null;
    }

    public void RemoveLocator(Locator locator)
    {
        _locators.Remove(locator);
    }
}
