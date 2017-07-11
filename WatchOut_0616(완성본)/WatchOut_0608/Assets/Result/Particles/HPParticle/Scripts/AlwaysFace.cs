/*
this script is attached to ammo, and stores data to be used by the PickUpItemScript
*/

using UnityEngine;
using System.Collections;

public class AlwaysFace : MonoBehaviour {
	public float Speed;
	public GameObject Target;

	// turn towards target
	void Start()
	{
		Target = GameObject.FindGameObjectWithTag("MainCamera");

		if (Target == null)
		{
			return;
		}
		transform.LookAt(Target.transform);
	}

	// turn towards target
	void FixedUpdate()
	{
		if (Target == null)
		{
			return;
		}
		transform.LookAt(Target.transform);
	}
}
