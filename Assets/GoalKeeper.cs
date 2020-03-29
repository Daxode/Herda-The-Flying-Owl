using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalKeeper : MonoBehaviour {
    Dictionary<int, Pickable> pickers;

    // Start is called before the first frame update
    void Start() {
        pickers = new Dictionary<int, Pickable>();
    }

    IEnumerator LoadYourAsyncScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WinScene");
        while (!asyncLoad.isDone) {
            yield return null;
        }
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Pickable")) return;

        if (!pickers.ContainsKey(other.transform.GetInstanceID())) 
            pickers.Add(other.transform.GetInstanceID(), other.GetComponent<Pickable>());

        print(pickers.Count);
        if (FindObjectsOfType<Pickable>().Length <= pickers.Count) {
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    private void OnTriggerExit(Collider other) {
        pickers.Remove(other.GetInstanceID());
    }
}
