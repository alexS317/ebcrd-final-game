using System.Collections;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private Terrain terrain;

    [SerializeField] private GameObject collectible;

    [SerializeField] private float timeBetweenSpawns;

    private bool _coroutineAllowed;

    // Start is called before the first frame update
    void Start()
    {
        _coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn apples as long as the max nr isn't reached yet
        if (GlobalStorage.Instance.CurrentAppleNr < GlobalStorage.Instance.MaxAppleNr)
            if (_coroutineAllowed) StartCoroutine(SpawnObject());
    }

    // Spawn a new object at a random position
    IEnumerator SpawnObject()
    {
        _coroutineAllowed = false;

        // Get terrain origin-position and size
        var terrainPos = terrain.transform.position;
        var terrainSize = terrain.terrainData.size;
        
        // Calculate a random position within the area of the terrain
        Vector3 spawnPos = new Vector3(
            Random.Range(terrainPos.x, terrainPos.x + terrainSize.x),
            0,
            Random.Range(terrainPos.z, terrainPos.z + terrainSize.z));

        // Get the terrain height of the random position
        var spawnPosY = terrain.SampleHeight(spawnPos);
        spawnPos.y = spawnPosY + 2; // Set y position + 2 (so the object won't be inside the terrain)

        // Spawn new object
        GameObject newCollectible = Instantiate(collectible, spawnPos, transform.rotation);
        GlobalStorage.Instance.SpawnAppleCounter();

        yield return new WaitForSeconds(timeBetweenSpawns);
        
        _coroutineAllowed = true;
    }
}