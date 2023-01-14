using System.Collections;
using UnityEngine;

public class SW_GameCycleComponent : GameComponent<SW_MiniGame>
{
    [SerializeField] private float _hourSeconds = 1;

    protected override void OnInit()
    {
        base.OnInit();

        StartCoroutine(HourProcess());
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (!MiniGame.EntryPoint.IsDisabled)
        {
            StopCoroutine(HourProcess());
        }
    }

    private IEnumerator HourProcess()
    {
        while (true)
        {
            yield return new WaitForSeconds(_hourSeconds);
            MiniGame.OnHourChanged();
        }
    }
}
