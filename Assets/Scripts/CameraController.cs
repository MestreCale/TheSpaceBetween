using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform targetToFollow;

    private Camera _camera;
    public Color hellColor;
    public Color limboColor;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        PlayerStatus.OnPlayerChangeLocation += OnLocationChange;
    }

    private void OnDestroy()
    {
        PlayerStatus.OnPlayerChangeLocation -= OnLocationChange;

    }

    private void OnLocationChange(Location loc)
    {
        switch (loc)
        {
            case Location.Hell:
                _camera.backgroundColor = hellColor;
                break;
            case Location.Limbo:
                _camera.backgroundColor = limboColor;
                break;
            
        }
    }

    private void Update()
    {
        transform.position = new Vector3(targetToFollow.position.x, targetToFollow.position.y, -10);
    }
}
