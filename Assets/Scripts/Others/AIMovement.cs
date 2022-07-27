using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private float randomX;
    private float randomY;
    private int flip = 1;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        randomX = Random.Range(-1, 1);
        randomY = Random.Range(-1, 1);
        PickPosition();
    }

    private void MoveIn4Directions()
    {
        // Make sure we can move in this direction, by casting a box first, if the box return null, we are free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Animal", "Blocking"));
        if (hit.collider == null)
        {
            moveDelta.y += Mathf.PingPong(Time.time * speed, 1);
            //Hace que se mueve
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Animal", "Blocking"));
        if (hit.collider == null)
        {
            moveDelta.x += Mathf.PingPong(Time.time * speed, 1);
            //Hace que se mueve
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                Debug.Log("True");
                //animator.SetBool("isMoving", true);
                //animator.SetFloat("horizontal", direction.x);
                //animator.SetFloat("vertical", direction.y);
            }
            else
            {
                Debug.Log("False");
                //animator.SetBool("isMoving", false);
            }
        }
    }

    private void PickPosition()
    {
        StartCoroutine(MoveToRandomPos());
    }
    IEnumerator MoveToRandomPos()
    {
        float i = 0.0f;
        float rate = 1.0f / speed;
        moveDelta = new Vector2(transform.position.x * Time.deltaTime, 0);

        while (i < 2.0f )
        {
            i += Time.deltaTime * rate;
            Debug.Log(i);
            // Make sure we can move in this direction, by casting a box first, if the box return null, we are free to move
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Animal", "Blocking"));
            if (hit.collider != null)
            {
                flip = flip * (-1);
            }
            if (hit.collider == null)
            {
                transform.Translate(moveDelta.x * Time.deltaTime * flip, 0, 0);
            }
            yield return null;
        }

        float randomFloat = Random.Range(0.0f, 1.0f); // Create %50 chance to wait
        if (randomFloat < 0.5f)
            StartCoroutine(WaitForSomeTime());
        else
            PickPosition();
    }

    IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));
        PickPosition();
    }
}
