using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuView _view;
     private void OnEnable()
    {
        UIEvents.OnMainMenuEvent += OnMainMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnMainMenuEvent -= OnMainMenuEventHandler;
    }
     public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        GameEvents.RaiseOnGameRestartEvent();
        GameEvents.RaiseOnGeneratePatternEvent();

        _view.StartAnimation();
    }
    private void OnMainMenuEventHandler()
    {
        _view.gameObject.SetActive(true);
    }
}
