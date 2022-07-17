using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform _begin;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _checkpoint;
    [SerializeField] private Transform[] _boxes;
    [SerializeField] private float _boxChance;
    [SerializeField] private int _difficulty;

    public Transform Begin => _begin;
    public Transform End => _end;
    public Transform Checkpoint => _checkpoint;
    public Transform[] Boxes => _boxes;
    public float Chance => _boxChance;
    public int Difficulty => _difficulty;
}
