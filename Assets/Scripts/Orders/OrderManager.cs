using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OrderManager : MonoBehaviour {
    private bool _isSceneLoaded = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        print("Collision");
        if (!_isSceneLoaded) {
            print("Loading scene");
            SceneManager.LoadScene("CompraProductos", LoadSceneMode.Additive);
            _isSceneLoaded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        print("Unloading scene");
        _isSceneLoaded = false;
        SceneManager.UnloadSceneAsync("CompraProductos");
    }
}
