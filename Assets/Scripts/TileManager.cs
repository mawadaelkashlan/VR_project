using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs; // to make list of different tiles
    public float zSpawn = 0; // the initial value of start point of z coordinate the tile start from 
    public float tileLength = 30; // length of tile
    public int numberOfTiles = 5; // number of tiles that game combine
    private List<GameObject> activeTiles = new List<GameObject>(); //to generate many tiles by default and put them in a list
    public Transform playerTransform;
    void Start()
    {
        for (int i=0; i<numberOfTiles; i++)  // to generate Tiles limited by num of Tiles(5)
        {
            if (i==0)
                SpawnTile(0); // to make the first tile to appear is tile with index(0) (the first Tile, Tile1) 
            else
                SpawnTile(Random.Range(0,tilePrefabs.Length)); // to generate any random tile from tiles(index 0:5)
        }
    }
    void Update()
    {
        if (playerTransform.position.z-35 >zSpawn-(numberOfTiles*tileLength)) //35 ==> to prevent deleting first tile when player start playing
        { 
            SpawnTile(Random.Range(0,tilePrefabs.Length)); // to generate any random tile from tiles(index 0:5)
            DeleteTile(); // to delete previous tiles to prevent pc from Hang
        }
    }
    public void SpawnTile(int tileIndex) // method to generate ininite tiles
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex],transform.forward * zSpawn, transform.rotation); // object that generated(random Tile)
        activeTiles.Add(go); // to add the generated tile in activetiles List
        zSpawn+= tileLength; // to add 30 to zSpawn in each Tilegeneration
    }
    private void DeleteTile()  // method used to remove
    {
        Destroy(activeTiles[0]); // to stop using the first tile that the player go on 
        activeTiles.RemoveAt(0); // to remove the first tile that the player go on from activeTiles List
    }
}
