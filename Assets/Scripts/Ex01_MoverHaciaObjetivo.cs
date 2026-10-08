using UnityEngine;

public class Ex01_MoverHaciaObjetivo : MonoBehaviour
{
    public enum Modo { SoloStart, UpdateMitad, StartMitad, UpdateDoble }

    public Modo modo = Modo.SoloStart;
    public Vector3 goal = new Vector3(0f, 0f, 5f);

    void Start()
    {
        if (modo == Modo.SoloStart)
            this.transform.Translate(goal);       // se mueve una sola vez

        if (modo == Modo.StartMitad)
            goal = goal * 0.5f;                   // se reduce una sola vez
    }

    void Update()
    {
        switch (modo)
        {
            case Modo.UpdateMitad:
                this.transform.Translate(goal);
                goal = goal * 0.5f;               // saltos cada vez más pequeños
                break;

            case Modo.StartMitad:
                this.transform.Translate(goal);   // salto constante (la mitad)
                break;

            case Modo.UpdateDoble:
                this.transform.Translate(goal);
                goal = goal * 2.0f;               // saltos exponenciales
                break;
        }
    }
}