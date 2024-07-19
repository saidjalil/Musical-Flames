using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RestartMenuController : MonoBehaviour
{
    [SerializeField] private RestartMenuView _view;
    private float _fadeInTime = 1f;
    private float _fadeOutTime = 0.4f;

    private void OnEnable()
    {
        UIEvents.OnRestartMenuEvent += OnRestartMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnRestartMenuEvent -= OnRestartMenuEventHandler;
    }
    private void OnRestartMenuEventHandler(int score)
    {
        _view.gameObject.SetActive(true);  // Activate the restart menu
        _view.PlayAudio();
        _view.gameObject.GetComponent<RectTransform>().DOScale(1f, _fadeInTime).SetEase(Ease.OutBounce);
        _view.SetScore(score);
    }
    public void OnTryAgainPressed()
    {
        StartCoroutine(EaseOut());
        GameEvents.RaiseOnGeneratePatternEvent();
    }
    public void ExitButtonPressed() 
    {
        StartCoroutine(EaseOut());
        _view.ExitAnimation();
    }
    private IEnumerator EaseOut() // do tween effect coroutine
    {
        GameEvents.RaiseOnGameRestartEvent(); // Restart the game values
        _view.gameObject.GetComponent<RectTransform>().DOScale(0f, _fadeOutTime);
        yield return new WaitForSeconds(_fadeOutTime);
        _view.gameObject.SetActive(false);

    }
}
