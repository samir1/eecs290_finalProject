using UnityEngine
using System.Collections;

public class SafeHouse : MonoBehaviour {


	public Transform movingHouse;
	public Transform position1;
	public Transform position2;
	public Transform position3;
	public Transform position4;

	public Vector3 newPosition;
	public string currentState;
	public float smooth;
	public float resetTime;

 
	void Start () {

	}

	void FixedUpdate () {
		movingHouse.position = Vector3.Lerp (movingHouse.position, newPosition, smooth * Time.delatTime);
	}


}


