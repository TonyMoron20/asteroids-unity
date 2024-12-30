using UnityEngine;

public class Ship : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 4.0f;

    float radiousShip;

    const float RotateDegreesPerSecond = 180.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        radiousShip = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        float rotate = Input.GetAxis("Rotate");

        // calculate rotation amount and apply rotation
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;

        if (rotate != 0)
        {
            if (rotate < 0)
            {
                rotationAmount *= -1;
            }

            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to math shipmrotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") != 0)
        {
            rb.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }

    private void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        if (position.x - radiousShip > ScreenUtils.ScreenRight || position.x + radiousShip < ScreenUtils.ScreenLeft)
        {
            position.x *= -1;
        }
        if (position.y - radiousShip > ScreenUtils.ScreenTop || position.y + radiousShip < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        transform.position = position;
    }
}
