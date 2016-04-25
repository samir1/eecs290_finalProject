using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public Maze mazePrefab;

	private Maze mazeInstance;

	private void Start () {
		BeginGame();
	}

	private void Update () {
		
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

}
