using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class PlantInstantiation : Collidable
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject choclo;
    public GameObject zanahoria;
    public GameObject lechuga;
    public GameObject tomate;
    public GameObject zapallo;
    private GameObject instantiatedObj;
    private Animator animator;
    private int tap = 0;
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Tomate(Clone)")
        {
            Debug.Log("Choquecon un prefab");
        }

    }


    protected override void onCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
        //Debug.Log(tap);
        if (coll.name == "Rock" && tap > 0)
        {
            Debug.Log(coll.name);

            var rock = coll.GetComponent<RockSystem>();

            if (rock)
            {
                rock.TakeHit(1);//Quito vida a la piedra
            }
            GameManager.instance.player.animator.SetBool("Minar", true);
            tap = 0;

        }
        else if(coll.name == "Tree" && tap > 0)
        {
            var tree = coll.GetComponent<TreeSystem>();

            if (tree)
            {
                tree.TakeHit(1);//Quito vida a la madera
            }
            GameManager.instance.player.animator.SetBool("Talar", true);
            tap = 0;
        }
            
    }

    public void playerAction()
    {

        tap++;//Registro que estoy haciendo tap en el CTA

        Vector3Int position = new Vector3Int(
             Mathf.RoundToInt(transform.position.x),
             Mathf.RoundToInt(transform.position.y),
             0);

        if (GameManager.instance.tileManager.TileName(position) != "")
        {
            instanciarPrefab(position);
            tap = 0;
        }
            
    }


    void instanciarPrefab(Vector3Int position)
    {

        var instantiatePosition = GameManager.instance.tileManager.GetWorldPositionToTile(position);

        switch (GameManager.instance.tileManager.TileName(position))
        {
            case "ttomate":
                if (GameManager.instance.stomate == 0)
                {
                    showMsg("Semillas insuficientes");
                }
                else
                {
                    instantiatedObj = Instantiate(tomate, instantiatePosition, Quaternion.identity);
                    GameManager.instance.stomate = GameManager.instance.stomate - 1;
                    GameManager.instance.player.animator.SetBool("Cosechar", true);
                }
                break;

            case "tzanahoria":
                if (GameManager.instance.szana == 0)
                {
                    showMsg("Semillas insuficientes");
                }
                else
                {
                    instantiatedObj = Instantiate(zanahoria, instantiatePosition, Quaternion.identity);
                    GameManager.instance.szana = GameManager.instance.szana - 1;
                    GameManager.instance.player.animator.SetBool("Cosechar", true);
                }
                break;

            case "tzapallo":
                if (GameManager.instance.szapallo == 0)
                {
                    showMsg("Semillas insuficientes");
                }
                else
                {
                    instantiatedObj = Instantiate(zapallo, instantiatePosition, Quaternion.identity);
                    GameManager.instance.szapallo = GameManager.instance.szapallo - 1;
                    GameManager.instance.player.animator.SetBool("Cosechar", true);
                }
                break;

            case "tlechuga":
                if (GameManager.instance.slechuga == 0)
                {
                    showMsg("Semillas insuficientes");
                }
                else
                {
                    instantiatedObj = Instantiate(lechuga, instantiatePosition, Quaternion.identity);
                    GameManager.instance.slechuga = GameManager.instance.slechuga - 1;
                    GameManager.instance.player.animator.SetBool("Cosechar", true);
                }
                break;

            case "tchoclo":
                if (GameManager.instance.schoclo == 0)
                {
                    showMsg("Semillas insuficientes");
                }
                else
                {
                    instantiatedObj = Instantiate(choclo, instantiatePosition, Quaternion.identity);
                    GameManager.instance.schoclo = GameManager.instance.schoclo - 1;
                    GameManager.instance.player.animator.SetBool("Cosechar", true);
                }
                break;
        }
    }

    private void showMsg(string txt)
    {
        GameManager.instance.ShowText(txt, 50, Color.red, transform.position, Vector3.up * 50, 1.0f);
    }



}
