using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Player2 : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 15f;

    public GameController GameController;
    public GameObject ART;
    private Rigidbody2D _rb2d;
    private Transform _childTransform;
    
    void Start(){
        _rb2d = GetComponent<Rigidbody2D>();
        _childTransform = ART.transform;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (Input.GetButton("Horizontal1")) Run();
        if (IsGrounded() && Input.GetButtonDown("Jump1")) Jump();
    }

    void Run(){
        Vector3 direction = transform.right * Input.GetAxis("Horizontal1");
        transform.position = Vector3.Lerp(transform.position, Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime), 0.4f);
        if (direction.x > 0.0f){
            Quaternion rotate = Quaternion.Euler(_childTransform.rotation.x, 145f, _childTransform.rotation.z);
            _childTransform.rotation = rotate;
        }
        else{
            Quaternion rotate = Quaternion.Euler(_childTransform.rotation.x, 215f, _childTransform.rotation.z);
            _childTransform.rotation = rotate;
        }
    }

    void Jump(){
        _rb2d.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded(){
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        if (collider.Length > 1) return true;
        else return false;
    }

    void GetHit (int damage){
        _health -= damage;
        if (_health<0){
            GameController.GameOver();
        }
    }
}
