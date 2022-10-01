using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerPlayer : Collidable
{
    public Dialogue dialogue;
    private int tuto = 0;
    protected override void onCollide(Collider2D coll)
    {

        if (coll.name == "Player")
        {
            if(tuto == 0)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                tuto = 1;
            }    
            
        }
    }
}
