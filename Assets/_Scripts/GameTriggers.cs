using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameTriggers
{
    public static Action OnPlayerAssigned;
    public static Action OnWaveEnd;
    public static Action OnCharSelect;
    
    public static Action OnGameEnd;
    public static Action OnGameStart;
    public static Action OnGameRestart;
    public static Action OnGameQuit;
}
