using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform target;

	public Vector3 offset;

	public float pitch = 15f, zoomSpeed = 2f, minZoom = 3f, maxZoom = 10f;

	private float currentZoom = 10f;

	void Update(){
		currentZoom -= Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp (currentZoom, minZoom, maxZoom);
	}

	void LateUpdate(){
		transform.position = target.position - offset * currentZoom;
		transform.LookAt (target.position + Vector3.up * pitch);
	}
}
