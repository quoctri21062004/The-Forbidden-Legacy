using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAnimation : BaseEnemyAnimation
{
   // [Header("Night Borne Animation")]

    public virtual void EnemyDestroyAnim()
    {
        animator.SetBool("IsDestroy",true);
    }
}
