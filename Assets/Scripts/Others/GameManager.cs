using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Este script es el encargado de guardar el estado del jugador y muchas cosas mas

    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        // SceneLoaded es un evento que dispara el SceneManager un vez que se carga la escena.
        // Scene manager va a ir por todas las funciones que hay en LoadState y las va a correr.
        //SceneManager.sceneLoaded += LoadState;
        LoadData();
        //Hace que el no se destruya el game manager a medida que cambio de scene
        DontDestroyOnLoad(gameObject);
        tileManager = GetComponent<TileManager>();
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
    //Logic
    public int pesos;
    public int manazana;

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
        string s = " ";


        s += pesos.ToString() + "|";
        s += manazana.ToString() + "|";
        s += "0" + "|";
        //PlayerPrefs guarda en memoria un string llamado SaveState con el contenido de mi 
        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("Save state");
        Debug.Log(s);

        //PlayerPrefs.SetInt(plata, pesos);
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
        manazana = int.Parse(data[2]);
        
        //Cambio la herramienta.
        Debug.Log("update state");
        Debug.Log(pesos);
        
    }

    public void LoadData()
    {
        //pesos = PlayerPrefs.GetInt(plata, 0);
        //Agarra el string de SaveState y lo esplitea metiendolo en el array cargando el estado
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Cargo la plata
        pesos = int.Parse(data[1]);
        manazana = int.Parse(data[2]);

        //Cambio la herramienta.
        Debug.Log("update state");
        Debug.Log(pesos);

    }
}
