using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartMenuView : MonoBehaviour
{
     [SerializeField] private Animator animator;

     [SerializeField] private TMP_Text scoreText;

    public void ExitAnimation() // Exit animation to menu
    {
        animator.SetTrigger("Exit");
    }

    public void SetScore(int score) // showing score
    {
        scoreText.text = "Score:" + score;
    }

    public void PlayAudio() // Playing the lose audio
    {
        GetComponentInChildren<AudioSource>().Play();
    }
}
