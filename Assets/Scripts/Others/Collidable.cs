using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    // que e
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    //Es un array que tiene informacion de a que le pegamos
    private Collider2D [] hits = new Collider2D[10];
   
    protected virtual void Start ()
    {

        //basicamente cualquier object que tenga este script va a necesitar un collider2D. Me crear un collider cuando se lo asigno a un objeto.
        boxCollider = GetComponent<BoxCollider2D>();

    }

    protected virtual void Update()
    {
        //Collision work, basicamente lo que hace es fijarse si estoy teniendo una colision con un collider y lo mete dentro del array de hits
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)//no hay nada
                continue;

                onCollide(hits[i]);//contra que choco? Le envio el collider a la funcion onCollide

            // limpiamos el array
            hits[i] = null;
        }
    }

    //se le envia un collider y se define que hacer con cada collider
    //protected virtual significa que el metodo lo puedo modificar desde la clase en la que llame a este script
    protected virtual void onCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}

