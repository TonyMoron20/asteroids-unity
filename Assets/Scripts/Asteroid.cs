using UnityEngine;

public class Asteroid : MonoBehaviour
{
    const float MinImpulseForce = 3f;
    const float MaxImpulseForce = 5f;
    
    [SerializeField]
    Sprite graySprite;

    [SerializeField]
    Sprite redSprite;

    [SerializeField]
    Sprite brownSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int numSprite = Random.Range(0, 3);

        if (numSprite == 0)
        {
            spriteRenderer.sprite = graySprite;
        }
        else if (numSprite == 1)
        {
            spriteRenderer.sprite = redSprite;
        }
        else 
        {
            spriteRenderer.sprite = brownSprite;
        }
    }
}
