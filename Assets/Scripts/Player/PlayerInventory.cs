using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventory;
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private GameObject gunPlayer;

    private bool addedItem = false;
    public bool gunAdded = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item") && !addedItem)
        {
            Item itemScript = other.gameObject.GetComponent<Item>();

            inventory.Add(itemScript.prefabRefrence);

            if (inventory.Contains(gunPrefab))
            {
                gunAdded = true;
                gunPlayer.SetActive(true);
            }

            Debug.Log(itemScript.prefabRefrence);
            Debug.Log(gunPrefab);
            Destroy(other.gameObject);
            addedItem = true;
            StartCoroutine(itemGrabCooldown());
        }
    }

    void Update()
    {

    }

    private IEnumerator itemGrabCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        addedItem = false;
    }
}
