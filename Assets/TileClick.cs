using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileClick : MonoBehaviour
{
	public Tilemap tilemap;
	public Grid grid;
	public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        Debug.Log("Found tile map!");
        grid = GameObject.Find("Grid").GetComponent<Grid>();;
    }

    // Update is called once per frame
    void Update()
    {
    	float inputX = Input.GetAxis ("Horizontal");
         float inputZ = Input.GetAxis ("Vertical");
         
         if (inputX != 0)
             rotate ();
         if (inputZ != 0)
             move ();

            void rotate(){
     transform.Rotate (new Vector3 (0f, inputX * Time.deltaTime, 0f));
 }
 
 void move(){
     transform.position += transform.forward * inputZ * Time.deltaTime;
 }

		// save the camera as public field if you using not the main camera
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// get the collision point of the ray with the z = 0 plane
		Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
		Vector3Int position = grid.WorldToCell(worldPoint);
		Debug.Log(position);
		TileBase hovered = tilemap.GetTile(position);
		Debug.Log(hovered);
		Debug.Log(hovered.name);
    }

    
}
