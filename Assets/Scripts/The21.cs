using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class The21 : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Image overlay = GameObject.FindGameObjectWithTag("Overlay").GetComponent<Image>();
            AudioPlayer.PlaySound(_sound);
            StartCoroutine(ColorChanger
                (
                overlay,
                new Color(1,1,1,0),
                new Color(1,1,1,1),
                3,
                () => { EndGame(); }
                ));
        }
    }

    private void EndGame()
    {
        FindObjectOfType<SceneChanger>().GoToScene("FinishScreen");
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
}
