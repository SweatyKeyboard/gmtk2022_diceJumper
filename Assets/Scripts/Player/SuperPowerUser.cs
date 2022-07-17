using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class SuperPowerUser : MonoBehaviour
{
    [SerializeField] private Text _valueViewer;
    [SerializeField] private Text _nameViewer;
    [SerializeField] private GameObject _jetpackParicles;
    [SerializeField] private Bullet _teleportBulletPrefab;
    [SerializeField] private Bullet _graviBulletPrefab;
    [SerializeField] private Image[] _panels;

    [SerializeField] private AudioClip _jetpackSound;
    
    private AbstractSuperPower _superPower;
    private Rigidbody2D _rigidbody;
    private bool _isMoonGravity = false;
    private bool _isSlowed = false;

    private float _lastJetPackSound;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void NewSuperPower(AbstractSuperPower superPower)
    {
        _superPower = superPower;
        _superPower.ResetValue();
        _valueViewer.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        _valueViewer.text = _superPower.Value.ToString();
        _nameViewer.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        _nameViewer.text = _superPower.Name;
        foreach (Image image in _panels)
            image.color = new Color(0.16f, 0.16f, 0.16f, 1f);
    }

    private void Update()
    {
        if (_superPower != null)
        {
            if (_superPower.Name == "Jetpack" &&
                Input.GetMouseButton(1))
            {

                _rigidbody.AddForce(Vector2.up * 25f);
                _superPower.Value -= 0.25f;
                _valueViewer.text = System.Math.Round(_superPower.Value, 2).ToString();
                Instantiate(_jetpackParicles, transform.position - new Vector3(0, 0.3f, 0), Quaternion.identity);

                if (Time.time > _lastJetPackSound + 0.06f)
                {
                    AudioPlayer.PlaySound(_jetpackSound);
                    _lastJetPackSound = Time.time;
                }
            }
            else if (_superPower.Name == "Teleporter" &&
                Input.GetMouseButtonDown(1))
            {
                FindObjectOfType<GunShooting>().Shot(_teleportBulletPrefab);
                _superPower.Value -= 1f;
                _valueViewer.text = System.Math.Round(_superPower.Value).ToString();
            }
            else if (_superPower.Name == "Gravigun" &&
                Input.GetMouseButtonDown(1))
            {
                FindObjectOfType<GunShooting>().Shot(_graviBulletPrefab);
                _superPower.Value -= 1f;
                _valueViewer.text = System.Math.Round(_superPower.Value).ToString();
            }
            else if (_superPower.Name == "Moon Gravity" &&
                Input.GetMouseButtonDown(1))
            {
                Physics2D.gravity = new Vector2(0, -1.625f);
                _isMoonGravity = true;
            }
            else if (_superPower.Name == "Timeslower" &&
               Input.GetMouseButtonDown(1))
            {
                Time.timeScale = 0.33f;
                Time.fixedDeltaTime = 0.33f * 0.02f;
                _isSlowed = true;
            }
            else if (_superPower.Name == "Air Jump" &&
              Input.GetMouseButtonDown(1))
            {
                PlayerMovement movement = GetComponent<PlayerMovement>();
               if (!movement.IsGrounded)
                {
                    movement.Jump();
                    _superPower.Value -= 1f;
                    _valueViewer.text = System.Math.Round(_superPower.Value).ToString();
                }
            }


            if (_isMoonGravity)
            {
                _superPower.Value -= Time.deltaTime;
                _valueViewer.text = System.Math.Round(_superPower.Value, 2).ToString();
            }

            if (_isSlowed)
            {
                _superPower.Value -= Time.deltaTime;
                _valueViewer.text = System.Math.Round(_superPower.Value, 2).ToString();
            }

            if (_superPower.Value <= 0)
            {
                _valueViewer.color = new Color(0f, 0f, 0f, 0f);
                _nameViewer.color = new Color(0f, 0f, 0f, 0f);
                _superPower = null;

                Physics2D.gravity = new Vector2(0, -9.81f);
                _isMoonGravity = false;
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
                _isSlowed = false;

                foreach (Image image in _panels)
                    image.color = new Color(0.16f, 0.16f, 0.16f, 0f);
            }
        }
    }
}
