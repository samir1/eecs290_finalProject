using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerCharacter : MonoBehaviour {
	public float health;
	public Image healthBar;
	public GameObject restartDialog;

	void Start() {
		health = 100f;
		InvokeRepeating("decreaseHealthOverTime", 30f, 30f);
	}

	public void Hurt(int damage) {
		health -= damage;
		Debug.Log("Health: " + health);
	}

	public void Update() {
		Debug.Log(health);
		checkHealth();
	}

	public void decreaseHealthOverTime() {
		subtractHealth(10f);
	}

	//Checks the players current health
	void checkHealth(){
		healthBar.rectTransform.localScale = new Vector3 (health /100,healthBar.rectTransform.localScale.y,healthBar.rectTransform.localScale.z);
		if (health <= 0.0f)
			showRestart (true);
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
		if (hit.gameObject.CompareTag("Zombie")) // collision with zombie
			subtractHealth(10f);
		else if(hit.gameObject.CompareTag("HealthPack")) // collision with Health Pack
			addHealth(50f);
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
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);	
	}
		
}
