using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private SpawnedCube cubePrefab;
    [SerializeField] private Transform origin;

    private ObjectPool<SpawnedCube> objectPool;
    public ObjectPool<SpawnedCube> ObjectPool => objectPool;
    private int spawnRate = 16;
    private int maxSpawns = 10000;
    [HideInInspector] public int spawnedCubes;

	private async void Start()
	{
        CreatePools();
        Task spawnedCubeTask = SpawnCubes();
        await spawnedCubeTask;

        if (spawnedCubeTask.IsFaulted || spawnedCubeTask.IsCanceled)
        {
            Debug.Log("Spawned Cube task is no longer running");
        }
	}

    private void CreatePools()
    {
        objectPool = new ObjectPool<SpawnedCube>(
        CreateCube,
        ActivateCube,
        DeactivateCube,
        DestroyCube,
        false, 
        0, maxSpawns);
    }

    private SpawnedCube CreateCube()
    {
        SpawnedCube cube = Instantiate(cubePrefab, origin);
        return cube;
    }

    private void ActivateCube(SpawnedCube cube)
    {
        cube.gameObject.SetActive(true);
    }

    private void DeactivateCube(SpawnedCube cube)
    {
        cube.gameObject.SetActive(false);
    }

    private void DestroyCube(SpawnedCube cube)
    {
        Destroy(cube);
    }

    private async Task SpawnCubes()
    {
        while (spawnedCubes < maxSpawns)
        {
            SpawnCube();
            await Task.Delay(spawnRate);
        }
    }

    private void SpawnCube()
    {
        objectPool.Get(out SpawnedCube newSpawnedCube);

        if (!newSpawnedCube)
        {
            return;
        }

        newSpawnedCube.SetRandomVelocity();
    }
}
