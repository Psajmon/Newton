using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 spawnPosition;
    private float distanceToDestroy;
    public GameObject turrentToSpawn;
    public bool preventSpawnTurrent = false;

    void Start()
    {
        spawnPosition = transform.position;
        distanceToDestroy = Random.Range(1, 4);
    }
    private void Update()
    {
        //checking distance:
        if(Vector3.Distance(spawnPosition , transform.position) >= distanceToDestroy)
        {
            Destroy(gameObject);
            SpawnNewTurrent();
        }
    }

    private void SpawnNewTurrent()
    {
        if (preventSpawnTurrent) return;
        if(TurrentController.currentTurrentCount < 100)
        {
            if (!TurrentController.ForcePreventAllTurentSpawn)
            {
                GameObject newTurrent = Instantiate(turrentToSpawn, transform.position, turrentToSpawn.transform.rotation);
            }
            
        }
        else
        {
            preventSpawnTurrent = true;
            TurrentController.reactivateTurrent.Invoke();
        }
    }
}
