using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;
    private GameObject spawnedEnemy;

    [SerializeField] private Transform botLeftPos, botRightPos; //topLeftPos, topRightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(monsterReference[randomIndex]);

            //left
            if(randomSide == 0)
            {
                spawnedEnemy.transform.position = botLeftPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);

            }
            else //right
            {
                spawnedEnemy.transform.position = botRightPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(-10, -4);
                //spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            //switch (randomSide)
            //{
            //    case 0:
            //        spawnedEnemy.transform.position = botLeftPos.position;
            //        spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
            //        break;
            //    case 1:
            //        spawnedEnemy.transform.position = botRightPos.position;
            //        spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
            //        spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            //        break;
                //case 2:
                //    spawnedEnemy.transform.position = topLeftPos.position;
                //    spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
                //    break;
                //case 3:
                //    spawnedEnemy.transform.position = topRightPos.position;
                //    spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                //    spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
                //    break;
            }
        }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
