using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxLocalSemillas : Collidable
{
    public string sceneName;

    protected override void onCollide(Collider2D coll)
    {
        if(coll.name == "Player" )
        {
            //Nos vamos al local de semillas
            //Cargamos la scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
