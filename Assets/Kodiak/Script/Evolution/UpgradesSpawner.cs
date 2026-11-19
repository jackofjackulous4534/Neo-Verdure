using Unity.ProjectAuditor.Editor.Core;
using UnityEngine;

public class UpgradesSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] upgrades;
    [SerializeField] GameObject posOne;
    [SerializeField] GameObject posTwo;
    [SerializeField] int upgradeOne;
    [SerializeField] int upgradeTwo;
    public float currentUpgrades;
    void Awake()
    {
        SpawnOne();
        SpawnTwo();
    }

    void SpawnOne()
    {
        upgradeOne = Random.Range(0, 2);
        Instantiate(upgrades[upgradeOne], posOne.transform.position, Quaternion.identity);
    }
    void SpawnTwo()
    {
        upgradeTwo = Random.Range(0, 2);
        Instantiate(upgrades[upgradeTwo], posTwo.transform.position, Quaternion.identity);
    }
}
