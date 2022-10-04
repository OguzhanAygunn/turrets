using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool PlayerDestroyable,GameLose,GameWin;
    public static int levelCoinScore;
    public static void Start(){
        PlayerDestroyable = false;
        GameLose          = false;
        levelCoinScore    = 0;
    }
}
