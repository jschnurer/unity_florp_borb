using System;
using UnityEngine;

public class Borb : MonoBehaviour
{
    public static event Action OnPlayerDied;
    public Rigidbody2D RigidBody;
    public float FlapVelocity = 10f;
    private RandomAudioPlayer _flapSounds;
    private RandomAudioPlayer _deathSounds;
    private float _screenBottom = 0f;
    private float _screenTop = 0f;

    public bool IsDead { get; private set; } = false;

    void Start()
    {
        _screenBottom = Camera.main.ScreenToWorldPoint(Vector2.zero).y;
        _screenTop = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight)).y;
        RigidBody.velocity = Vector2.up * FlapVelocity;

        _flapSounds = gameObject.transform.GetChild(0).GetComponent<RandomAudioPlayer>();
        _deathSounds = gameObject.transform.GetChild(1).GetComponent<RandomAudioPlayer>();
    }

    void Update()
    {
        if (transform.position.y >= _screenTop)
        {
            transform.position = new Vector2(transform.position.x, _screenTop);
        }

        if (transform.position.y <= _screenBottom
            && !IsDead)
        {
            Die();
        }

        if (IsFlapPressed()
            && !IsDead)
        {
            RigidBody.velocity = Vector2.up * FlapVelocity;
            _flapSounds.PlayRandomSound();
        }
    }

    private bool IsFlapPressed()
    {
        return Input.GetKeyDown(KeyCode.Space)
            || Input.GetMouseButtonDown(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death")
            && !IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        _deathSounds.PlayRandomSound();
        IsDead = true;
        OnPlayerDied?.Invoke();
    }
}
