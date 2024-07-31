using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform origin;

    private ObjectPool<GameObject> objectPool;
    public ObjectPool<GameObject> ObjectPool => objectPool;
    private float spawnRate = 0.01f;
    private int maxSpawns = 10000;
    [HideInInspector] public int spawnedCubes;

	private void Start()
	{
        // StartCoroutine(SpawnCubes());
        CreatePools();
	}

    private void CreatePools()
    {
        objectPool = new ObjectPool<GameObject>(() =>
        {
            GameObject cube = Instantiate(cubePrefab, origin);
            return cube;
        },
        ActivateCube,
        DeactivateCube,
        DestroyCube,
        false, 
        0, maxSpawns);
    }

	private void Update()
	{
        // if (Time.deltaTime > 1)
        // {
        //     enabled = false;
        //     Debug.LogWarning("Spawner script has been disabled to prevent too much overhead and crashing.");
        // }

         
	}

    private void ActivateCube(GameObject cube)
    {
        cube.SetActive(true);
    }

    private void DeactivateCube(GameObject cube)
    {
        cube.SetActive(false);
    }

    private void DestroyCube(GameObject cube)
    {
        Destroy(cube);
    }

	// private IEnumerator SpawnCubes()
    // {
    //     spawnedCubes = 0;

    //     while (spawnedCubes < maxSpawns)
    //     {
	// 		int spawnAmount = 10;

	// 		for (int i = 0; i < spawnAmount; i++)
    //         {      
    //             GameObject cube = Instantiate(cubePrefab, origin);
    //             cube.GetComponent<SpawnedCube>().SetRandomVelocity();
    //         }

	// 		yield return new WaitForSeconds(spawnRate);
	// 	}
    // }
}
