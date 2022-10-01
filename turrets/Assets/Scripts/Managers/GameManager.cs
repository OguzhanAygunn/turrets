using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool PlayerDestroyable,GameLose;

    static void Start(){
        PlayerDestroyable = false;
        GameLose          = false;
    }
}
