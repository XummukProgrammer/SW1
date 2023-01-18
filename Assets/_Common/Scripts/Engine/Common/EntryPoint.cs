using UnityEngine;

public class EntryPoint
{
    private Camera _camera;

    private HUDManager _hudManager = new HUDManager();
    private WindowManager _windowManager = new WindowManager();
    private ActionsQueue _actionsQueue = new ActionsQueue();
    private MiniGamesManager _miniGamesManager = new MiniGamesManager();
    private SoundsManager _soundsManager = new SoundsManager();
    private EffectsManager _effectsManager = new EffectsManager();
    private TooltipManager _tooltipManager = new TooltipManager();
    private LocatorManager _locatorManager = new LocatorManager();

    private BaseMiniGameEntryBehaviour[] _miniGameEntryBehaviours;
    private string _startMiniGameId;
    private MiniGame _currentMiniGame;

    private bool _isDisabled = false;

    public HUDManager HUDManager => _hudManager;
    public WindowManager WindowManager => _windowManager;
    public ActionsQueue ActonsQueue => _actionsQueue;
    public MiniGamesManager MiniGamesManager => _miniGamesManager;
    public MiniGame CurrentMiniGame => _currentMiniGame;
    public SoundsManager SoundsManager => _soundsManager;
    public EffectsManager EffectsManager => _effectsManager;
    public TooltipManager TooltipManager => _tooltipManager;
    public LocatorManager LocatorManager => _locatorManager;
    public bool IsDisabled => _isDisabled;

    public void Init(Camera camera,
        HUDContainerBehaviour hudContainerBehaviour, Transform windowContainer,
        BaseMiniGameEntryBehaviour[] miniGameEntryBehaviours, string startMiniGameId,
        Transform soundsContainer, AudioSource baseAudioSource,
        Transform worldEffectsContainer, Transform canvasEffectsContainer,
        Transform tooltipContainer)
    {
        _camera = camera;
        _miniGameEntryBehaviours = miniGameEntryBehaviours;
        _startMiniGameId = startMiniGameId;

        _hudManager.Init(this, hudContainerBehaviour);
        _windowManager.Init(this, windowContainer);
        _miniGamesManager.Init(this);
        _actionsQueue.Init(this);
        _soundsManager.Init(soundsContainer, baseAudioSource);
        _effectsManager.Init(this, worldEffectsContainer, canvasEffectsContainer);
        _tooltipManager.Init(this, tooltipContainer);

        // TODO: Разделить игровую логику на Core и Meta!
        StartMiniGame(_startMiniGameId);
    }

    public void Deinit()
    {
        _hudManager.Deinit();
        _windowManager.Deinit();
        _actionsQueue.Deinit();
        _miniGamesManager.Deinit();
        _soundsManager.Deinit();
        _effectsManager.Deinit();
    }

    public void Update()
    {
        _hudManager.Update();
        _windowManager.Update();
        _actionsQueue.Update();
        _miniGamesManager.Update();
        _soundsManager.Update();
        _effectsManager.Update();
    }

    public Vector3 GetMousePosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void StartMiniGame(string miniGameId)
    {
        foreach (var miniGameEntryBehaviour in _miniGameEntryBehaviours)
        {
            if (miniGameEntryBehaviour.name == miniGameId)
            {
                var entry = GameObject.Instantiate(miniGameEntryBehaviour);
                _currentMiniGame = entry.CreateMiniGame(_miniGamesManager);
                _currentMiniGame.Start();
            }
        }
    }

    public void OnDisabled()
    {
        _isDisabled = true;
    }
}
