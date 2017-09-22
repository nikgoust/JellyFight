using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Floating : MonoBehaviour {

    void Start(){
        StartCoroutine(Float());
    }

    IEnumerator Float(){
        yield return new WaitForSeconds(1);
        while (true){
            transform.DOMove(new Vector3(0, 0.3f, 0), 1).SetRelative();
            yield return new WaitForSeconds(1);
            transform.DOMove(new Vector3(0, -0.3f, 0), 1).SetRelative();
            yield return new WaitForSeconds(1);
        }
    }
}
