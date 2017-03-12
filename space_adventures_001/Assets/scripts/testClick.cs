using UnityEngine;
using System.Collections;
using System.IO;

public class testClick : MonoBehaviour {
	public static LevelProps[] levelProps;
	public int objectNumber = 0;
	private Rigidbody rb;
	private Vector3 position;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		init();
		
		objectsMoving();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
        Debug.Log("fap-fap   "+objectNumber);
	}
	
	void OnMouseUp() {
        Debug.Log("Wiiiiii   "+objectNumber);
    }
	
	void OnMouseDrag() {
		float distance_to_screen;
        Vector3 pos_move;
		
		distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
		transform.position = new Vector3( pos_move.x, pos_move.y, pos_move.z );
	}
	
	private void objectsMoving()
	{
		switch(objectNumber)
		{
			case 2: 
				position = new Vector3(levelProps[0].caps_x, levelProps[0].caps_y, levelProps[0].caps_z);
				rb.MovePosition(position);
				break;
			case 1:
				//hi girls!
				break;
		}
	}
	
	private void init()
	{
		string path = Application.streamingAssetsPath + "/gameProperties.json";
		string jsonString = File.ReadAllText(path);
		levelProps = JsonHelper.FromJson<LevelProps> (jsonString);

		Debug.Log("x "+levelProps[0].caps_x);
		Debug.Log("y "+levelProps[0].caps_y);
		Debug.Log("z "+levelProps[0].caps_z);
	}
}
