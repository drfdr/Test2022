using UnityEngine;
using UnityEngine.UI;

public class ESystem : MonoBehaviour{

    private RaycastHit rHit;
    private GlobalLinks GL;
    private Transform HandUI;

    private void Start() {
        GL = GlobalLinks.global;
        HandUI = GL.HandUI;
    }
    private void Update() {

        if (Input.GetKeyDown(KeyCode.E)) {
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out rHit, 10)) {
                if (rHit.transform.name.Contains("floatItem")) {
                    vCreate();
                }
              }
           }
        }

    private void vCreate() {

        var ISO = rHit.transform.GetComponent<FloatItem>().ISO;
        var EmptyGO = HandUI.Find("Empty");
        if (EmptyGO == null) {
            Debug.Log("Not Enough Space");
        } else {
            Debug.Log("Grabbing: " + ISO.name);
            EmptyGO.GetComponent<ItemUI>().vRefreshISO(ISO);
        }
       
    }
 }
