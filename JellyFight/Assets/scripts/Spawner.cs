using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Spawners;
    [SerializeField] private BeanCollision[] Beans;
    private List<BeanCollision> ItemsList = new List<BeanCollision>();
    private List<GameObject> SpawnersList = new List<GameObject>();

    void Start(){
        FillLists();
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning(){
        yield return new WaitForSeconds(5);
        while (true){
            if (ItemsList.Count!=0 && SpawnersList.Count!=0){
                print(" SpawnСount" + SpawnersList.Count);
                var _randomItemNumber = Random.Range(0, ItemsList.Count);
                var randomSpawnNumber = Random.Range(0, SpawnersList.Count);
                Vector3 spawnPosition = SpawnersList[randomSpawnNumber].transform.position;
                SpawnersList.Remove(SpawnersList[randomSpawnNumber]);
                ItemsList[_randomItemNumber].ParentTransform.position = spawnPosition;
                ItemsList[_randomItemNumber].spawnNumber = randomSpawnNumber;
                ItemsList[_randomItemNumber].gameObject.SetActive(true);
                ItemsList.Remove(ItemsList[_randomItemNumber]);
            }
            yield return new WaitForSeconds(10);
        }
    }

    private void OnBeanPicked(int number, int spawnNumber){
        ItemsList.Add(Beans[number]);
        SpawnersList.Add(Spawners[spawnNumber]);
    }

    private void FillLists(){
        for (int i = 0; i < Beans.Length; i++){
            Beans[i].myNumber = i;
            ItemsList.Add(Beans[i]);
            Beans[i].Picked.AddListener(OnBeanPicked);
        }
        for (int i = 0; i < Spawners.Length; i++){
            SpawnersList.Add(Spawners[i]);
        }
    }

}
