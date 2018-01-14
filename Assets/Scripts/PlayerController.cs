using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	public Interactable focus;

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
				RemoveFocus ();
			}
		}
		if (Input.GetMouseButton (1)) {
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 1000)) {
				Interactable interactable = hit.collider.GetComponent<Interactable> ();
				if (interactable != null) {
					SetFocus (interactable);
				}
			}
		}
	}

	void SetFocus (Interactable newFocus){
		if (newFocus != focus) {
			if (focus != null) {
				focus.OnDefocused ();
			}
			focus = newFocus;
			motor.FollowTarget (newFocus);
		}

		newFocus.OnFocused (transform);

	}

	void RemoveFocus(){
		if (focus != null) {
			focus.OnDefocused ();
		}
		focus = null;
		motor.StopFollowingTarget ();
	}

}
