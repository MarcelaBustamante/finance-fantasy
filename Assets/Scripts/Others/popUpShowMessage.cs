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
        //GameObject.Find("bubble-attention");

        //Transform child = transform.GetChild(0);
        //Debug.Log(child.name);

        bubble.gameObject.SetActive(false);
    }

}