using UnityEngine;

public class LocatorBehaviour : MonoBehaviour
{
    [SerializeField] private string _name;

    private EntryPoint _entryPoint;
    private Locator _locator;

    private void OnEnable()
    {
        var launcher = FindObjectOfType<Launcher>();
        if (launcher != null)
        {
            _entryPoint = launcher.EntryPoint;
            AddLocator();
        }
        else
        {
            Debug.Log("[SW] No found Launcher!");
        }
    }

    private void OnDisable()
    {
        if (_entryPoint != null)
        {
            RemoveLocator();
        }
    }

    private void AddLocator()
    {
        _locator = new Locator();
        _locator.Init(_name, this);
        _entryPoint.LocatorManager.AddLocator(_locator);
    }

    private void RemoveLocator()
    {
        _entryPoint.LocatorManager.RemoveLocator(_locator);
    }
}
