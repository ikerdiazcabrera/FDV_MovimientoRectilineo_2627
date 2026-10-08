using UnityEngine;

public class Ex05_CuboTeclado : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(-v, 0f, h);
        this.transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}