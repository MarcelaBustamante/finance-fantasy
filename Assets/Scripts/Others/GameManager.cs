using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Este script es el encargado de guardar el estado del jugador y muchas cosas mas

    public static GameManager instance;
    public ItemManager itemManager;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
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
    public int pesos;
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
}
