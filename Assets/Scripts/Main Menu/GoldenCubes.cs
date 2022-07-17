using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenCubes : MonoBehaviour
{
    [SerializeField] private Image[] _cubes = new Image[6];
    [SerializeField] private Color _highlightColor;
    [SerializeField] private Color _defaultColor;
    private void Awake()
    {
        CheckHighlight();
    }

    public void CheckHighlight()
    {
        for (int i = 1; i <= 6; i++)
        {
            if (PlayerPrefs.GetInt("gold" + i) == 1)
            {
                _cubes[i - 1].color = _highlightColor;
            }
            else
            {
                _cubes[i - 1].color = _defaultColor;
            }
        }
    }
}
