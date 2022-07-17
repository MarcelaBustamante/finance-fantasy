using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMotor : MonoBehaviour
{
    public Transform lookAt; // LookAt despues lo vamos a definir desde el ui de Unity, vamos a completarlo con el caracter que queremos que siga.
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //Esto es para chequear si estamos dentro de los limites del eje X
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        //Esto es para chequear si estamos dentro de los limites del eje y
        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaY > boundY || deltaY < -boundY)
        {
            if(transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y,0);
    }
}
