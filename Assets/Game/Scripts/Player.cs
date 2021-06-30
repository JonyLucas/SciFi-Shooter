using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private GameObject 
		weapon,
		shotFX,
		hitMarker;

	private CharacterController controller;

	private float 
		speed = 3.5f,
		gravity = 9.81f;

	[SerializeField]
	private int 
		maxAmmo = 125, 
		currentAmmo;

	private bool isReloading = false;

	public bool hasCoin = false;

	private UIManager uiManager;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		currentAmmo = maxAmmo;

		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

	}
	
	// Update is called once per frame
	void Update () {
		Movement();
		if (Input.GetMouseButton(0) && weapon.active) {
			if(currentAmmo >= 0)
				shoot();
		}
		else {
			shotFX.SetActive(false);
		}

		if (Input.GetKeyDown(KeyCode.R) && isReloading == false) {
			StartCoroutine(reload());
		}

	}

	public void enableWeapon() {
		weapon.SetActive(true);
	}

	private void shoot() {
		Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hitInfo;

		shotFX.SetActive(true);
		uiManager.updateAmmoCount(currentAmmo--, maxAmmo);

		if (Physics.Raycast(rayOrigin, out hitInfo)) {
			Debug.Log("Hit: " + hitInfo.transform.name);

			// Instância o efeito de hitmark especificando a rotação como a normal da superfície atingida
			GameObject hitFX = Instantiate(hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
			Destroy(hitFX, 3.8f);

			Destructable destructableObject = hitInfo.transform.GetComponent<Destructable>();
			if (destructableObject != null) {
				destructableObject.destroyObject();
			}

		}
	}

	private IEnumerator reload() {
		isReloading = true;
		yield return new WaitForSeconds(1.5f);
		currentAmmo = maxAmmo;
		isReloading = false;
		uiManager.updateAmmoCount(currentAmmo, maxAmmo);
	}

	private void Movement() {
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
		moveDirection.y -= gravity;
		moveDirection = transform.TransformDirection(moveDirection);
		controller.Move(moveDirection);
	}
}
