using UnityEngine;

public class Ex08_RotacionSuave : MonoBehaviour
{
    public Transform goal;
    public float speed = 3f;
    public float rotSpeed = 2f;
    public float accuracy = 0.05f;

    void Update()
    {
        Vector3 direction = goal.position - this.transform.position;

        if (direction.magnitude > accuracy)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            this.transform.rotation = Quaternion.Slerp(
                this.transform.rotation, lookRotation, rotSpeed * Time.deltaTime);

            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}