using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject targetPrefab;

    private int nbExistingTarget;
    private int nbTargetToSpawn = 50;

    private float areaRange;
    /*private float minDistance = 50f;
    private float maxDistance = 50f;*/

    // Start is called before the first frame update
    void Start()
    {
        areaRange = PlayerPrefs.GetFloat("areaRange", 5f);
        /*minDistance = PlayerPrefs.GetFloat("minDistance");
        maxDistance = PlayerPrefs.GetFloat("minDistance");*/

        StartCoroutine(SpawnTarget());
        /*transform.position = new Vector3(transform.position.x, transform.position.y, minDistance);*/
    }

    IEnumerator SpawnTarget()
    {
        while (nbTargetToSpawn > 0 && nbExistingTarget < 10)
        {
            float positionX = Random.Range(-areaRange * 2, areaRange * 2);
            float positionY = Random.Range(-areaRange, areaRange);
            /*float positionZ = Random.Range(minDistance, maxDistance);

            Vector3 targetPosition = new Vector3(transform.position.x + positionX, transform.position.y + positionY, positionZ);*/
            Vector3 targetPosition = new Vector3(transform.position.x + positionX, transform.position.y + positionY, transform.position.z);

            Instantiate(targetPrefab, targetPosition, Quaternion.identity, transform);

            nbTargetToSpawn--;
            nbExistingTarget++;

            yield return new WaitForSeconds(1f);
        }
        if (nbExistingTarget >= 10)
        {
            gameManager.EndGame();
        }
    }

    public void TargetHit()
    {
        nbExistingTarget--;
        if (nbTargetToSpawn <= 0 && nbExistingTarget <= 0)
        {
            gameManager.EndGame();
        }
    }
}
