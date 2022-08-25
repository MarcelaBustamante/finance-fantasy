using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FinanceFantasy.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Este script es el encargado de guardar el estado del jugador y muchas cosas mas

    public static GameManager instance;
    public ItemManager itemManager;
    public Inventory inventory;


    // Recursos
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Referencias
    public Player player;
    public TileManager tileManager;
    public FloatingTextManager floatingTextManager;
    public PlotManager plotManager;
    public PlantInstantiation plantInstantiation;

    //Logic
    public float pesos;
    public int choclo;
    public int tomate;
    public int zanahoria;
    public int lechuga;
    public int zapallo;
    public int stomate;
    public int szana;
    public int schoclo;
    public int szapallo;
    public int slechuga;


    //Cosas del script de fer
    public static Action<float> PlayerMoneyChanged;
    private float _currentMoney = 1000f;

    private void Awake()
    {
        inventory = new Inventory(27);
        if (GameManager.instance != null)
        {
            Debug.LogWarning("GameManagerDestroy " + gameObject.name );
            Destroy(gameObject);
            return;
        }


        PlayerPrefs.DeleteAll();// Esto me borra todo lo que tengo en el player. Lo puse por que me tiraba error al agregar los int de semillas.

        instance = this;
        // SceneLoaded es un evento que dispara el SceneManager un vez que se carga la escena.
        // Scene manager va a ir por todas las funciones que hay en LoadState y las va a correr.
        //SceneManager.sceneLoaded += LoadState;
        LoadData();
        //Hace que el no se destruya el game manager a medida que cambio de scene
        DontDestroyOnLoad(gameObject); 
    }

 
    public void TakeMoney(float quantity)
    {
        //if (_currentMoney < quantity)
        //{
        //    print($"Something is weird, the {quantity} is greater than current player's money = {_currentMoney}");
        //    _currentMoney = 0;
        //    return;
        //}

        //_currentMoney -= quantity;
        //PlayerMoneyChanged?.Invoke(_currentMoney);

        if(pesos < quantity)
        {
            print($"Something is weird, the {quantity} is greater than current player's money = {_currentMoney}");
            pesos = 0;
            return;
        }

        pesos -= quantity;
        PlayerMoneyChanged?.Invoke(pesos);
    }

    public void GiveMoney(float quantity)
    {
        //_currentMoney += quantity;
        //PlayerMoneyChanged?.Invoke(_currentMoney);

        pesos += quantity;
        PlayerMoneyChanged?.Invoke(pesos);
    }

    public float GetMoney()
    {
        return pesos;
    }

    ///  Fin cosas script fer

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Guardo el estado (Pensar que es lo que tenemos que ir guardando entre las distintas scenes
    /*
     * int pesos
     * int manzanas
     * int herramienta
     */
    public void SaveState()
    {
        // String vacio donde ire guardando la informacion del inventario
        string s = " ";


        s += pesos.ToString() + "|";
        s += choclo.ToString() + "|";
        s += tomate.ToString() + "|";
        s += zanahoria.ToString() + "|";
        s += lechuga.ToString() + "|";
        s += zapallo.ToString() + "|";
        s += stomate.ToString() + "|";
        s += szana.ToString() + "|";
        s += schoclo.ToString() + "|";
        s += szapallo.ToString() + "|";
        s += slechuga.ToString(); //No olvidar que el ultimo no lleva el pipe


        //s += "0";
        //PlayerPrefs guarda en memoria un string llamado SaveState con el contenido de mi 
        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("Save state");
        Debug.Log(s);

        //PlayerPrefs.SetInt(plata, 1);
        //Debug.Log(plata);
    }

//REVISAR  O ENTENDER POR QUE NO ME FUNCIONA ESTO, ESTOY USAND LOADDATA para no perder la info.
    public void LoadState(Scene s, LoadSceneMode mode)
    {

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        //Agarra el string de SaveState y lo esplitea metiendolo en el array cargando el estado
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Cargo la plata
        pesos = int.Parse(data[1]); 
        choclo = int.Parse(data[2]);
        stomate = int.Parse(data[3]);
        //SemZanahoria = int.Parse(data[4]);

        //Cambio la herramienta.
        Debug.Log("update state");
        Debug.Log(pesos);
        
    }

    public void LoadData()
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            Debug.Log("no tengo SaveState");
            return;
        }
            

        //pesos = PlayerPrefs.GetInt(plata, 0);
        //Agarra el string de SaveState y lo esplitea metiendolo en el array cargando el estado
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Cargo la plata
        pesos = int.Parse(data[1]);
        choclo = int.Parse(data[2]);
        tomate = int.Parse(data[3]);
        zanahoria = int.Parse(data[4]);
        lechuga = int.Parse(data[5]);
        zapallo = int.Parse(data[6]);
        stomate = int.Parse(data[7]);
        szana = int.Parse(data[8]);
        schoclo = int.Parse(data[9]);
        szapallo = int.Parse(data[10]);
        slechuga = int.Parse(data[11]);


        //Cambio la herramienta.
        Debug.Log(data);

    }

    public bool TryCompleteOrder(Order order) {
        // Temporal
        Dictionary<string, int> translator = new Dictionary<string, int> {
            { "Choclo", choclo },
            { "Zapallo", zapallo },
            { "Tomate", tomate },
            { "Lechuga", lechuga },
            { "Zanahoria", zanahoria }
        };

        if (translator.TryGetValue(order.orderName, out var amount)) {
            if (amount >= order.amount) {
                GiveMoney(order.cost);
                switch (order.orderName) {
                    case "Choclo":
                        choclo -= order.amount;
                        break;
                    case "Zapallo":
                        zapallo -= order.amount;
                        break;
                    case "Tomate":
                        tomate -= order.amount;
                        break;
                    case "Lechuga":
                        lechuga -= order.amount;
                        break;
                    case "Zanahoria":
                        zanahoria -= order.amount;
                        break;
                }

                return true;
            }
        }
        
    
        return false;
    }
}
