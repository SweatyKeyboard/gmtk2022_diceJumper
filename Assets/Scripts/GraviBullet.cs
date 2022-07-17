using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviBullet : MonoBehaviour
{
    private void Awake()
    {
    }
    private void OnDestroy()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, 2.5f);
        foreach (Collider2D obj in objects)
        {
            if (obj.attachedRigidbody != null)
            {
                Vector3 direction = obj.transform.position - transform.position;
                direction.z = 0;
                obj.attachedRigidbody.AddForce(
                    direction * 5,
                    ForceMode2D.Impulse
                    );
            }
        }
    }
}
