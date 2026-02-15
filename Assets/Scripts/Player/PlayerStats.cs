using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float oxygen = 100f;
    [SerializeField] private float oxygenDepletionSpeed = 0.01f;
    [SerializeField] private Image blud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //right here we do the oxygen down en als je geen meer heb dan ga je lowkey dood
        oxygen -= oxygenDepletionSpeed;
        if (oxygen <= 0)
        {
            health -= 0.05f;
        }
        if (oxygen != 0)
        {
            blud.transform.localScale = new Vector3(1, oxygen * 1/100, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
