using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {


	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;
	private bool first_round = true;
	public Maze mazePrefab;
	private Maze mazeInstance;

	void Start() {
		BeginGame();
		InvokeRepeating("spawnEnemiesNearPlayer", 30f, 30f);

	
	}

	void Update() {
		
		if (_enemy == null && first_round) {
			first_round = false;

			for (int i = -5; i < 5; i++) {
				spawnZombieAtPosition (287.1f + i * 2, 1.5f, 870);
			}
		} else if (GameObject.FindGameObjectsWithTag("Zombie").Length <= 2 && !first_round) { // spawn enemies if none on the map
			spawnEnemiesNearPlayer();
		} else if (!nearByZombiesExist() && !first_round) { // spawn enemies if there are none near to the character
			spawnEnemiesNearPlayer();
		}

	}

	private bool nearByZombiesExist(){
		int closeByZmb = 0;
		Vector3 playerPos = GameObject.Find("Player").transform.position;
		GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
		foreach (GameObject zmb in zombies) {
			float distanceSqr = (zmb.transform.position - playerPos).sqrMagnitude;
			Debug.Log(distanceSqr);
			if (distanceSqr < 400)
				closeByZmb++;
		}
		return closeByZmb >= 3;
	}

	private void BeginGame () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		StartCoroutine(mazeInstance.Generate());
	}

	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}

	void spawnZombieAtPosition(float x, float y, float z) {
		_enemy = Instantiate (enemyPrefab) as GameObject;
		_enemy.transform.position = new Vector3 (x, y, z);
		_enemy.tag = "Zombie";
		float angle = Random.Range (0, 360);
		_enemy.transform.Rotate (0, angle, 0);
		_enemy.GetComponent<WanderingAI> ().SetAlive (true);
	}

	void spawnEnemiesNearPlayer() {
		GameObject playerObject = GameObject.Find("Player");
		Vector3 playerPos = playerObject.transform.position;
		PlayerCharacter playerScript = playerObject.GetComponent<PlayerCharacter>();
//		float health = playerScript.getHealth();
		spawnZombieAtPosition (playerPos.x + 10f, 1.5f, playerPos.z);
		spawnZombieAtPosition (playerPos.x - 10f, 1.5f, playerPos.z);
		spawnZombieAtPosition (playerPos.x, 1.5f, playerPos.z + 10f);
		spawnZombieAtPosition (playerPos.x, 1.5f, playerPos.z - 10f);
	}
}
