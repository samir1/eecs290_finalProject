using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;



public class RayShooter : MonoBehaviour {
	private Camera _camera;
	private GameObject _player;
//	private GameObject _bat;
	private AudioSource source;//Sound effect source
	public AudioClip shoot;//attaches audio component to player
	public Texture reticle;
	Vector3 originalPos;
	Quaternion originalRot;
	void Start() {
//		_bat = GameObject.Find("BaseballBat");
		_camera = GetComponent<Camera>();
		_player = GameObject.Find("Player");
		_player.layer = LayerMask.NameToLayer("Ignore Raycast");
//		originalPos = _bat.transform.localPosition;
//		originalRot = _bat.transform.localRotation;
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}

	void OnGUI() {
		int size = 30;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2-5;
		//GUI.Label(new Rect(posX, posY, size, size), "*");
		GUI.DrawTexture(new Rect(posX, posY, size, size), reticle);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space) && !EventSystem.current.IsPointerOverGameObject()) {
			source.PlayOneShot (shoot, 0.5f);// Plays sound effect from gun shot
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			ray.origin = new Vector3(_player.transform.position.x, _player.transform.position.y+1.3f, _player.transform.position.z);
			Debug.DrawRay (ray.origin, point, Color.green);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
					Messenger.Broadcast(GameEvent.ENEMY_HIT);
				} else {
					if (hitObject.tag != "UITrigger") {
//						StartCoroutine (SphereIndicator (hit.point));
					}
				}
			}
		}

//		if (Input.GetMouseButton (0))
//			batAnimation ();
//		else {
//			_bat.transform.localPosition = originalPos;
//			_bat.transform.localRotation = originalRot;
//		}
	}
		
//	private void batAnimation(){
//		_bat.transform.Translate (new Vector3(1f, -.3f, -.4f) * Time.deltaTime);
//		_bat.transform.Rotate (new Vector3(1f,.3f, .4f), 30 * Time.deltaTime);
//	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}

	void Awake(){
		source = GetComponent<AudioSource> ();
	}
}