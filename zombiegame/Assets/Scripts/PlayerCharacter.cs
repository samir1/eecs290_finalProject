using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerCharacter : MonoBehaviour {
	private float health;
	public Image healthBar;
	public GameObject restartDialog;
	GUIStyle text = new GUIStyle();//Style for HP
	private AudioSource source;//Sound effect source
	public AudioClip onHit;//attaches audio component to player
	private float volL = .5f;//Lower bound for sounds
	private float volH = 1f;//Higher bound for sounds
	private bool playerHit = false; //If player is hit


	void Start() {
		health = 100f;
		InvokeRepeating("decreaseHealthOverTime", 30f, 30f);
		text.fontSize = 20;
		text.normal.textColor = Color.white;
	}

	public void Hurt(int damage) {
		health -= damage;
		Debug.Log("Health: " + health);
	}

	public void Update() {
		updateHealthBar();
	}

	public void decreaseHealthOverTime() {
		subtractHealth(10f);
	}

	public float getHealth() {
		return health;
	}

	//Checks the players current health
	public void updateHealthBar(){
		healthBar.rectTransform.localScale = new Vector3 (health /100,healthBar.rectTransform.localScale.y,healthBar.rectTransform.localScale.z);
		if (health <= 0.0f) {
//			SceneManager.UnloadScene("SceneZombie");	
			SceneManager.LoadScene("SceneZombie");	
		}
//			showRestart (true);
	}

	//adds to health to player
	public void addHealth(float amount){
		if (health + amount > 100f)
			health = 100f;
		else
			health += amount;

	}

	//subtracts health from player
	public void subtractHealth(float amount){
		if (health - amount < 0.0f)
			health = 0;
		else
			health -= amount;
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		//Volume Range for sound effect
		float vol = UnityEngine.Random.Range (volL, volH);

		//Collide if player has not been hit 
		if (playerHit == false) {
			if (hit.gameObject.CompareTag ("Zombie")) { // collision with zombie
				source.PlayOneShot (onHit, vol);// Plays sound affect every collision with zombie
				subtractHealth (10f);
				playerHit = true;//Player has been injured recently
				StartCoroutine(onHitWait(1.5f));
			}
		}
		else if (hit.gameObject.CompareTag("HealthPack")) { // collision with Health Pack
			DestroyObject (hit.gameObject);
			addHealth (50f);
		}

		else if (hit.gameObject.CompareTag("SafeHouse")) { // collision with SafeHouse
			Debug.Log("Game Over");
			SceneManager.LoadScene ("END SCENE");
		}
	}

	//Limits the amount a player can get hurt per second
	IEnumerator onHitWait(float waitTime){
		yield return new WaitForSeconds (waitTime);
		playerHit = false;
	}

	//Displays Restart Screen prompt
	public void showRestart(bool display){
		if (display == true)
			Time.timeScale = 0.0f; //Pauses game
		else
			Time.timeScale = 1.0f;
		restartDialog.SetActive (display);
	}

	//Restarts level
	public void Restart(){
		SceneManager.LoadScene ("SceneZombie");	
	}

	//Updates numerical text on GUI
	void OnGUI(){
		GUI.Label (new Rect (60,20,100,20), "HP: " + health, text);
	}
		
	void Awake(){
		source = GetComponent<AudioSource> ();
	}
		
}
