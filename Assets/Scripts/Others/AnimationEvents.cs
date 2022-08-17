using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void endHoeAnimation()
    {
        //animator.SetBool("Cosechar", false);
        GameManager.instance.player.animator.SetBool("Cosechar", false);
        Debug.Log("Triger stop");
    }
}
