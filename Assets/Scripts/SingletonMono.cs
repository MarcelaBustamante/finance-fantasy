using System;
using UnityEngine;

namespace FinanceFantasy {
  public class MonoSingleton : MonoBehaviour {
    public static MonoSingleton Instance { get; private set; }

    protected virtual void Awake() {
      if (Instance != null) {
        Debug.Log($"I found multiple instances of {gameObject.name}, please consider delete one.");
        Destroy(this);
        return;
      }

      Instance = this;
      DontDestroyOnLoad(this);
    }
  }
}