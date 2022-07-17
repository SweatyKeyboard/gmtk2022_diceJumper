using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBullet : MonoBehaviour
{
    private bool _isSafeDestory = false;
    private void OnDestroy()
    {
        if (!_isSafeDestory)
            FindObjectOfType<PlayerMovement>().transform.position = transform.position;
    }

    public void SafeDestroy()
    {
        _isSafeDestory=true;
        Destroy(gameObject);
    }
}
