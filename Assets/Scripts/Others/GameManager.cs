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
        if(GameManager.instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        // SceneLoaded es un evento que dispara el SceneManager un vez que se carga la escena.
        // Scene manager va a ir por todas las funciones que hay en LoadState y las va a correr.
        SceneManager.sceneLoaded += LoadState;
        //Hace que el no se destruya el game manager a medida que cambio de scene
        DontDestroyOnLoad(gameObject);
    }

    // Recursos
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Referencias
    public player player;

    //Logic
    public int pesos;
    public int manazana;

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

        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("save state");
    }

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
    }
}
