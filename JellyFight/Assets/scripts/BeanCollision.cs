using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeanCollision : MonoBehaviour
{
    public int myNumber;
    public int spawnNumber;

    public Transform ParentTransform;

    public class BeanEvent : UnityEvent<int,int>{
    }

    public BeanEvent Picked=new BeanEvent();

    void OnTriggerEnter2D(Collider2D other){
        print("bean"+other.name);
        if (other.tag == "Player"|| other.tag == "Player1"){
            gameObject.SetActive(false);
            Picked.Invoke(myNumber, spawnNumber);
        }
    }
}
