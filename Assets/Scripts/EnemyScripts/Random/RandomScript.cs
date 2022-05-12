using UnityEngine;

public class RandomScript : BasicEnemy
{
    private int _randomDirection;
    private Vector2 DirectionVector;

    GameManager gm;


    void Awake()
    {
        gm = FindObjectOfType<GameManager>();

        _randomDirection = Random.Range(1, 5);
        _speed = Random.Range(3f, 7f);

        float _randomScale = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(_randomScale, _randomScale, 1);
    }

    void Start()
    {
        PickColor(GetComponent<SpriteRenderer>());
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (_randomDirection == 1)
            transform.position += (new Vector3(1, 0)) * _speed * Time.deltaTime; // Go Right
        if (_randomDirection == 2)
            transform.position += (new Vector3(-1, 0)) * _speed * Time.deltaTime; // Go Left
        if (_randomDirection == 3)
            transform.position += (new Vector3(0, 1)) * _speed * Time.deltaTime; // Go Up
        if (_randomDirection == 4)
            transform.position += (new Vector3(0, -1)) * _speed * Time.deltaTime; // Go Down

    }

    void OnCollisionEnter2D(Collision2D Collider)
    {
        if (Collider.gameObject.name == "BackgroundFrame")
        {
            _randomDirection = RandomNumberGenerator(_randomDirection);
        }
    }

    int RandomNumberGenerator(int _currentNum)
    {
        int _newNumber = Random.Range(1, 5);

        if (CheckIfNewDirectionIsGood(_newNumber))
            return _newNumber;

        else return RandomNumberGenerator(_currentNum);
    }

    bool CheckIfNewDirectionIsGood(int _newPossibleDirection)
    {
        if (
            (transform.position.x < -7 && transform.position.y > 0 && (_newPossibleDirection != 3 && _newPossibleDirection != 2)) ||     // Top Left Corner
            (transform.position.x < -7 && transform.position.y < 0 && (_newPossibleDirection != 4 && _newPossibleDirection != 2)) ||     // Bottom Left Corner;
            (transform.position.x > 7 && transform.position.y > 0 && (_newPossibleDirection != 3 && _newPossibleDirection != 1)) ||      // Top Right Corner
            (transform.position.x > 7 && transform.position.y < 0 && (_newPossibleDirection != 4 && _newPossibleDirection != 1)) ||      // Bottom Right Corner
            ((transform.position.x < 7 && transform.position.x > -7) && transform.position.y > 0 && (_newPossibleDirection != 3)) ||     // Middle Top
            ((transform.position.x < 7 && transform.position.x > -7) && transform.position.y < 0 && (_newPossibleDirection != 4)) ||     // Middle Bot
            ((transform.position.y > -4 && transform.position.y < 4) && transform.position.x > 7 && (_newPossibleDirection != 1)) ||     // Middle Right
            ((transform.position.y > -4 && transform.position.y < 4) && transform.position.x < 7 && (_newPossibleDirection != 2))        // Middle Left
        ) return true;
        else return false;
    }

    void OnMouseOver()
    {
        gm.GameEnd();
    }
}
