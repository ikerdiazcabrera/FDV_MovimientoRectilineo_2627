using UnityEngine;

public class Ex07_ControlJitter : MonoBehaviour
{
    public enum Metodo { Magnitud, Distancia, MoveTowards }

    public Metodo metodo = Metodo.Magnitud;
    public Transform goal;
    public float speed = 3f;
    public float accuracy = 0.01f;

    void Update()
    {
        Vector3 direction = goal.position - this.transform.position;

        switch (metodo)
        {
            case Metodo.Magnitud:
                if (direction.magnitude > accuracy)
                {
                    this.transform.LookAt(goal.position);
                    this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                break;

            case Metodo.Distancia:
                if (Vector3.Distance(this.transform.position, goal.position) > accuracy)
                {
                    this.transform.LookAt(goal.position);
                    this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                break;

            case Metodo.MoveTowards:
                if (direction.magnitude > accuracy)
                    this.transform.LookAt(goal.position);

                // Nunca se pasa: si el paso es mayor que lo que falta, se queda en el destino
                this.transform.position = Vector3.MoveTowards(
                    this.transform.position, goal.position, speed * Time.deltaTime);
                break;
        }
    }
}