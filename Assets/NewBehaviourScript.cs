using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public float speed;
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (h*speed,rb.velocity.y,v*speed);

		rb.velocity = movement;
	}
}
