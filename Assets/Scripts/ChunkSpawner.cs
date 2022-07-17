using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(CheckpointController))]
public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private Chunk _startChunk;
    [SerializeField] private Chunk _finalChunk;
    [SerializeField] private Box _boxPrefab;

    private CheckpointController _checkpointController;
    private List<Chunk> _spawnedChunks = new List<Chunk>();
    private int _chunkCounter = 0;
    private bool _isReadyToFinal = false;
    private bool _isSpawningStopped = false;

    public bool IsReadyToFinal
    {
        get => _isReadyToFinal;
        set => _isReadyToFinal = value;
    }

    private void Awake()
    {
        _spawnedChunks.Add(_startChunk);
        _checkpointController = GetComponent<CheckpointController>();
        _isReadyToFinal = AreAllGoldenDIceCollected();
    }

    private bool AreAllGoldenDIceCollected()
    {
        int sum = 0;
        for (int i = 1; i <= 6; i++)
        {
            sum += PlayerPrefs.GetInt("gold" + i);
        }
        return sum == 6;
    }

    private void Update()
    {
        if (!_isSpawningStopped &&
            _player.position.x > _spawnedChunks[_spawnedChunks.Count - 1].End.position.x - 20f
            )
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        _chunkCounter++;
        if (!IsReadyToFinal)
        {
            var allowedChunks = _chunks.Where(x => x.Difficulty <= _chunkCounter).ToArray();
            Chunk newChunk = Instantiate(allowedChunks[Random.Range(0, allowedChunks.Length)]);
            newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            _spawnedChunks.Add(newChunk);

            if ((_chunkCounter) % 3 == 0)
            {
                _checkpointController.New(_spawnedChunks[_spawnedChunks.Count - 1].Checkpoint.position);
            }

            for (int i = 0; i < newChunk.Boxes.Length; i++)
            {
                if (Random.Range(1, 100) >= newChunk.Chance)
                {
                    Instantiate(_boxPrefab, newChunk.Boxes[i].position, Quaternion.identity);
                }
            }

            if (_spawnedChunks.Count > 5)
            {
                Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);
            }
        }
        else
        {
            Chunk newChunk = Instantiate(_finalChunk);
            newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            _spawnedChunks.Add(newChunk);
            _isSpawningStopped = true;
        }
    }
}
