
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject bananaPeelItem;
    public GameObject rakeItem;
    public GameObject bombItem;
    public GameObject ballItem;

    public float spawnY;
    public float leftMaximumPosition;
    public float RightMaximumPosition;

    private GameObject[] items;

    void Start()
    {
        items = new GameObject[2];
        items[0] = bombItem;
        items[1] = ballItem;

        InvokeRepeating("SpawnRandomItem", 2.0f, 3.0f);
    }

    void Update()
    {
        // if(Input.anyKeyDown)
        // {
        //     CancelInvoke("SpawnRandomItem");
        // }
    }

    //user - defined functions
    private void SpawnItem(GameObject prefab, Vector3 position)
    {
        GameObject newItem = Instantiate(prefab, position, Quaternion.identity);
        newItem.GetComponent<Item>().SetSpawned();
    }

    private void SpawnRandomItem()
    {
        Vector3 position = new Vector3(Random.Range(leftMaximumPosition, RightMaximumPosition) ,spawnY ,0);
        int itemIndex = Mathf.RoundToInt(Random.Range(0,2));
        SpawnItem(items[itemIndex], position);
    }

}
