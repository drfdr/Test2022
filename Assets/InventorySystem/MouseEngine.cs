using UnityEngine;

public class MouseEngine : MonoBehaviour{

    public float MouseSens;
    float x;
    float y;

    private void Start() {
    }

    void Update() {

            x += MouseSens * Input.GetAxis("Mouse X");
            y = MouseSens * Input.GetAxis("Mouse Y");

        var v3 = Camera.main.transform.localEulerAngles;

            Camera.main.transform.localEulerAngles = new Vector3(v3.x-y,v3.y, v3.z);
            transform.localEulerAngles = new Vector3(0, x, 0);
       }
    }
