using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RedDiceCounter : MonoBehaviour
{
    private Image _image;
    [SerializeField] private SpriteList _sprites;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    public void UpdateDice(int value)
    {
        _image.sprite = _sprites[value-1];
    }
}
