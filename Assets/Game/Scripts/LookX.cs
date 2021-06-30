using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {

	[SerializeField]
	private float mouseSensitivity = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
		Vector3 newRotation = transform.localEulerAngles;
		newRotation.y += mouseX;
		transform.localEulerAngles = newRotation;
	}
}
