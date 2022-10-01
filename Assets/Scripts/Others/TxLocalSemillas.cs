using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxLocalSemillas : Collidable
{
    public string sceneName;
    public Animator transition;
    public float transitionTime = 1f;//Tiempo que quiero que tome la transición
    protected override void onCollide(Collider2D coll)
    {
        if(coll.name == "Player" )
        {
            //Guardo el estado actual antes de irme al local de semillas            
            GameManager.instance.SaveState();
            ////Nos vamos al local de semilla, Cargamos la scene
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            StartCoroutine(LoadLevel(sceneName));

        }
    }

    public void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel (string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

    }
}
