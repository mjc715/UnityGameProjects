using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRateTMP : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ResetAnimator()
    {
        anim.SetBool("rateIncrease", false);
    }
}
