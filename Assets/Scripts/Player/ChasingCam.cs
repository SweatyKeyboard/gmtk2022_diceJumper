using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ChasingCam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private int _speed;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _minX;
    private float _minY = -4;

    private Camera _camera;

    private Vector3 _tempVector;
    private float _reachedX;

    public float MinY 
    {
        get => _minY;
        set => _minY = value;
    }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if (_target.position.x > _reachedX)
            _reachedX = _target.position.x;

        _tempVector.x = Mathf.Max(_target.position.x, _minX, _reachedX);
        _tempVector.y = Mathf.Max(_target.position.y, _minY);

        _tempVector.x += _offsetX;
        _tempVector.y += _offsetY;
        _tempVector.z = -10f;
        transform.position = Vector3.Lerp(transform.position, _tempVector, _speed * Time.deltaTime);
    }

    public void ResetMinXTo(float x)
    {
        _reachedX = x;
    }

    public void FieldOfViewUp()
    {
        _camera.orthographicSize += 0.5f;
    }
}
