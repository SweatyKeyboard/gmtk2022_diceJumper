using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private DiceD6[] _possibleDices;
    [SerializeField] private int[] _weights;
    [SerializeField] private AudioClip _destroySound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            int rand = Random.Range(0, _weights.Sum() + 1);
            int index = -1;

            for (int c = 0, s = 0; c < _weights.Length; c++)
            {
                if (rand < s)
                {
                    index = c - 1;
                    break;
                }

                s += _weights[c];
            }
            if (index == -1)
                index = _weights.Length - 1;


            Instantiate(
                _possibleDices[index],
                transform.position,
                Quaternion.identity);

            AudioPlayer.PlaySound(_destroySound);

            Destroy(gameObject);
        }
    }
}
