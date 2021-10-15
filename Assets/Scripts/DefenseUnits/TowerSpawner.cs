using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.DefenseUnits
{
    public class TowerSpawner : MonoBehaviour
    {
        private List<GameObject> towers = new List<GameObject>();
        [SerializeField] private Transform spawnPointsRoot;
        private List<GameObject> spawnPoints;

        private List<GameObject> spawnedTowers = new List<GameObject>();

        private void Awake()
        {
            GetTowersFromFolder("Towers");
            GetSpawnPoints();         
        }

        public void SpawnTower(GameObject button)
        {
            spawnedTowers.Add(
                Instantiate(
                towers.Find(x => x.name.Equals(button.name)), 
                spawnPoints.Find(x => x.name == button.transform.parent.name).transform.position, 
                Quaternion.identity));
        }

        private void GetTowersFromFolder(string folderName)
        {
            Object[] resources = Resources.LoadAll(folderName);
            foreach (Object o in resources)
            {
                towers.Add((GameObject)o);
            }
        }

        private void GetSpawnPoints()
        {
            spawnPoints = new List<GameObject>();
            for (int i = 0; i < spawnPointsRoot.childCount; i++)
            {
                spawnPoints.Add(spawnPointsRoot.GetChild(i).gameObject);
            }
        }
    }
}
