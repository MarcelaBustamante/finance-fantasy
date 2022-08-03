using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

    //Es el layer del tilemap
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;

    void Start()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            //Aca lo que hago es remplazar el tile interactivo 
            //interactableMap.SetTile(position, hiddenInteractableTile);
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        Tile tile = (Tile)interactableMap.GetTile(position);


        if (tile != null)
        {
            if (tile.name == "tierra")
            {
                return true;
            }

        }

        return false;
    }



    public TileBase TileName(Vector3Int position)
    {
        TileBase tile = (TileBase)interactableMap.GetTile(position);

        if (tile != null)
        {
            return tile;
        }

        //return "es nulo " + position;
        return tile;

    }

    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);

    }
}
