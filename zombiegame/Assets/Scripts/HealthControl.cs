using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthControl : MonoBehaviour {
	public float health;//MAx 100
	public Image healthBar;
	public GameObject restartDialog;
	// Use this for initialization
	void Start () {
		showRestart (false);
	}
	
	// Update is called once per frame
	void Update () {
		checkHealth ();
	}

	//Checks the players current health
	void checkHealth(){
		healthBar.rectTransform.localScale = new Vector3 (health /100,healthBar.rectTransform.localScale.y,healthBar.rectTransform.localScale.z);
		if (health <= 0.0f)
			showRestart (true);
	}

	//adds to health to player
	public void addHealth(float amount){
		if (health + amount > 100)
			health = 100f;
		else
			health += amount;
			
	}

	//subtracts health from player
	public void subtractHealth(float amount){
		if (health - amount < 0.0f)
			health = 0f;
		else
			health -= amount;
	}
		
	void OnCollisionEnter(Collision other){
		//Removes health on collision with zombie
		if(other.collider.CompareTag("Zombie"))
			subtractHealth(10f);

		if(other.collider.CompareTag("Health"))
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
