using System;
using FinanceFantasy.Player;
using TMPro;
using UnityEngine;

namespace FinanceFantasy.UI {
  public class PlayerMoneyListener : MonoBehaviour {

    private TextMeshProUGUI _textMesh;

    private void Awake() {
      _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() {
      PlayerMoney.PlayerMoneyChanged += ChangeText;
    }

    private void OnDisable() {
      PlayerMoney.PlayerMoneyChanged -= ChangeText;
    }

    private void ChangeText(float money) {
      _textMesh.text = $"Dinero actual: {money:c2}";
    }
  }
}
