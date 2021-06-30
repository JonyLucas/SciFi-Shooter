using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

	[SerializeField]
	GameObject crackedCrate;

	public void destroyObject() {
		Instantiate(crackedCrate, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}

}
