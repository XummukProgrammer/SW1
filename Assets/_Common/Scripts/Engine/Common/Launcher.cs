using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private BaseMiniGameEntryBehaviour[] _miniGameEntryBehaviours;
    [SerializeField] private string _startMiniGameId;

    [SerializeField] private HUDContainerBehaviour _hudContainerBehaviour;
    [SerializeField] private Transform _windowContainer;

    [SerializeField] private Transform _soundsContainer;
    [SerializeField] private AudioSource _baseAudioSource;

    [SerializeField] private Transform _worldEffectsContainer;
    [SerializeField] private Transform _canvasEffectsContainer;

    [SerializeField] private Transform _tooltipContainer;

    [SerializeField] private Transform _startMiniGameMenu;

    private EntryPoint _entryPoint = new EntryPoint();

    public EntryPoint EntryPoint => _entryPoint;

    private void OnEnable()
    {
        _entryPoint.Init(_camera,
            _hudContainerBehaviour, _windowContainer, 
            _miniGameEntryBehaviours, _startMiniGameId,
            _soundsContainer, _baseAudioSource,
            _worldEffectsContainer, _canvasEffectsContainer,
            _tooltipContainer);
    }

    private void OnDisable()
    {
        _entryPoint.OnDisabled();
        _entryPoint.Deinit();
    }

    private void Update()
    {
        _entryPoint.Update();
    }

    public void OnStartMiniGame()
    {
        _startMiniGameMenu.gameObject.SetActive(false);
        _entryPoint.StartMiniGame();
    }
}
