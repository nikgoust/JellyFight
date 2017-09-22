using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePosition : MonoBehaviour {
    public GameObject firstObject;
    public GameObject secondObject;
    private Transform _firstTransform;
    private Transform _secondTransform;
    public float magnitude;

    // Use this for initialization
    void Start () {
        _firstTransform = firstObject.transform;
        _secondTransform = secondObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
		transform.position= (_firstTransform.position + _secondTransform.position) /2;
	    magnitude = (_firstTransform.position - _secondTransform.position).magnitude;
	}
}
