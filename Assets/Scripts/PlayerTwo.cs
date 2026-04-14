using UnityEngine;

public class PlayerTwo : MonoBehaviour
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

        if (Input.GetKey(KeyCode.L)) movimientoHorizontal = 1f;
        if (Input.GetKey(KeyCode.J)) movimientoHorizontal = -1f;
        if (Input.GetKey(KeyCode.I)) movimientoVertical = 1f;
        if (Input.GetKey(KeyCode.K)) movimientoVertical = -1f;

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