using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    
    public float _speed;

    void Awake()
    {
        _speed = Random.Range(1f, 5f);
    }

    public void PickColor(SpriteRenderer sr)
    {
        sr.color = ColorPicker();
    }

    Color ColorPicker()
    {
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        return newColor;
    }
}
