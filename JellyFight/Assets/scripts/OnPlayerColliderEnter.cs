using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerColliderEnter : MonoBehaviour
{
    public Move Move;
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Foe"){
            Move.GetHit(3);
        }
        if (other.name == "bean_green"){
            Move.GetHit(1);
        }
        if (other.name == "bean_red"){
            Move.GetHealth(1);
        }
        if (other.name == "bean_blue"){
            Move.GetSpeed();
        }

    }
}
