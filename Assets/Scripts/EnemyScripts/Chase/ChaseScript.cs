using UnityEngine;

public class ChaseScript : BasicEnemy
{
    Vector3 mousePos;
    Rigidbody2D rb;
    Vector2 position;
    GameManager gm;


    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        _speed = Random.Range(0.01f, 0.05f);

        float _randomScale = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(_randomScale * 2, _randomScale, 1);

        PickColor(GetComponent<SpriteRenderer>());
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        position = Vector2.Lerp(transform.position, mousePos, _speed);
    }

    void FixedUpdate()
    {
        rb.MovePosition(position);
    }
    
    void OnMouseOver()
    {
        gm.GameEnd();
    }
}
