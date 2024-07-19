using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void OnGeneratePattern();
    public static event OnGeneratePattern OnGeneratePatternEvent;

    public delegate void OnGameRestart();
    public static event OnGameRestart OnGameRestartEvent;


    public static void RaiseOnGeneratePatternEvent()
    {
        OnGeneratePatternEvent?.Invoke();
    }
    public static void RaiseOnGameRestartEvent()
    {
        OnGameRestartEvent?.Invoke();
    }
}
