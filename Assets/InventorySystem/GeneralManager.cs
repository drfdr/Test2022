using UnityEngine;

public class GeneralManager : MonoBehaviour{

    private bool bGamePause;
    [SerializeField] private Behaviour[] GamePauseBehaviours;


    private void Start() {
        vGameResume();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            bGamePause = !bGamePause;
            if (bGamePause) {
                vGamePause();
            } else {
                vGameResume();
            }
        }
    }


    public void vGamePause() {
        bGamePause = true;
        foreach (Behaviour b in GamePauseBehaviours) {
            b.enabled = false;
        }
        vMouseShow();
    }

    public void vGameResume() {
        bGamePause = false;
        foreach (Behaviour b in GamePauseBehaviours) {
            b.enabled = true;
        }
        vMouseHide();
    }

    public void vMouseHide() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void vMouseShow() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
