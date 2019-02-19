using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileClick : MonoBehaviour
{
	public Tilemap tilemap;
	public Grid grid;
	public TileBase tile_dirt;
	public TileBase tile_ocean;

    // Start is called before the first frame update
    void Start()
    {
    	LoadTiles();
    }

    // Update is called once per frame
    void Update()
    {
		// save the camera as public field if you using not the main camera
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// get the collision point of the ray with the z = 0 plane
		Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
		Vector3Int position = grid.WorldToCell(worldPoint);
		//Debug.Log(position);
		TileBase hovered = tilemap.GetTile(position);
		Debug.Log(hovered.name);

		if (Input.GetMouseButtonDown(0)) 
		{
			Vector3Int posToSet = position;
			tilemap.SetTile(posToSet, tile_ocean);
			Debug.Log("Setting");
			Debug.Log(posToSet);
		}
		
    }

    // Brings in all the tiles for use within the game
    void LoadTiles()
    {
    	grid = GameObject.Find("Grid").GetComponent<Grid>();
    	tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
    	tile_dirt = AssetDatabase.LoadAssetAtPath("Assets/dirt.asset", typeof(TileBase)) as TileBase;
    	tile_ocean = AssetDatabase.LoadAssetAtPath("Assets/ocean.asset", typeof(TileBase)) as TileBase;
    }
    
}
