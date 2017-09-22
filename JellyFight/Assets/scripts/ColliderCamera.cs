using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCamera : MonoBehaviour {
    private Vector3 pos;

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Boundery")
        {
            print(other.tag);
            pos = transform.position;
            pos.y += 0.2f;
            transform.position = pos;
        }

    }
}
