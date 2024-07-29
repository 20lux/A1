using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform origin;

    private float spawnRate = 0.01f;
    private int maxSpawns = 10000;
    [HideInInspector] public int spawnedCubes;

	private void Start()
	{
        StartCoroutine(SpawnCubes());
	}

	private void Update()
	{
        if (Time.deltaTime > 1)
        {
            enabled = false;
            Debug.LogWarning("Spawner script has been disabled to prevent too much overhead and crashing.");
        }
	}

	private IEnumerator SpawnCubes()
    {
        spawnedCubes = 0;

        while (spawnedCubes < maxSpawns)
        {
			int spawnAmount = 10;

			for (int i = 0; i < spawnAmount; i++)
            {      
                GameObject cube = Instantiate(cubePrefab, origin);
                cube.GetComponent<SpawnedCube>().SetRandomVelocity();
            }

			yield return new WaitForSeconds(spawnRate);
		}
    }
}
