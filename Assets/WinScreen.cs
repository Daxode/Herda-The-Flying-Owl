using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {
    float timerLeft = 2f;
    void Update() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (timerLeft > 0) {
            timerLeft -= Time.deltaTime;
        } else {
            if (Input.anyKeyDown) {
                StartCoroutine(LoadYourAsyncScene());
            }
        }
    }

    IEnumerator LoadYourAsyncScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StartScene");
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
