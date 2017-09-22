using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Move : MonoBehaviour
{
    [SerializeField] private int _health ;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public GameController GameController;
    public GameObject ART;
    public GameObject AllHearts;
    public GameObject[] Hearts;
    private Rigidbody2D _rb2d;
    private Transform _childTransform;
    // Use this for initialization
    void Start (){
        _rb2d = GetComponent<Rigidbody2D>();
        _childTransform = ART.transform;
    }
	
	// Update is called once per frame
	void FixedUpdate (){
	    if (Input.GetButton("Horizontal")) Run();
        if (IsGrounded() && Input.GetButtonDown("Jump")) Jump();
    }

    void Run(){
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(transform.position, Vector3.MoveTowards(transform.position, transform.position+direction, _speed*Time.deltaTime),0.4f);
        if (direction.x>0.0f){
            Quaternion rotate = Quaternion.Euler(_childTransform.rotation.x, 145f, _childTransform.rotation.z);
            _childTransform.rotation = rotate;
        }
        else{
            Quaternion rotate = Quaternion.Euler(_childTransform.rotation.x, 215f, _childTransform.rotation.z);
            _childTransform.rotation = rotate;
        }
    }

    void Jump(){
        _rb2d.AddForce(transform.up* _jumpForce,ForceMode2D.Impulse);
    }

    bool IsGrounded(){
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        if (collider.Length > 1)return true;
        else return false;
    }

    public void GetHit(int damage){
        _health -= damage;
        if (_health < 0){
            GameController.GameOver();
        }
        Hearts[_health].SetActive(false);
        StartCoroutine(ShowHealths());
    }

    public void GetHealth(int health){
        if (_health < 5){
            _health += health;
            Hearts[_health-1].SetActive(true);
        }
        StartCoroutine(ShowHealths());
    }

    public void GetSpeed(){
        StartCoroutine(Speed());
    }

    IEnumerator ShowHealths(){
        AllHearts.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        AllHearts.SetActive(false);
    }

    IEnumerator Speed(){
        _speed = 18;
        yield return new WaitForSeconds(10);
        _speed = 10;
    }
}
