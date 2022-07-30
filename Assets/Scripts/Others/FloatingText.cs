using UnityEngine.UI;
using UnityEngine;

public class FloatingText 
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Shown()
    {
        active = true;
        lastShown = Time.time; //time.time es ahora mismo
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if (!active)
            return;
        // 10s (ahora mismo) - 7s (cuando empezo la animacion) > duracion 
        if (Time.time - lastShown > duration)
            Hide();

        // Esto es para mover el texto si no entiendo mal
        go.transform.position += motion * Time.deltaTime;
    }
}
