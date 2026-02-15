using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventory;

    private bool addedItem = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item") && !addedItem)
        {
            Item itemScript = other.gameObject.GetComponent<Item>();

            inventory.Add(itemScript.prefabRefrence);
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
