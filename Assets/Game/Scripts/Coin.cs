using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	[SerializeField]
	AudioClip pickupCoinClip;

	UIManager uiManager;

	private void Start() {
		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			if (Input.GetKeyDown(KeyCode.E)) {
				Player player = other.GetComponent<Player>();
				if (player != null) {
					AudioSource.PlayClipAtPoint(pickupCoinClip, transform.position);
					player.hasCoin = true;
					uiManager.showCoinImage();
					Destroy(this.gameObject);
				}
			}

		}
	}

}
