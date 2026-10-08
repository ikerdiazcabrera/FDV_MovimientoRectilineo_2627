using UnityEngine;

public class Ex02_DireccionNormalizada : MonoBehaviour
{
    public enum Paso { Normalizado, ConVelocidad, ConDeltaTime }

    public Paso paso = Paso.Normalizado;
    public Vector3 goal = new Vector3(0f, 0f, 5f);
    public float speed = 0.1f;   // en ConDeltaTime son unidades/segundo: sube a 3 o más

    void Update()
    {
        switch (paso)
        {
            case Paso.Normalizado:
                this.transform.Translate(goal.normalized);                       // 1 unidad por frame
                break;
            case Paso.ConVelocidad:
                this.transform.Translate(goal.normalized * speed);               // depende del framerate
                break;
            case Paso.ConDeltaTime:
                this.transform.Translate(goal.normalized * speed * Time.deltaTime); // unidades/segundo
                break;
        }
    }
}