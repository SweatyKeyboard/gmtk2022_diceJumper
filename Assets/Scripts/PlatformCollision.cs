using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundChecker"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().IsGrounded = true;
        }
    }
}
