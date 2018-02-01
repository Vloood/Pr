using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abc : MonoBehaviour {
	public float mass;
	public float echarge;
	public float vx;
	public float vy;
	public float vz;
	Vector3 perv = new Vector3 (0, 0, 0);
	Vector3 vperv = new Vector3 (0, 0, 0);
	public Vector3 vtor = new Vector3 (0, 0, 0);
	public Vector3 vvtor = new Vector3 (0, 0, 0);
	public float q1;
	Rigidbody rb;

	public static Vector3 vzaim (Vector3 r1,Vector3 r2,Vector3 v1,Vector3 v2,float qu1,float qu2){
		Vector3 x = new Vector3 (0, 0, 0);
		x = r1 - r2;
		float y=Mathf.Sqrt(x.x*x.x+x.y*x.y+x.z*x.z);
		x *= qu1 * qu2 / (y * y * y);
		return x;
	}
		

	public static float elx (Vector3 t){
		return 0;
	}
	public static float ely (Vector3 t){
		return 0;
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
		return 0;
	}




	void Start () {
		rb = GetComponent<Rigidbody> ();
		Vector3 speed = new Vector3 (vx,vy,vz);
		perv = GameObject.Find ("Sphere").GetComponent<Movement> ().perv;
		vperv = GameObject.Find ("Sphere").GetComponent<Movement> ().vperv;
		q1 = GameObject.Find ("Sphere").GetComponent<Movement> ().echarge;
		vtor = rb.position;
		vvtor = rb.velocity;
		rb.velocity = speed;
	}

	public Vector3 vel = new Vector3 (0,0,0);
	void Update () {
		float fx,fy,fz;
		float dt = 1/60f;
		perv = GameObject.Find ("Sphere").GetComponent<Movement> ().perv;
		vperv = GameObject.Find ("Sphere").GetComponent<Movement> ().vperv;
		vtor = rb.position;
		vvtor = rb.velocity;
		Vector3 abc = new Vector3 ();
		abc = vzaim (rb.position, perv, rb.velocity, vperv, echarge, q1);
		fx = echarge*(elx(rb.position)+rb.velocity.y*mz(rb.position)-rb.velocity.z*my(rb.position))+abc.x;
		fy = echarge*(ely(rb.position)+rb.velocity.z*mx(rb.position)-rb.velocity.x*mz(rb.position))+abc.y;
		fz = echarge*(elz(rb.position)+rb.velocity.x*my(rb.position)-rb.velocity.y*mx(rb.position))+abc.z;
		vel.x=(fx/mass)*dt;
		vel.y=(fy/mass)*dt;
		vel.z=(fz/mass)*dt;
		rb.velocity = rb.velocity + vel;
	}
}