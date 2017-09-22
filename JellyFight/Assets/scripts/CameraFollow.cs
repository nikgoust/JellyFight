using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector2 _xBoundery;
    [SerializeField] private Vector2 _yBoundery;
    [SerializeField] private float _distanceZ;
    private Vector3 _newPositionVector3;
    private Camera camera;

    public MiddlePosition objectToFollow;
    private Transform _objectTransform;


    void Start()
    {
        _objectTransform = objectToFollow.transform;
        _newPositionVector3.z = _distanceZ;
        camera = GetComponent<Camera>();

    }

    void Update()
    {
        _newPositionVector3 = NewPosition(_xBoundery, _yBoundery);

        if (objectToFollow.magnitude > 9) camera.orthographicSize = 5 + (objectToFollow.magnitude - 9) / 3;
        if ((_newPositionVector3.y - (objectToFollow.magnitude - 9) / 3) < 0){
           _newPositionVector3.y = (objectToFollow.magnitude - 9) / 3;
        }
        transform.position = _newPositionVector3;
    }

    Vector3 NewPosition(Vector2 xBoundery, Vector2 yBoundery){
        if ((xBoundery.x < _objectTransform.position.x) && (xBoundery.y > _objectTransform.position.x)){
            _newPositionVector3.x = _objectTransform.position.x;
        }
        if ((yBoundery.x < _objectTransform.position.y) && (yBoundery.y > _objectTransform.position.y)){
            _newPositionVector3.y = _objectTransform.position.y;
        }
        if (yBoundery.x > _objectTransform.position.y){
            _newPositionVector3.y = yBoundery.x;
        }
        return _newPositionVector3;
    }
}