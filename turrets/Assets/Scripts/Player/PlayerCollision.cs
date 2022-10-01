using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static List<GameObject> turrets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameManager.PlayerDestroyable = false;
    }

    private void FixedUpdate() {
        Debug.Log(turrets.Count.ToString());
    }
}
