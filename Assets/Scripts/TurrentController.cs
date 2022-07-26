using UnityEngine;
using UnityEngine.Events;

public class TurrentController : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject projectile;
    private int allowedProjectilesCount = 12;
    static public int currentTurrentCount = 0;
    private bool allowDesroy = false;
    static public UnityEvent reactivateTurrent;
    private bool preventSpawnNewTurrents = false;
    static public bool ForcePreventAllTurentSpawn = false;

    void Start()
    {
        if (reactivateTurrent == null) reactivateTurrent = new UnityEvent();
        reactivateTurrent.AddListener(ForceReactivateTurrent);
        allowDesroy = false;
        currentTurrentCount++;
        sprite.color = new Color(255, 255, 255);
        InvokeRepeating("RotateAndShoot", 6, 0.5f);
        Invoke("PreventSelfCollision", 0.1f);
    }
    void ForceReactivateTurrent()
    {
        sprite.color = new Color(255, 0, 0);
        ForcePreventAllTurentSpawn = true;
        preventSpawnNewTurrents = true;
        allowedProjectilesCount = 12;
    }
    void PreventSelfCollision()
    {
        allowDesroy = true;
    }

    void RotateAndShoot()
    {
        if (allowedProjectilesCount > 0)
        {
            sprite.color = new Color(255, 0, 0);
            allowedProjectilesCount--;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Random.Range(15, 45) + transform.localEulerAngles.y, transform.localEulerAngles.z);
            LaunchProjectile();
        }
        else
        {
            sprite.color = new Color(255, 255, 255);
            CancelInvoke("RotateAndShoot");
        }
    }
    void LaunchProjectile()
    {
        GameObject newProjectille = Instantiate(projectile, transform.position + (transform.TransformDirection(Vector3.up)*0.6f), transform.rotation);
        newProjectille.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up * 4);
        if (preventSpawnNewTurrents) newProjectille.GetComponent<ProjectileController>().preventSpawnTurrent = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!allowDesroy) return;
        Debug.Log("Tower collision");
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        currentTurrentCount--;
    }
}
