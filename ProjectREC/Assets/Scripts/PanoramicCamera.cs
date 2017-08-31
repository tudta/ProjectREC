using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanoramicCamera : MonoBehaviour {
    [SerializeField] private Vector3 camMinRot = Vector3.zero;
    [SerializeField] private Vector3 camMaxRot = Vector3.zero;
    [SerializeField] private float camRotSpeed = 0.0f;
    private Vector2 mouseClickPos = Vector2.zero;
    private Vector2 currentMousePos = Vector2.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
	}

    private void CheckInput() {
        if (Input.GetMouseButtonDown(0)) {
            mouseClickPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0)) {
            currentMousePos = Input.mousePosition;
            if (currentMousePos != mouseClickPos) {
                RotateCamera();
            }
        }
    }

    private void RotateCamera() {
        Vector3 rotVec = new Vector3(mouseClickPos.x, mouseClickPos.y, 0.0f) - new Vector3(currentMousePos.x, currentMousePos.y, 0.0f);
        rotVec *= camRotSpeed;
        transform.Rotate(Vector3.up, rotVec.x);
        //transform.Rotate(Vector3.right, -rotVec.y);
        mouseClickPos = currentMousePos;
    }
}
