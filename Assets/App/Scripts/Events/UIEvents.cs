using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public delegate void OnMainMenu();
    public static event OnMainMenu OnMainMenuEvent;

    public delegate void OnPauseMenu();
    public static event OnPauseMenu OnPauseMenuEvent;

    public delegate void OnRestartMenu(int score);
    public static event OnRestartMenu OnRestartMenuEvent;

    public static void RaiseOnMainMenu()
    {
        OnMainMenuEvent?.Invoke();
    }
    public static void RaiseOnPauseMenuEvent()
    {
        OnPauseMenuEvent?.Invoke();
    }

    public static void RaiseOnRestartMenuEvent(int score)
    {
        OnRestartMenuEvent?.Invoke(score);
    }
}
