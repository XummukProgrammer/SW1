using System.Collections.Generic;

public class SequenceAction : Action
{
    private List<Action> _actions = new List<Action>();

    public void AddAction(Action action)
    {
        action.Init(EntryPoint);
        _actions.Add(action);
    }

    protected override void OnInit()
    {
        base.OnInit();

        ExecuteDelegate = OnExecute;
        IsFinishDelegate = OnIsFinish;
        FinishDelegate = OnFinish;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        // TODO: duplicate (ActionsQueue)
        if (_actions.Count == 0)
        {
            return;
        }

        var action = _actions[0];

        action.Update();

        if (action.State == ActionState.Destroy)
        {
            action.Deinit();
            _actions.Remove(action);
        }
    }

    private void OnExecute()
    {
    }

    private bool OnIsFinish()
    {
        return _actions.Count == 0;
    }

    private void OnFinish()
    {
    }
}
