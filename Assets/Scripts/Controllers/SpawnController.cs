using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public OreBehaviour[] orePrefabs;
    private int oreSpawnCount = 1;

    public Transform MinPositionCorner;
    public Transform MaxPositionCorner;

    public MeshRenderer groundRenderer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < oreSpawnCount; i++)
        {
            int selectedOreIndex = Random.Range(0, orePrefabs.Length);
            OreBehaviour selectedPrefab = orePrefabs[selectedOreIndex];
            OreBehaviour spawnedOre = Instantiate(selectedPrefab, null);

            //float randomXPosition = Random.Range(MinPositionCorner.position.x, MaxPositionCorner.position.x);
            //float randomZPosition = Random.Range(MinPositionCorner.position.z, MaxPositionCorner.position.z);

            float randomXPosition = Random.Range(groundRenderer.bounds.min.x, groundRenderer.bounds.max.x);
            float randomZPosition = Random.Range(groundRenderer.bounds.min.z, groundRenderer.bounds.max.z);

            spawnedOre.transform.position = new Vector3(randomXPosition, spawnedOre.transform.position.y,randomZPosition);
        }
    }
}
