using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] private Checkpoint _checkpointPrefab;
    [SerializeField] private ChasingCam _camera;
    private Checkpoint _lastCheckpoint;
    private Checkpoint _nextCheckpoint;
    private Vector2 _respawnPosition;
    

    public Vector2 RespawnPosition => _respawnPosition;

    private void Awake()
    {
        _respawnPosition = transform.position;
    }
    public void New(Vector2 position)
    {
        Checkpoint checkpoint = Instantiate(_checkpointPrefab, position, Quaternion.identity, transform);
        _nextCheckpoint = checkpoint;
        _nextCheckpoint.OnReached += CheckpointReached;
    }

    private void CheckpointReached()
    {
        _lastCheckpoint = _nextCheckpoint;
        _respawnPosition = _lastCheckpoint.transform.position;
        _camera.MinY = _respawnPosition.y - 10;
        _nextCheckpoint.OnReached -= CheckpointReached;
    }
}
