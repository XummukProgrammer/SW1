using UnityEngine;

public class SW_MiniGame : MiniGame
{
    protected override void OnInit() 
    { 
        base.OnInit();

        Debug.Log("[SW] MiniGame started!");
    }

    protected override void OnPostInit() 
    { 
        base.OnPostInit();
    }

    protected override void OnDeinit() 
    { 
        base.OnDeinit();
    }

    protected override void OnUpdate() 
    { 
        base.OnUpdate();
    }

    protected override void OnLoadResources() 
    {
        base.OnLoadResources();
    }

    protected override void OnUnloadResources() 
    { 
        base.OnUnloadResources();
    }

    protected override void OnInProgress() 
    { 
        base.OnInProgress();
    }

    protected override void OnWin() 
    { 
        base.OnWin();
    }

    protected override void OnShowWinWindow() 
    { 
        base.OnShowWinWindow();
    }

    protected override void OnLose() 
    { 
        base.OnLose();
    }

    protected override void OnShowLoseWindow() 
    { 
        base.OnShowLoseWindow();
    }

    protected override void OnShowRewardWindow() 
    {
        base.OnShowRewardWindow();
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
    }

    protected override bool IsResourcesLoaded() 
    { 
        return true; 
    }

    protected override bool IsResourcesUnloaded() 
    { 
        return true; 
    }

    protected override bool IsWin() 
    { 
        return false; 
    }

    protected override bool IsLose() 
    { 
        return false; 
    }

    protected override bool IsWinWindowShowed() 
    { 
        return false; 
    }

    protected override bool IsLoseWindowShowed() 
    { 
        return false; 
    }

    protected override bool IsRewardWindowShowed() 
    { 
        return false; 
    }
}
