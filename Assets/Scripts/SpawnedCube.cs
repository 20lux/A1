using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class SpawnedCube : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;

	//[SerializeField] private Vector2 xVelocityRange = new Vector2(-1, 1);
	//[SerializeField] private float verticalVelocity = 10;
	//[SerializeField] private Vector2 zVelocityRange = new Vector2(-1, 1);

	[SerializeField] private int lifetime = 10000;

	private Coroutine lifetimeCoroutine;
	private WaitForSeconds lifetimeWait;

	private void Awake()
	{
		lifetimeWait = new WaitForSeconds(lifetime);
	}

	private void OnEnable()
	{
		lifetimeCoroutine = StartCoroutine(SetLifetime());
	}

	private void OnDisable()
	{
		if (lifetimeCoroutine != null)
		{
			StopCoroutine(lifetimeCoroutine);
		}
	}

	//Releases a cube from the pool after a set lifetime
	private IEnumerator SetLifetime()
	{
		yield return lifetimeWait;

		if (gameObject != null && gameObject.activeSelf)
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
			Random.Range(-1, 1),
			10, 
			Random.Range(-1, 1));

		rb.angularVelocity = new Vector3(
			Random.Range(-10, 10), 
			Random.Range(-10, 10), 
			Random.Range(-10, 10));
	}
}
