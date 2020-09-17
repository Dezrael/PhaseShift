using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private float reloadTime;
    [SerializeField] private Transform spawnPoint;

    void Start()
    {
        StartCoroutine("CastFireball");
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
