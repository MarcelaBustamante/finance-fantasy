using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private BoxCollider2D BoxCollider;//información del exterior
    private Vector3 moveDelta; // basicamente es para ir moviendo al muñeco. Donde estoy y donde lo voy a mandar
    private RaycastHit2D hit;
    
    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();//es el boxcolider del muñeco

    }

    private void FixedUpdate()//
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset moveDelta - Esto se reinicia por cada frame
        moveDelta = new Vector3(x,y,0);

        //Swap sprite direction, wether you're going right or left
        if(moveDelta.x > 0)
            transform.localScale = Vector3.one;
            else if (moveDelta.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);

        // Make sure we can move in this direction, by casting a box first, if the box return null, we are free to move
        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if ( hit.collider == null)
        {
            //Hace que se mueve
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if ( hit.collider == null)
        {
            //Hace que se mueve
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
    }
}
