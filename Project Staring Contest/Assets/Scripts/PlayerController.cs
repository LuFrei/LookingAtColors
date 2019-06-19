using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform camera;
	public float lookSensitivity;
	public float moveSpeed;

	private void FixedUpdate(){
		Move(GetMoveInput());
		Look(GetMouseInput());
	}

	Vector3 GetMoveInput() {
		float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

		return new Vector3(horizontal, 0, vertical);
	}

	Vector2 GetMouseInput(){
		float horizontal = Input.GetAxis("Mouse X");
		float vertical = Input.GetAxis("Mouse Y");

		return new Vector2(vertical, horizontal);		//These are flipped because we are rotating the Y axis on x movement and vice versa
	}

	void Move(Vector3 moveVector) {
		transform.Translate(moveVector);
	}

	void Look(Vector3 lookVector){
		camera.Rotate(Vector2.left * lookVector.x * lookSensitivity);		//rotate camera up and down
		transform.Rotate(Vector2.up * lookVector.y * lookSensitivity);  //roate body left and right

		//Camera x rot Limits
		Mathf.Clamp(camera.rotation.x, -90, 90);
		
	}
}
