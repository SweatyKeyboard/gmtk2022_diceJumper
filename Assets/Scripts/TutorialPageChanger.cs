using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPageChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] _pages;
    [SerializeField] private Image _image;
    [SerializeField] private Button _prevButton;
    [SerializeField] private Button _nextButton;
    private int _currentPage = 0;

    private void Awake()
    {
        _prevButton.interactable = false;
        UpdatePage();
    }

    private void UpdatePage()
    {
        if (_currentPage == 0)
        {
            _prevButton.interactable = false;
        }
        else
        {
            _prevButton.interactable = true;
        }

        if (_currentPage == _pages.Length - 1)
        {
            _nextButton.interactable = false;
        }
        else
        {
            _nextButton.interactable = true;
        }
        _image.sprite = _pages[_currentPage];
    }

    public void NextPage()
    {
        _currentPage++;
        UpdatePage();
    }

    public void PreviousPage()
    {
        _currentPage--;
        UpdatePage();
    }
}
