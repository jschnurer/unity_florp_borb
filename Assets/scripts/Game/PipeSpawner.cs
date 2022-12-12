using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject PipesPrefab;
    public float PipeFrequency = 2f;
    public float HeightVariance = 4.5f;
    private float _pipeTimer = 0f;

    void Start() => SpawnPipe();

    void Update()
    {
        if (_pipeTimer >= PipeFrequency)
        {
            SpawnPipe();
            _pipeTimer = 0f;
        }
        else
        {
            _pipeTimer += Time.deltaTime;
        }
    }

    void SpawnPipe() =>
        Instantiate(PipesPrefab,
            GetNewPipePosition(),
            transform.rotation);

    Vector3 GetNewPipePosition() =>
        new Vector3(transform.position.x,
            GetRandomYPosition(),
            transform.position.x);

    float GetRandomYPosition() =>
        Random.Range(transform.position.y - HeightVariance,
            transform.position.y + HeightVariance);
}
