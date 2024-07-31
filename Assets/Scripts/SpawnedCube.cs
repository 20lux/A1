using System.Threading.Tasks;
using UnityEngine;

public class SpawnedCube : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;

	[SerializeField] private Vector2 xVelocityRange = new Vector2(-1, 1);
	[SerializeField] private float verticalVelocity = 10;
	[SerializeField] private Vector2 zVelocityRange = new Vector2(-1, 1);

	[SerializeField] private int lifetime = 10000;

	private void OnEnable()
	{
		SetLifetime();
	}

	//Releases a cube from the pool after a set lifetime
	private async void SetLifetime()
	{
		await Task.Delay(lifetime);

		if (gameObject.activeSelf)
		{
			CubeSpawner.Instance.ObjectPool.Release(this);
		}
	}

	public void Initialise()
	{
		SetRandomVelocity();
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
