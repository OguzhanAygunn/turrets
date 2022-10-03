using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallController : MonoBehaviour
{
    [SerializeField] float minY;
    CameraController cameraController;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        cameraController = Camera.main.gameObject.GetComponent<CameraController>();
        rigidbody        = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mainOperations();
    }

    void mainOperations(){
        if(transform.position.y < minY && !GameManager.GameLose){
            cameraController.GameDeathController();
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
