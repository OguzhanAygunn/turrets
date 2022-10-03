using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSlimeController : MonoBehaviour
{
    public Transform targetPos;
    private float moveSpeed = 4f;
    [SerializeField] float radius;
    Collider[] hitColliders = new Collider[1];
    [SerializeField] LayerMask targetLayer;
    bool freezeMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementOperations();
        lookAtOperations();
        radar();
    }

    void radar(){
        hitColliders = Physics.OverlapSphere(transform.position, radius, targetLayer);
        if((targetPos == null || targetPos.gameObject.CompareTag("Player")) && hitColliders != null){
            foreach(var obj in hitColliders){
                targetPos = obj.transform;
            }
        }
    }

    void movementOperations(){
        if(targetPos && !freezeMove && !GameManager.GameLose && !GameManager.GameWin)
        transform.position = Vector3.MoveTowards(transform.position,targetPos.position,moveSpeed*Time.deltaTime);
    }

    void lookAtOperations(){
        if(targetPos)
        transform.LookAt(targetPos.position,transform.up);
    }
}
