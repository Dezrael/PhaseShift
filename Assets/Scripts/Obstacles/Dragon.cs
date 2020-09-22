using System.Collections;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float reloadTime;

    void Start()
    {
        StartCoroutine(CastFireball());
    }

    private IEnumerator CastFireball()
    {
        while(true)
        {
            Instantiate(fireballPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(reloadTime);
        }
    }
}
