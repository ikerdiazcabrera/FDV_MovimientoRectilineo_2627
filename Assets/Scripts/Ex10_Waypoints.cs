using System;
using System.Linq;
using UnityEngine;

public class Ex10_Waypoints : MonoBehaviour
{
    public float speed = 4f;
    public float rotSpeed = 4f;
    public float accuracy = 0.5f;

    Transform[] waypoints;
    int current = 0;

    void Start()
    {
        // FindGameObjectsWithTag no garantiza el orden, así que se ordena por nombre
        waypoints = GameObject.FindGameObjectsWithTag("waypoint")
            .OrderBy(g => g.name, StringComparer.Ordinal)
            .Select(g => g.transform)
            .ToArray();

        if (waypoints.Length == 0)
        {
            Debug.LogError("No hay objetos con la etiqueta 'waypoint'.");
            enabled = false;
        }
    }

    void Update()
    {
        Vector3 direction = waypoints[current].position - this.transform.position;

        if (direction.magnitude < accuracy)
        {
            current = (current + 1) % waypoints.Length;   // siguiente objetivo, el circuito es cerrado
            return;
        }

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        this.transform.rotation = Quaternion.Slerp(
            this.transform.rotation, lookRotation, rotSpeed * Time.deltaTime);

        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}