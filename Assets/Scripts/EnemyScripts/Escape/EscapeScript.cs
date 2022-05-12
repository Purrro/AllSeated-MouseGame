using UnityEngine;

public class EscapeScript : BasicEnemy
{
    Vector3 mousePos;
    Rigidbody2D rb;
    Vector2 position;
    GameManager gm;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        _speed = Random.Range(2f, 5f);
        float _randomScale = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(_randomScale, _randomScale, 1);

        PickColor(GetComponent<SpriteRenderer>());
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        position = Vector2.Lerp(transform.position, -mousePos, _speed);
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, mousePos) < 5)
            rb.AddForce(-mousePos * _speed, ForceMode2D.Force);
    }

    void OnMouseOver()
    {
        gm.AddScore();

        float rndXPos = Random.Range(-7, 7);
        float rndYPos = Random.Range(-4, 4);

        transform.position = new Vector2(rndXPos, rndYPos);
    }
}
