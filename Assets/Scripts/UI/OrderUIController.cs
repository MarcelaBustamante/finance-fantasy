using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FinanceFantasy.UI {
  
  [Serializable]
  public class Order {
    public int id;
    public Sprite orderImage;
    public string orderName;
    public int amount;
    public float cost;
  }
  
  public class OrderUIController : MonoBehaviour {

    [Header("UI Elements")] [SerializeField]
    private GameObject backgroundPanel;

    [SerializeField] private RectTransform orderPanel;
    [SerializeField] private Transform orderPrefab;

    [Header("Orders settings")] [SerializeField]
    private Order[] orders;

    private void Awake() {
      backgroundPanel.SetActive(true);
      FillOrders();
    }

    public void ClickOnOrder(Order order) {
      print("Request an order.");
      if (GameManager.instance != null) {
        if (GameManager.instance.TryCompleteOrder(order)) {
          print($"Orden completada de {order.orderName} con ${order.cost} y un total de {order.amount} unidades");
          // Cerramos el pop up? Mensaje? Borramos el encargo?
          return;
        }
        
        print($"Orden NO completada de {order.orderName}");
        // Si no puede comprar... que hacemos? 
      }
    }

    private void FillOrders() {
      const int firstYPosition = -50;
      const int buttonTopMargin = -100;
      var index = 0;
      foreach (var order in orders) {
        var instantiateUI = Instantiate(orderPrefab);
        var orderTitles = instantiateUI.GetComponentsInChildren<TextMeshProUGUI>();
        var orderImage = instantiateUI.Find("ImagenPedido").GetComponent<Image>();
        
        foreach (var title in orderTitles) {
          if (title.name == "NombreEncargo") {
            title.text = order.orderName;
          } else {
            title.name = $"${order.cost}";
          }
        }

        if (orderImage != null) {
          orderImage.sprite = order.orderImage;
        }
        
        SetRectTransformCorrectly(instantiateUI.GetComponent<RectTransform>());
        SetButtonOnClick(instantiateUI.gameObject, order);
        index++;
        
        void SetRectTransformCorrectly(RectTransform rectTransform) {
          if (rectTransform == null) {
            print($"Something went wrong at {gameObject.name}, rectTransform wasn't found");
            return;
          }
          
          rectTransform.SetParent(orderPanel.transform);
          rectTransform.anchorMin = new Vector2(0, 1);
          rectTransform.anchorMax = new Vector2(1, 1);
          rectTransform.pivot = new Vector2(0.5f, 0.5f);
          rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, orderPanel.rect.width);
          rectTransform.localScale = new Vector3(1, 1, 1);
          rectTransform.anchoredPosition = new Vector2(0, firstYPosition + (buttonTopMargin * index));  
        }

        void SetButtonOnClick(GameObject go, Order order) {
          if (go.TryGetComponent<Button>(out var button)) {
            button.onClick.AddListener(delegate {
              ClickOnOrder(order);
            });
          }
        }
      }
    }
  }
}