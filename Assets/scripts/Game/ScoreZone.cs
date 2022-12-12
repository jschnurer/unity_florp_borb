using System;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public static event Action<int> OnScoreZoneEntered;
    public int ScoreValue = 1;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnScoreZoneEntered?.Invoke(ScoreValue);
        }
    }
}
