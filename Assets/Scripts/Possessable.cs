using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possessable : MonoBehaviour {

	public PossessableType type;
	public static List<Possessable> allPossessables = new List<Possessable> ();

	void Awake(){
		allPossessables.Add (this);
	}

	void OnDestroy(){
		allPossessables.Remove (this);
	}

	public static Possessable GetPossessableInRange(Vector3 position, float maxRange){
		Possessable closest = null;
		float closestDist = float.MaxValue;

		foreach (Possessable p in allPossessables) {
			float dist = Vector3.Distance (position, p.transform.position);
			if (dist < closestDist && dist < maxRange) {
				closest = p;
				closestDist = dist;
			}
		}
		return closest;
	}


}

public enum PossessableType{
	Outlet,
	Outlet2,
	Vacuum,
	TV,
	Light,
	Car

}
