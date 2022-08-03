using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArarTierra : Collidable
{
    public Sprite tierraArada;

    protected override void onCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = tierraArada;
        }  
    }

}



