using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float mass;
	public float echarge;
	public float vx;
	public float vy;
	public float vz;
	Rigidbody rb;

	public static float elx (Vector3 t){
		return 0;
	}
	public static float ely (Vector3 t){
		return 1;
	}
	public static float elz (Vector3 t){
		return 0;
	}



	public static float mx (Vector3 t){
		return 0;
	}
	public static float my (Vector3 t){
		return 0;
	}
	public static float mz (Vector3 t){
		return 1;
	}




	void Start () {
		rb = GetComponent<Rigidbody> ();
		Vector3 vel = new Vector3 (vx,vy,vz);
		rb.velocity = vel;
	}


	void Update () {
		Vector3 vel = new Vector3 (0,0,0);
		float fx,fy,fz;
		float dt = 1/60f;
		fx = echarge*(elx(rb.position)+rb.velocity.y*mz(rb.position)-rb.velocity.z*my(rb.position));
		fy = echarge*(ely(rb.position)+rb.velocity.z*mx(rb.position)-rb.velocity.x*mz(rb.position));
		fz = echarge*(elz(rb.position)+rb.velocity.x*my(rb.position)-rb.velocity.y*mx(rb.position));
		vel.x=(fx/mass)*dt;
		vel.y=(fy/mass)*dt;
		vel.z=(fz/mass)*dt;
		rb.velocity =rb.velocity+ vel;
	}
}