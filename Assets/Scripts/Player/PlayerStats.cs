using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float oxygen = 100f;
    [SerializeField] private float maxOxygen = 100f;
    [SerializeField] private float oxygenDepletionSpeed = 0.01f;
    [SerializeField] private float tapeOxygenDepletionSpeed = 0.01f;
    [SerializeField] private float healthDepletionSpeed = 0.01f;
    [SerializeField] private Image healthImage;
    [SerializeField] private Image oxygenImage;
    [SerializeField] private GameObject tape;

    private void Update()
    {
        //right here we do the oxygen down en als je geen meer heb dan ga je lowkey dood

        if (tape != null)
        {
            oxygen -= tapeOxygenDepletionSpeed;
        }

        if (tape == null)
        {
            oxygen -= oxygenDepletionSpeed;
        }

        if (oxygen <= 0)
        {
            health -= healthDepletionSpeed;
        }

        UpdateHP();
        UpdateOxygen();
    }

    private void UpdateHP()
    {
        if (healthImage != null)
        {
            healthImage.fillAmount = (float)health / maxHealth;
        }
    }

    private void UpdateOxygen()
    {
        if (oxygenImage != null)
        {
            oxygenImage.fillAmount = (float)(oxygen / maxOxygen);
        }
    }
}
