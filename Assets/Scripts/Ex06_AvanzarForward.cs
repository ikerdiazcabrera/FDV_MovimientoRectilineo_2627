using UnityEngine;

public class Ex06_AvanzarForward : MonoBehaviour
{
    public Transform goal;
    public float speed = 3f;

    void Update()
    {
        this.transform.LookAt(goal.position);

        // Por defecto Translate usa Space.Self: avanza por el forward local
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}