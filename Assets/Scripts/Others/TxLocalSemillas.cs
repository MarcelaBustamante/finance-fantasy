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
            //Guardo el estado actual antes de irme al local de semillas            
            GameManager.instance.SaveState();
            ////Nos vamos al local de semilla, Cargamos la scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
         
        }
    }
}
