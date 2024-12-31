using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float radiousObject;

    void Start()
    {
        radiousObject = GetComponent<CircleCollider2D>().radius;
    }

    private void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        if (position.x - radiousObject > ScreenUtils.ScreenRight || position.x + radiousObject < ScreenUtils.ScreenLeft)
        {
            position.x *= -1;
        }
        if (position.y - radiousObject > ScreenUtils.ScreenTop || position.y + radiousObject < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        transform.position = position;
    }
}
