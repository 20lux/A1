//using System.Numerics;
using UnityEngine;

public class SpawnedCube : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector2 xVelocityRange = new Vector2(-1, 1);
    [SerializeField] private float verticalVelocity = 10;
    [SerializeField] private Vector2 zVelocityRange = new Vector2(-1, 1);

    [SerializeField] private float lifetime = 10;

    private static CubeSpawner cubeSpawner;

	private void Start()
	{
		cubeSpawner = GameObject.Find("Cube Spawner").GetComponent<CubeSpawner>();

		cubeSpawner.spawnedCubes++;

		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (GameObject.Find("Cube Spawner").GetComponent<CubeSpawner>().spawnedCubes > 10000)
		{
			Destroy(gameObject, lifetime);
		}
	}

	public void SetRandomVelocity()
    {
		rb = GetComponent<Rigidbody>();

		rb.velocity = new Vector3(
			Random.Range(xVelocityRange.x, xVelocityRange.y),
			verticalVelocity, 
			Random.Range(zVelocityRange.x, zVelocityRange.y));

        rb.angularVelocity = new Vector3(
			Random.Range(-10, 10), 
			Random.Range(-10, 10), 
			Random.Range(-10, 10));
    }
}
