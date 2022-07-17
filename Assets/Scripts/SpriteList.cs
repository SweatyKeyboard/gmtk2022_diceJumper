using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpriteList")]
public class SpriteList : ScriptableObject
{
    [SerializeField] private Sprite[] _sprites;

    public Sprite this[int i] => _sprites[i];
    public int Length => _sprites.Length;
}
