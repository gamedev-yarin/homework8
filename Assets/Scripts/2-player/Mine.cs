using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mine : KeyboardMover
{
    /**
 * This component allows the player to dig through tiles ​​on the map and level them down
 */

    [SerializeField] Tilemap tilemap = null;
    [SerializeField] TileBase[] MineTiles = new TileBase[3];
    [SerializeField] float waitAfretMine = 2f;

    public bool PlayerMine = false;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && Input.GetKey(KeyCode.X)) MineTile();
 
    }

    private TileBase TileOnPosition(Vector3 worldPosition) //return the tile on a given position
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    void MineTile()
    {
        Vector3 newPositionV3 = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPositionV3);
        Vector3Int newPosition = new Vector3Int((int)newPositionV3.x, (int)newPositionV3.y, 0);
        if (tileOnNewPosition != MineTiles[0] && !PlayerMine) //if the tile is not on the lowest level and thr player donot mining anymore
        {
            StartCoroutine(MineAndWait(newPosition, Array.IndexOf(MineTiles, tileOnNewPosition)));
        }

        Debug.Log("mine: " + tileOnNewPosition);
        
    }

    private IEnumerator MineAndWait(Vector3Int newPosition, int TileNum)
    {
        Debug.Log("mine: " + newPosition + "  " + TileNum);
        PlayerMine = true;
        yield return new WaitForSeconds(waitAfretMine);
        PlayerMine = false;
        tilemap.SetTile(newPosition, MineTiles[TileNum-1]);
    }

}
