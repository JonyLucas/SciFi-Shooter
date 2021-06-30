using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {

	private UIManager uiManager;

	private void Start() {
		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			Player player = other.GetComponent<Player>();
			if (player != null) {
				if (Input.GetKeyDown(KeyCode.E)) {
					if (player.hasCoin) {
						player.hasCoin = false;
						uiManager.hideCoinImage();
						GetComponent<AudioSource>().Play();
						player.enableWeapon();
					}
					else {
						Debug.Log("You don't have a coin");
					}
					
				}
			}
		}
	}

}
