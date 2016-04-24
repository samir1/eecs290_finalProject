using UnityEngine;
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
		changeTarget ();
	}

	void FixedUpdate () {
		movingHouse.position = Vector3.Lerp (movingHouse.position, newPosition, smooth * Time.deltaTime);
	}

	void changeTarget() {
		if (currentState == "Moving to Position2") {
			currentState = "Moving to Position3";
			newPosition = position3.position;
		} else if (currentState == "Moving to Position3") {
			currentState = "Moving to Position4";
			newPosition = position4.position;
		} else if (currentState == "Moving to Position4") {
			currentState = "Moving to Position1";
			newPosition = position1.position;
		} else if (currentState == "Moving to Position1") {
			currentState = "Moving to Position2";
			newPosition = position2.position;
		}else if(currentState == ""){
			currentState = "Moving to Position2";
			newPosition = position2.position;
		}
		Invoke ("changeTarget", resetTime);
	}

}


