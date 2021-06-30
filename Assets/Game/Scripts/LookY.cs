using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {

	[SerializeField]
	private float mouseSensitivity = 1.0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
		Vector3 newRotation = transform.localEulerAngles;
		newRotation.x -= mouseY; // Utilizar ' - ' para rotação não ser invertida
		transform.localEulerAngles = newRotation;
	}
}
