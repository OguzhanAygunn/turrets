using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool PlayerDestroyable,GameLose,GameWin,GameStart;
    public static int levelCoinScore;
    public static void Start(){
        PlayerDestroyable = false;
        GameLose          = false;
        GameWin           = false;
        GameStart         = false;
        levelCoinScore    = 0;
    }
}
