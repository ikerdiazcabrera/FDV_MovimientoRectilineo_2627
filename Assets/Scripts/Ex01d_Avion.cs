using UnityEngine;

public class Ex01d_Avion : MonoBehaviour
{
    public float speed = 10f;
    public float takeoffDelay = 3f;     // segundos en pista antes de despegar
    public float climbAngle = 20f;      // grados de morro hacia arriba
    public float pitchSmooth = 2f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= takeoffDelay)
        {
            // En Unity un giro negativo en X levanta el morro
            Quaternion up = Quaternion.Euler(-climbAngle, transform.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, up, pitchSmooth * Time.deltaTime);
        }

        // Avanza por su eje forward local: al estar inclinado, asciende
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}