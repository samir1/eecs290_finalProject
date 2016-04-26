using UnityEngine;
using System.Collections;

public class Rockpiles : MonoBehaviour {

	public Transform Rock8;
	public Transform Rock8_position1;
	public Transform Rock8_position2;
	public Vector3 newPosition8;
	public string currentState8;

	public Transform Rock19;
	public Transform Rock19_position1;
	public Transform Rock19_position2;
	public Vector3 newPosition19;
	public string currentState19;

	public Transform Rock12;
	public Transform Rock12_position1;
	public Transform Rock12_position2;
	public Vector3 newPosition12;
	public string currentState12;

	public Transform Rock6;
	public Transform Rock6_position1;
	public Transform Rock6_position2;
	public Vector3 newPosition6;
	public string currentState6;

	public Transform Rock14;
	public Transform Rock14_position1;
	public Transform Rock14_position2;
	public Vector3 newPosition14;
	public string currentState14;



	public float smooth;
	public float resetTime;


	void Start () {
		changeTarget ();
	}

	void FixedUpdate() {
		
		Rock8.position = Vector3.Lerp (Rock8.position, newPosition8, smooth * Time.deltaTime);
		Rock19.position = Vector3.Lerp (Rock19.position, newPosition19, smooth * Time.deltaTime);
		Rock12.position = Vector3.Lerp (Rock12.position, newPosition12, smooth * Time.deltaTime);
		Rock6.position = Vector3.Lerp (Rock6.position, newPosition6, smooth * Time.deltaTime);
		Rock14.position = Vector3.Lerp (Rock14.position, newPosition14, smooth * Time.deltaTime);

	}

	void changeTarget(){

		//rock8
		if (currentState8 == "Rock8 Moving to position 1"){
			
			currentState8 = "Rock8 Moving to position 2";
			newPosition8 = Rock8_position2.position;

		}else if(currentState8 == "Rock8 Moving to position 2"){
			
			currentState8 = "Rock8 Moving to position 1";
			newPosition8 = Rock8_position1.position;
			
		}else if(currentState8 == ""){
			
			currentState8 = "Rock8 Moving to position 2";
			newPosition8 = Rock8_position2.position;
		}

		//rock19

		if (currentState19 == "Rock19 Moving to position 1"){

			currentState19 = "Rock19 Moving to position 2";
			newPosition19 = Rock19_position2.position;

		}else if(currentState19 == "Rock19 Moving to position 2"){

			currentState19 = "Rock19 Moving to position 1";
			newPosition19 = Rock19_position1.position;

		}else if(currentState19 == ""){

			currentState19 = "Rock19 Moving to position 2";
			newPosition19 = Rock19_position2.position;
		}

		//rock12

		if (currentState12 == "Rock12 Moving to position 1"){

			currentState12 = "Rock12 Moving to position 2";
			newPosition12 = Rock12_position2.position;

		}else if(currentState12 == "Rock12 Moving to position 2"){

			currentState12 = "Rock12 Moving to position 1";
			newPosition12 = Rock12_position1.position;

		}else if(currentState12 == ""){

			currentState12 = "Rock12 Moving to position 2";
			newPosition12 = Rock12_position2.position;
		}

		//Rock 6
		if (currentState6 == "Rock6 Moving to position 1"){

			currentState6 = "Rock6 Moving to position 2";
			newPosition6 = Rock6_position2.position;

		}else if(currentState6 == "Rock6 Moving to position 2"){

			currentState6 = "Rock6 Moving to position 1";
			newPosition6 = Rock6_position1.position;

		}else if(currentState6 == ""){

			currentState6 = "Rock6 Moving to position 2";
			newPosition6 = Rock6_position2.position;
		}

		//Rock 14

		if (currentState14 == "Rock14 Moving to position 1"){

			currentState14 = "Rock14 Moving to position 2";
			newPosition14 = Rock14_position2.position;

		}else if(currentState14 == "Rock14 Moving to position 2"){

			currentState14 = "Rock14 Moving to position 1";
			newPosition14 = Rock14_position1.position;

		}else if(currentState14 == ""){

			currentState14 = "Rock14 Moving to position 2";
			newPosition14 = Rock14_position2.position;
		}

		Invoke("ChangeTarget", resetTime);
	}	

}
