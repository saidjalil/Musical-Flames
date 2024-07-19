using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartMenuView : MonoBehaviour
{
     [SerializeField] private Animator animator;

     [SerializeField] private TMP_Text scoreText;

    public void ExitAnimation()
    {
        animator.SetTrigger("Exit");
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score:" + score;
    }
}
