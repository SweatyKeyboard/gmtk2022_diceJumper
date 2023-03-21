using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VisualDiceRolling : MonoBehaviour
{
    [SerializeField] private Image _back;
    [SerializeField] private Image _dice;
    [SerializeField] private Text _text;
    [SerializeField] private SpriteList _sprites;
    [SerializeField] private AudioClip[] _rollSounds;
    [SerializeField] private AudioClip _endSound;

    private int _value;
    private DiceD6 _mainDice;

    public Color DiceColor { get; set; }
    public void Roll(DiceD6 dice)
    {
        _mainDice = dice;
        DiceColor = dice.Color;
        ShowWindow();
    }

    private void ShowWindow()
    {
        StartCoroutine(ColorChanger(
            _back,
            _back.color,
            new Color(0,0,0,0.5f),
            0.5f));
        StartCoroutine(ColorChanger(
           _dice,
           _dice.color,
           DiceColor,
           0.5f,
           () => { RollTheDice(); }));
    }

    private void RollTheDice()
    {
        AudioPlayer.PlaySound(_rollSounds[UnityEngine.Random.Range(0, _rollSounds.Length)]);
        StartCoroutine(SpriteChanger(
            _dice,
            _sprites,
            1.5f,
            () => ShowResult()));
    }

    private void ShowResult()
    {
        if (_mainDice.IsInstantRolled)
        {
            _mainDice.Actions[_value]?.Invoke(0);
            _text.text = _mainDice.Description;
        }
        else
        {
            int redDices = FindObjectOfType<PlayerLife>().RedDices;
            _mainDice.Actions[1]?.Invoke(_value);
            _text.text = _mainDice.Description;
        }
        StartCoroutine(ColorChanger(
            _text,
            _text.color,
            new Color(0.88f, 0.88f, 0.88f, 1f),
            0.25f,
            () => { Invoke("HideWindow", 0.8f); }));
    }

    private void HideWindow()
    {
        StartCoroutine(ColorChanger(
            _back,
            _back.color,
            new Color(0, 0, 0, 0f),
            0.5f));

        StartCoroutine(ColorChanger(
           _text,
           _text.color,
           new Color(0, 0, 0, 0f),
           0.5f));

        StartCoroutine(ColorChanger(
           _dice,
           _dice.color,
           new Color(0, 0, 0, 0f),
           0.5f));
    }

    private IEnumerator ColorChanger(Image image, Color from, Color to, float time, Action action = null)
    {
        float currentTime = 0f;
        image.color = from;
        do
        {
            image.color = Color.Lerp(from, to, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;

        } while (currentTime < time);
        action?.Invoke();
    }

    private IEnumerator ColorChanger(Text text, Color from, Color to, float time, Action action = null)
    {
        float currentTime = 0f;
        text.color = from;
        do
        {
            text.color = Color.Lerp(from, to, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;

        } while (currentTime < time);
        action?.Invoke();
    }

    private IEnumerator SpriteChanger(Image image, SpriteList sprites, float time, Action action = null)
    {
        float currentTime = 0f;
        float delay = 0.05f;
        do
        {
            _value = UnityEngine.Random.Range(0, sprites.Length);
            image.sprite = sprites[_value];
            delay *= 1.15f;
            currentTime += delay;
            yield return new WaitForSeconds(delay);
        } while (currentTime < time);
        action?.Invoke();
    }
}
