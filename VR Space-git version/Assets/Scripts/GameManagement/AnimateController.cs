using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateController : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private string animationName;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void BeginAnimation()
    {
        anim.Play(animationName);
    }
}
