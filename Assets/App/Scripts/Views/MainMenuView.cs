using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void StartAnimation()
    {
        anim.SetTrigger("Start");
    }
}
