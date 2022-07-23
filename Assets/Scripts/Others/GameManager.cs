using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Este script es el encargado de guardar el estado del jugador y muchas cosas mas

    // Se puede obtener la 
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
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

    public void LoadState()
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
