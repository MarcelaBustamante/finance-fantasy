using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInstantiation : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject choclo;
    public GameObject zanahoria;
    public GameObject lechuga;
    public GameObject tomate;
    public GameObject zapallo;
    private GameObject instantiatedObj;
    private Animator animator;
    // This script will simply instantiate the Prefab when the game starts.

    private void Start()
    {
       //animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
       //animator.SetBool("Cosechar", true);
       //GameManager.instance.player.animator.SetBool("Cosechar", true);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Entro con Space");

            Vector3Int position = new Vector3Int(
                 Mathf.RoundToInt(transform.position.x),
                 Mathf.RoundToInt(transform.position.y),
                 0);

            //La posicion donde voy a instanciar el prefab
            var instantiatePosition = GameManager.instance.tileManager.GetWorldPositionToTile(position);

            

            switch (GameManager.instance.tileManager.TileName(position))
            {
                case "ttomate":
                    if (GameManager.instance.stomate == 0)
                    {
                        showMsg();
                    }
                    else
                    {

                        instantiatedObj = Instantiate(tomate, instantiatePosition, Quaternion.identity);
                        GameManager.instance.stomate = GameManager.instance.stomate - 1;
                        GameManager.instance.player.animator.SetBool("Cosechar", true);
                        // animator.SetBool("Cosechar", true);
                        // ME tira error con este metodo 
                    }
                    break;

                case "tzanahoria":
                    if (GameManager.instance.zanahoria == 0)
                    {
                        showMsg();
                    }
                    else
                    {
                        instantiatedObj = Instantiate(tomate, instantiatePosition, Quaternion.identity);
                        GameManager.instance.stomate = GameManager.instance.stomate - 1;
                    }
                    break;

                case "tzapallo":
                    if (GameManager.instance.zapallo == 0)
                    {
                        showMsg();
                    }
                    else
                    {
                        instantiatedObj = Instantiate(tomate, instantiatePosition, Quaternion.identity);
                        GameManager.instance.stomate = GameManager.instance.stomate - 1;
                    }
                    break;

                case "tlechuga":
                    if (GameManager.instance.lechuga == 0)
                    {
                        showMsg();
                    }
                    else
                    {
                        instantiatedObj = Instantiate(tomate, instantiatePosition, Quaternion.identity);
                        GameManager.instance.stomate = GameManager.instance.stomate - 1;
                    }
                    break;

                case "tchoclo":
                    if (GameManager.instance.choclo == 0)
                    {
                        showMsg();
                    }
                    else
                    {
                        instantiatedObj = Instantiate(tomate, instantiatePosition, Quaternion.identity);
                        GameManager.instance.stomate = GameManager.instance.stomate - 1;
                    }
                    break;

                    
            }
        }
    }

    private void showMsg()
    {
        GameManager.instance.ShowText("Semillas insuficientes", 50, Color.red, transform.position, Vector3.up * 50, 1.0f);
    }



}
