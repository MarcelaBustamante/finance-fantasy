using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : Collectable
//Cofre hereda todo lo que tengo definido en mi script Collectable 
{
    //Cambio el aspecto del cofre y cuanto voy a dar de recomepnsa
    public Sprite cofreVacio;
    public int pesosAmount = 5;
   
    //Aca estoy sobreescribiendo el metodo onCollect que tengo definido en el script Collidable
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            //Aca lo que hago es cambiar el sprit del cofre
            GetComponent<SpriteRenderer>().sprite = cofreVacio;
            Debug.Log("Grant" + pesosAmount + "pesos!" );
        }
        
    }

}
