using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMain : Collectable
{
    public string sceneName = "Main";

    protected override void onCollide(Collider2D coll)
    {
            //Guardo el estado actual         
            GameManager.instance.SaveState();
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
