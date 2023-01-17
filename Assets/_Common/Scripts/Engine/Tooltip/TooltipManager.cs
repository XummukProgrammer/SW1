using System.Collections.Generic;
using UnityEngine;

public class TooltipManager
{
    private EntryPoint _entryPoint;
    private Transform _container;
    private List<Tooltip> _tooltips = new List<Tooltip>();

    public void Init(EntryPoint entryPoint, Transform container)
    {
        _entryPoint = entryPoint;
        _container = container;
    }

    public void Deinit()
    {
        foreach (var tooltip in _tooltips)
        {
            tooltip.Remove();
        }

        _tooltips.Clear();
    }

    public Tooltip CreateTooltip(TooltipBehaviour prefab, Transform target, bool isAutoShow)
    {
        var tooltip = new Tooltip();
        tooltip.Create(_entryPoint, prefab, _container, target, isAutoShow);
        return tooltip;
    }

    public void RemoveTooltip(Tooltip tooltip)
    {
        _tooltips.Remove(tooltip);
        tooltip.Remove();
    }
}
