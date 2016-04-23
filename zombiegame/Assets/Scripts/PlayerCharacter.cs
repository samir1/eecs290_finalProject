using UnityEngine;
using System.Collections;
using System;

public class PlayerCharacter : MonoBehaviour {
	private int _health;

	void Start() {
		_health = 100;
	}

	public void Hurt(int damage) {
		_health -= damage;
		Debug.Log("Health: " + _health);
	}

	public void Update() {
		Debug.Log (Time.time);
	}
		
}
