using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	public LayerMask movementMask;

	Camera camera;
	PlayerMotor motor;

	// Use this for initialization
	void Start () {
		camera = Camera.main;
		motor = GetComponent<PlayerMotor> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 1000, movementMask)) {
				motor.MoveToPoint (hit.point);
				//Stop Focusing Object
			}
		}
		if (Input.GetMouseButton (1)) {
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 1000)) {
				// Check if we hit an interactable
				//If so, set as focus
			}
		}
	}
}
