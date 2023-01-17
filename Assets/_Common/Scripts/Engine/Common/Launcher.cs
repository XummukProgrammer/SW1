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

    private EntryPoint _entryPoint = new EntryPoint();

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
}
