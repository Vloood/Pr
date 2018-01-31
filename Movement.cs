using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float mass;
	public float echarge;
	public float vx;
	public float vy;
	public float vz;
	public Vector3 perv = new Vector3 (0, 0, 0);
	public Vector3 vperv = new Vector3 (0, 0, 0);
	Vector3 vtor = new Vector3 (0, 0, 0);
	Vector3 vvtor = new Vector3 (0, 0, 0);
	public float q2;
	Rigidbody rb;

	public static Vector3 vzaim (Vector3 r1,Vector3 r2,Vector3 v1,Vector3 v2,float qu1,float qu2){
		Vector3 x = new Vector3 (0, 0, 0);
		x = r1 - r2;
		float y=Mathf.Sqrt(x.x*x.x+x.y*x.y+x.z*x.z);
		x *= qu1 * qu2 / (y * y * y);
		return x;
	}
	public static float abcx (Vector3 r1,Vector3 r2,Vector3 v1,Vector3 v2,float qu1,float qu2){
		return 0;
	}
	public static float abcy (Vector3 r1,Vector3 r2,Vector3 v1,Vector3 v2,float qu1,float qu2){
		return 0;
	}
	public static float abcz (Vector3 r1,Vector3 r2,Vector3 v1,Vector3 v2,float qu1,float qu2){
		return 0;
	}


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
		Vector3 speed = new Vector3 (vx,vy,vz);
		perv = rb.position;
		vperv = rb.velocity;
		vtor = GameObject.Find ("Sphere (1)").GetComponent<abc> ().vtor;
		vvtor = GameObject.Find ("Sphere (1)").GetComponent<abc> ().vvtor;
		q2 = GameObject.Find ("Sphere (1)").GetComponent<abc> ().echarge;
		rb.velocity = speed;
	}

	public Vector3 vel = new Vector3 (0,0,0);
	void Update () {
		float fx,fy,fz;
		float dt = 1/60f;
		perv = rb.position;
		vperv = rb.velocity;
		vtor = GameObject.Find ("Sphere (1)").GetComponent<abc> ().vtor;
		vvtor = GameObject.Find ("Sphere (1)").GetComponent<abc> ().vvtor;

		fx = echarge*(elx(rb.position)+rb.velocity.y*mz(rb.position)-rb.velocity.z*my(rb.position))+abcx(rb.position,perv,rb.velocity,vperv,echarge,q2);
		fy = echarge*(ely(rb.position)+rb.velocity.z*mx(rb.position)-rb.velocity.x*mz(rb.position))+abcy(rb.position,perv,rb.velocity,vperv,echarge,q2);
		fz = echarge*(elz(rb.position)+rb.velocity.x*my(rb.position)-rb.velocity.y*mx(rb.position))+abcz(rb.position,perv,rb.velocity,vperv,echarge,q2);
		vel.x=(fx/mass)*dt;
		vel.y=(fy/mass)*dt;
		vel.z=(fz/mass)*dt;
		rb.velocity = rb.velocity + vel;
	}
}