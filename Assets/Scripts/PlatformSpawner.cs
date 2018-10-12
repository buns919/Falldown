using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenRowSpawns = 4f;
    [SerializeField] GameObject platformPrefab;

    private bool enableWaveSpawn = true;

    // Use this for initialization
    private IEnumerator Start() {
        // start spawing waves until we're told to stop
        do {
            yield return StartCoroutine(SpawnRow());
        }
        while (enableWaveSpawn);
    }

    // Update is called once per frame
    void Update() {
    }


    IEnumerator SpawnRow() {
        int numSpawns = 0;

        Transform[] waypoints = GetComponentsInChildren<Transform>();
        List<GameObject> instances = new List<GameObject>();

        //foreach (Transform waypoint in waypoints) {
        for (int i = 0; i < waypoints.Length; i++) {

            if (Random.value > 0.4f) {
                var instance = Instantiate(platformPrefab, waypoints[i].transform) as GameObject;
                instance.transform.parent = gameObject.transform.parent;
                instances.Add(instance);
                numSpawns++;
            }
        }

        if (numSpawns == waypoints.Length) {
            Destroy(instances[Random.Range(0, waypoints.Length - 1)]);
        }

        yield return new WaitForSeconds(secondsBetweenRowSpawns);
    }

    IEnumerator OldSpawnRow() {
        var spawnTransform = GetComponentInChildren<Transform>().transform;
        GameObject platformInstance = Instantiate(platformPrefab, spawnTransform) as GameObject;

        // create a random width
        Vector3 currentScale = platformInstance.transform.localScale;
        float randomRange = Random.Range(currentScale.x * .25f, currentScale.x * 1.75f);
        platformInstance.transform.localScale = new Vector3(randomRange, currentScale.y, currentScale.z);

        // adjust the starting position
        //platformInstance.transform.position = new Vector3();
        yield return new WaitForSeconds(secondsBetweenRowSpawns);
    }
}
