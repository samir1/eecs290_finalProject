using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	public float speed = 1f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, speed);


	}
}
