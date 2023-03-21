using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class AudioPlayer : MonoBehaviour
{
    private AudioListener _audioListener;
    private static Vector2 _position;

    private void Awake()
    {
        _audioListener = GetComponent<AudioListener>();
        _position = transform.position;
    }
    public static void PlaySound(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, _position);
    }
}
