using System;
using System.Collections.Generic;
using FinanceFantasy.Bank;
using TMPro;
using UnityEngine;

namespace FinanceFantasy.UI {
  public class BankOperationUpdate : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI TimerTextMesh;
    private Dictionary<BankOperation, TextMeshProUGUI> operationList = new();

    private void Update() {
      if (operationList.Count > 0) {
        foreach (var operation in operationList.Keys) {
          if (operationList.TryGetValue(operation, out var textmesh)) {
            textmesh.text = $"Tiempo restante para cobrar {operation.Name}: " +
                            $"{TimeUtils.GetFormatTime(operation.PaymentTime)}";
          }
        }
      }
    }

    private void OnEnable() {
      BankManager.SignUpWithBank += AddNewTimer;
    }

    private void OnDisable() {
      BankManager.SignUpWithBank -= AddNewTimer;
    }

    private void AddNewTimer(BankOperation op) {
      var instantiate = Instantiate(TimerTextMesh);
      instantiate.transform.SetParent(transform);
      if (instantiate.TryGetComponent<RectTransform>(out var component)) {
       component.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, component.rect.width);
       component.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, operationList.Count * 100, component.rect.height);
      }
      
      operationList.Add(op, instantiate);
    }
  }
}