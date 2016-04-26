using UnityEngine;
using System.Collections;

public class SafeHouse : MonoBehaviour {


	public GameObject position1;
	public GameObject position2;
	public GameObject position3;
	public GameObject position4;
	public GameObject safeHouse;

	public Vector3 newPosition;
	public string currentState;
	public float smooth;
	public float resetTime;


	void Start () {
		InvokeRepeating("changeLocation", 30f, 30f);
	}

	void changeLocation() {
		int randomNum = Random.Range(1, 5);
		switch (randomNum) {
		case 1:
			safeHouse.transform.position = new Vector3(position1.transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), position1.transform.position.z);
			break;
		case 2:
			safeHouse.transform.position = new Vector3(position2.transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), position2.transform.position.z);
			break;
		case 3:
			safeHouse.transform.position = new Vector3(position3.transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), position3.transform.position.z);
			break;
		case 4:
			safeHouse.transform.position = new Vector3(position4.transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), position4.transform.position.z);
			break;
		default:
			print ("Unknown location");
			break;
		}
	}

}


