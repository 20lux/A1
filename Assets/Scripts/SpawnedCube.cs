using UnityEngine;

public class SpawnedCube : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector2 xVelocityRange = new(-1, 1);
    [SerializeField] private float verticalVelocity = 10;
    [SerializeField] private Vector2 zVelocityRange = new(-1, 1);

    [SerializeField] private float lifetime = 10;

    private static CubeSpawner cubeSpawner;

	private void Start()
	{
		GameObject.Find("Cube Spawner").GetComponent<CubeSpawner>().spawnedCubes++;
	}

	private void Update()
	{
		rb = GetComponent<Rigidbody>();
		cubeSpawner = GameObject.Find("Cube Spawner").GetComponent<CubeSpawner>();

		if (GameObject.Find("Cube Spawner").GetComponent<CubeSpawner>().spawnedCubes > 10000)
			Destroy(gameObject, lifetime);
	}

	private void FixedUpdate()
	{
		rb = GetComponent<Rigidbody>();
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
