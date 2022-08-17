using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D BoxCollider;//información del exterior
    private Vector3 moveDelta; // basicamente es para ir moviendo al muñeco. Donde estoy y donde lo voy a mandar
    private RaycastHit2D hit;
    public Animator animator;
    public Inventory inventory;
    public Joystick joystick;

    private void Awake()
    {
        inventory = new Inventory(27);
    }


    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();//es el boxcolider del muñeco
        
    }

    private void Update()//
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (joystick)
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
        }
        // Reset moveDelta - Esto se reinicia por cada frame
        moveDelta = new Vector3(x, y, 0);
        AnimateMovement(moveDelta);
        //si queremos incluir las diagonales.
        MoveIn4Directions();

    }

    private void MoveIn4Directions()
    {
        // Make sure we can move in this direction, by casting a box first, if the box return null, we are free to move
        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Hace que se mueve
            transform.Translate(0, moveDelta.y * 4 * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Hace que se mueve
            transform.Translate(moveDelta.x * 4 * Time.deltaTime, 0, 0);
        }
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }

    public void endHoeAnimation2()
    {
        //animator.SetBool("Cosechar", false);
        Debug.Log("Triger stop");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("El palyer en colsion");
        //animator.SetBool("Cosechar", true);
    }

}