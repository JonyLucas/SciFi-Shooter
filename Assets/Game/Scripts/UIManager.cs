using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]
	Text ammoText;

	[SerializeField]
	Image coinImage;

	private Player player;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		coinImage.enabled = false;
	}

	public void showCoinImage() {
		coinImage.enabled = true;
	}

	public void hideCoinImage() {
		coinImage.enabled = false;
	}

	public void updateAmmoCount(int ammoCount, int maxAmmo) {
		ammoText.text = ammoCount + "/" + maxAmmo;
	}

}
