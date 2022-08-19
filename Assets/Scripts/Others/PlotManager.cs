using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : Collectable
{
    public bool isPlanted = false;
    public SpriteRenderer plant;
    public Sprite[] plantStages;
    public GameObject myPrefab;
    private int verduraCant; 
    private int plantStage = 0;
    private float timeBtwStages = 2f;
    private float timer;
    private GameObject object2Destroy;
    private string verduraNombre;




    // Update is called once per frame
    private void Awake()
    {
        verduraCant = Random.Range(3, 10);
    }

    protected override void Update()
    {
        //Ignore the collisions between layer 0 (default) and layer 8 (custom layer you set in Inspector window)
        
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && plantStage < plantStages.Length - 1)
            {
                timer = timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        object2Destroy = this.gameObject;
        Debug.Log(object2Destroy);

        if (plantStage == plantStages.Length - 1)
        {

            switch (object2Destroy.name)
            {
                case "Choclo(Clone)":
                    verduraNombre = "Choclo";
                    GameManager.instance.choclo = GameManager.instance.choclo + verduraCant;
                    break;

                case "Tomate(Clone)":
                    verduraNombre = "Tomate";
                    GameManager.instance.tomate = GameManager.instance.tomate + verduraCant;
                    break;

                case "Zanahoria(Clone)":
                    verduraNombre = "Zanahoria";
                    GameManager.instance.zanahoria = GameManager.instance.zanahoria + verduraCant;
                    break;

                case "Lechuga(Clone)":
                    verduraNombre = "Lechuga";
                    GameManager.instance.lechuga = GameManager.instance.lechuga + verduraCant;
                    break;

                case "Zapallo(Clone)":
                    verduraNombre = "Zapallo";
                    GameManager.instance.zapallo = GameManager.instance.zapallo + verduraCant;
                    break;
            }
            //Cantidad de semillas recibidas
            GameManager.instance.ShowText("+ " + verduraCant + " " + verduraNombre, 50, Color.yellow, transform.position, Vector3.up * 50, 1.0f);
            Destroy(object2Destroy);
        }
        else if (plantStage == 0)
            Plant();
    }

    //private void OnMouseDown()
    //{

    //    if (isPlanted)
    //    {
    //        if (plantStage == plantStages.Length - 1)
    //            Harvest();
    //    }
    //    else
    //    {
    //        Plant();
    //    }
    //}

    public void Harvest()
    {
        Debug.Log("Harvest");
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    public void Plant()
    {
        Debug.Log("Planted");
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
        plant.sortingOrder = 3;
        plant.sortingLayerName = "Cosecha";
    }

}