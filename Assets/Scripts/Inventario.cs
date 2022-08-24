using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventario", menuName = "ScriptableObject/Inventario")]
public class Inventario : ScriptableObject
{
    [System.Serializable]
    public class Item
    {
        public string nombre;
        public int cantidad;
    }

    public List<Item> itemsInventario;

    // agregar, borrar, etc.
}
