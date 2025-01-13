using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 3;
    [SerializeField] GameObject rocket;

    float torque;
    float force;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(rocket, transform.position + Vector3.up, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector2.up * torque);
    }
}