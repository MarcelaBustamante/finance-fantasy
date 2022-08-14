using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

    //Es el layer del tilemap
    [SerializeField] private Tilemap interactableMap;
    //[SerializeField] private Tile hiddenInteractableTile;
    //[SerializeField] private Tile interactedTile;
    //[SerializeField] private Tilemap siembraMap;

          

    //void Start()
    //{
    //    foreach (var position in siembraMap.cellBounds.allPositionsWithin)
    //    {
    //        //Aca lo que hago es remplazar el tile interactivo 
    //        //interactableMap.SetTile(position, hiddenInteractableTile);
    //    }
    //}

    public bool IsInteractable(Vector3Int position)
    {
        Tile tile = (Tile)interactableMap.GetTile(position);

        if (tile != null)
        {
            return true;
            //if (tile.name == "tierra")
            //{
            //    return true;
            //}
            //else if (tile.name =="sembrar")
            //{
            //    return true;
            //}

        }

        return false;
    }

    public Vector3 GetWorldPositionToTile(Vector3Int position)
    {
        return interactableMap.GetCellCenterWorld(interactableMap.WorldToCell(position));
    }


    public string TileName(Vector3Int position)
    {
        TileBase tile = (TileBase)interactableMap.GetTile(position);
        if (tile != null)
        {
            return tile.name;
        }
        return tile.name;
    }


    //public void SetInteracted(Vector3Int position)
    //{
    //    Tile tile = (Tile)interactableMap.GetTile(position);


    //    if (tile != null)
    //    {
    //        if (tile.name == "ttomate" || tile.name == "tzanahoria")
    //        {
    //            interactableMap.SetTile(position, interactedTile);
    //        }
    //    }
    //}

}
