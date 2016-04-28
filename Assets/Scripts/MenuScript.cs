using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Button startButton;
	public Button exitButton;
	public Button levelButton;


	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		quitMenu.enabled = false;
		levelButton = levelButton.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ExitPress(){
		quitMenu.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
	}

	public void NoPress(){
		quitMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
	}


	public void StartLevel(){
		SceneManager.LoadScene ("StoryDialogue");
	}

	public void ExitGame(){
		Application.Quit();
	}

	public void AdvanceScene(){
		SceneManager.LoadScene ("SceneZombie");
	}
}
