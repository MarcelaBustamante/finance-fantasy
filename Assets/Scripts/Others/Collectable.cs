using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;

    public CollectableType type;

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
            player.inventory.Add(type);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, CARROTE_SEED, TOMATOES_SEED, STRAWBERRY_SEED, CORN_SEED
}