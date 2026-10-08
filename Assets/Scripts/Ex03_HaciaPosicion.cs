using UnityEngine;

public class Ex03_HaciaPosicion : MonoBehaviour
{
    public Transform goal;
    public float speed = 1.0f;

    void Start()
    {
        // Gira primero hacia el objetivo y luego se mueve
        this.transform.LookAt(goal.position);
    }

    void Update()
    {
        Vector3 direction = goal.position - this.transform.position;

        // Space.World porque direction está en coordenadas de mundo y el personaje está rotado
        this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}