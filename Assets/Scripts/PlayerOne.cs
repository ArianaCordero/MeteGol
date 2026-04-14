using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public Rigidbody rb;
    public float velocidad = 8.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void FixedUpdate()
    {
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        if (Input.GetKey(KeyCode.D)) movimientoHorizontal = 1f;
        if (Input.GetKey(KeyCode.A)) movimientoHorizontal = -1f;
        if (Input.GetKey(KeyCode.W)) movimientoVertical = 1f;
        if (Input.GetKey(KeyCode.S)) movimientoVertical = -1f;

        Vector3 direccion = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        if (direccion.magnitude > 1)
            direccion = direccion.normalized;

        rb.linearVelocity = new Vector3(
            direccion.x * velocidad,
            rb.linearVelocity.y,
            direccion.z * velocidad
        );
    }
}