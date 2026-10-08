using UnityEngine;

public class Ex05_SeguirCubo : MonoBehaviour
{
    public Transform goal;
    public float speed = 2f;
    public float speedStep = 1f;    // incremento por cada pulsación de espacio
    public float maxSpeed = 15f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            speed = Mathf.Min(speed + speedStep, maxSpeed);

        Vector3 direction = goal.position - this.transform.position;

        this.transform.LookAt(goal.position);
        this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}