using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;

    public CollectableType type;
    public Sprite icon;
    
    protected override void onCollide(Collider2D coll)
    {
        if(coll.name == "Player")
            OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
     
        if (player)
        {
            GameManager.instance.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE = 0,
    CARROTE_SEED = 1,
    TOMATOES_SEED = 2, 
    LETTUCE_SEED = 3, 
    CORN_SEED = 4
}