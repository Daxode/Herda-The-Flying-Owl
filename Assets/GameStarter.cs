using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStarter : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        Cursor.lockState = CursorLockMode.Confined;
        if (Input.anyKeyDown) {
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}