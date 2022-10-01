using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpShowMessage : MonoBehaviour
{
    public string popUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
        pop.PopUp(popUp);
        Debug.Log("colision");
        var bubbleParent = gameObject;
        var bubble = bubbleParent.transform.GetChild(0);


        bubble.gameObject.SetActive(false);
    }

}