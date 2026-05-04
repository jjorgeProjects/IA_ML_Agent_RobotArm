using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float minRadius = 1.0f;
    [SerializeField] private float maxRadius = 3.5f;
    [SerializeField] private float minY = 0.5f;
    [SerializeField] private float maxY = 2.5f;

    public void RandomizeTarget()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float radius = Random.Range(minRadius, maxRadius);
        float y = Random.Range(minY, maxY);

        Vector3 pos = new Vector3(
            Mathf.Cos(angle) * radius,
            y,
            Mathf.Sin(angle) * radius
        );

        target.position = pos;
    }
}