using UnityEngine;

public class RandomizePosition : MonoBehaviour
{
    [SerializeField] GameObject[] enemyGO;
    [SerializeField] int numberOfSpawns = 100;
    [SerializeField] int range = 15;
    [SerializeField] GameObject enemyParent;

    private void Start()
    {
        for (int i = 0; i <= numberOfSpawns; i++)
        {
            int randomIndex = Random.Range(0, enemyGO.Length);
            Vector3 randomSpawn = new Vector3(transform.position.x + Random.Range(-range, range), 2, transform.position.z + Random.Range(-range, range));
            var enemySpawn = Instantiate(enemyGO[randomIndex], randomSpawn, Quaternion.identity);
            enemySpawn.transform.parent = enemyParent.transform;
        }
    }
}