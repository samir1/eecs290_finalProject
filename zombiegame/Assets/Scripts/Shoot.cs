using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public float delayTime = 8;
	private AudioSource source;
	public AudioClip onShoot;//attaches audio component to player
	private float counter = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Mouse0) && counter > delayTime) {
			Instantiate (bullet, transform.position, transform.rotation);
			source.PlayOneShot (onShoot);
			counter = 0;
		}
		counter += 1 * Time.deltaTime;

	}
}