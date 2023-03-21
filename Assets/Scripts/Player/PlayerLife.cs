using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private CheckpointController _checkpoints;
    [SerializeField] private ChasingCam _camera;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private RedDiceCounter _redDiceView;
    [SerializeField] private int _lifes;
    [SerializeField] private GameObject _dieParticles;
    [SerializeField] private AudioClip _respawnSound;

    [SerializeField] private DiceD6 _redDiceSample;

    [SerializeField] private VisualDiceRolling _diceRoller;

    private SpriteRenderer _renderer;

    private int _redDices = 1;

    public int RedDices
    {
        get => _redDices;
        set
        {
            _redDices = value;
            _redDiceView.UpdateDice(_redDices);
        }
    }

    public int Lifes => _lifes;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    public void Respawn()
    {
        Color color = _renderer.color;
        _renderer.color = new Color(color.r, color.g, color.b, 1f);
        FindObjectOfType<GunShooting>().GetComponent<SpriteRenderer>().color =
    new Color(color.r, color.g, color.b, 1f);

        Vector2 respawnPos = _checkpoints.RespawnPosition;
        _camera.ResetMinXTo(respawnPos.x);
        transform.position = respawnPos;
    }

    public void AddHP()
    {
        _healthView.UpdateHP(++_lifes);
    }

    public void ResetRedDices()
    {
        RedDices = 1;
    }

    public void FinallyDie()
    {
        Invoke("GoToMainMenu", 1.5f);
    }

    private void GoToMainMenu()
    {
        FindObjectOfType<SceneChanger>().GoToScene("MainMenu");
    }

    private void Update()
    {
        if (transform.position.y < _camera.MinY - 5)
            Die();
    }

    private void Die(string cause = "fall")
    {
        _healthView.UpdateHP(--_lifes);

        if (cause == "fall")
        {
            Respawn();
        }
        else
        {
            Instantiate(_dieParticles, transform);
            Color color = _renderer.color;
            _renderer.color = new Color(color.r, color.g, color.b, 0);
            FindObjectOfType<GunShooting>().GetComponent<SpriteRenderer>().color =
                new Color(color.r, color.g, color.b, 0);
            Invoke("Respawn", 0.5f);
        }

        if (_lifes == 0)
        {
            TryToFinallyDie();
            GetComponent<PlayerMovement>().IsImmovable = true;
            FindObjectOfType<GunRotation>().IsImmovable = true;
            FindObjectOfType<GunShooting>().IsImmovable = true;
        }

        foreach (TeleportBullet bullet in FindObjectsOfType<TeleportBullet>())
        {
            bullet.SafeDestroy();
        }

        AudioPlayer.PlaySound(_respawnSound);
    }

    private void TryToFinallyDie()
    {
        DiceD6 dice = Instantiate(_redDiceSample, new Vector2(-100, -100), Quaternion.identity);
        _diceRoller.Roll(dice);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Die("Bullet");
        }
    }
}
