using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyPrefab;
    float countdown = 3;
    [SerializeField] float WaveDelay = 3;
    int WaveNumber;
    [SerializeField] Transform startpos;
    IEnumerator Start()
    {
        WaveNumber = 1;
        while (true)
        {
            yield return new WaitForSeconds(WaveDelay);

            StartCoroutine(WaveSpawn()); //Обращение к функции
        }
    }
    IEnumerator WaveSpawn()
    {
        WaveNumber++;
        for (int i = 0; i < WaveNumber; i++)
        {
            GameObject en = Instantiate(enemyPrefab, startpos.position, Quaternion.identity);
            en.GetComponent<Enemy>().speed = 5 + WaveNumber;
            yield return new WaitForSeconds(0.3f); //Подождать секунду (Работает только с IEnumerator)
        }


    }
}
