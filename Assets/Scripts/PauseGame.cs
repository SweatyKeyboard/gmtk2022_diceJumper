using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Image _back;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;

    private static bool _isPaused = false;

    private void Awake()
    {
        Unpause();
    }

    public void GamePause()
    {
        if (_isPaused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }
    private void Pause()
    {
        _back.color = new Color(0, 0, 0, 0.4f);
        _icon.color = new Color(0.9f, 0.9f, 0.9f, 1f);
        _button.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        _button.interactable = true;
        _button.GetComponentInChildren<Text>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
        FindObjectOfType<PlayerMovement>().IsImmovable = true;
        FindObjectOfType<GunRotation>().IsImmovable = true;
        FindObjectOfType<GunShooting>().IsImmovable = true;
        Time.timeScale = 0;
        _isPaused = true;
    }

    private void Unpause()
    {
        _back.color = new Color(0, 0, 0, 0f);
        _icon.color = new Color(0.8f, 0.8f, 0.8f, 0f);
        _button.GetComponent<Image>().color = new Color(1, 1, 1, 0f);
        _button.interactable = false;
        _button.GetComponentInChildren<Text>().color = new Color(0.7f, 0.7f, 0.7f, 0f);
        FindObjectOfType<PlayerMovement>().IsImmovable = false;
        FindObjectOfType<GunRotation>().IsImmovable = false;
        FindObjectOfType<GunShooting>().IsImmovable = false;
        Time.timeScale = 1;
        _isPaused = false;
    }
}
