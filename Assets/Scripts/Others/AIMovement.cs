using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 0.2f;
    public Animator animator;

    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;
    internal Vector2[] moveDirections = new Vector2[] {
        Vector2.right,
        Vector2.left,
        Vector2.up,
        Vector2.down,
        Vector2.zero,
        Vector2.zero
    };
    internal Vector2 currentMoveDir;

    void Start()
    {
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        ChooseMoveDirection();
    }

    void Update()
    {
        if (decisionTimeCount > 0)
        {
            decisionTimeCount -= Time.deltaTime;
        }
        else
        {
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
            ChooseMoveDirection();
        }
        AnimateMovement();

    }

    void FixedUpdate()
    {
        Vector2 delta = currentMoveDir * Time.deltaTime * speed;
        transform.position += new Vector3(delta.x, delta.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        currentMoveDir *= -1;
    }

    void ChooseMoveDirection()
    {
        int selected = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
        currentMoveDir = moveDirections[selected];
    }

    void AnimateMovement()
    {
        if (animator != null)
        {
            if (currentMoveDir.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", currentMoveDir.x);
                animator.SetFloat("vertical", currentMoveDir.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
