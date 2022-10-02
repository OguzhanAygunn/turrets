using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] FloatingJoystick fj;
    [SerializeField] float MoveSpeed;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementOperations();
    }

    void MovementOperations(){
        if(Input.touchCount > 0 && !GameManager.GameLose){
            transform.position += new Vector3(fj.Horizontal,0,fj.Vertical) * MoveSpeed * Time.deltaTime;
        }
    }

    public void AddExplosionFunc(){
        Collider[] colliders = Physics.OverlapSphere(transform.position,20);
        foreach(var collider in colliders){
            Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
            if(rb != null){
                Debug.Log("x");
                rb.AddExplosionForce(10f,transform.position,20f,3f,ForceMode.Impulse);
                GameManager.GameLose = true;
            }
        }
    }
}
