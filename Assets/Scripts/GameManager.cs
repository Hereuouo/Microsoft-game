using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthtext;
    public Slider healthslider;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins : 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateCoinText(int coins) 
    {
        coinText.text = "Coins :" + coins.ToString();
    }

    public void UpdateHealthText(int currenthealth,int maxhealth)
    {
        healthtext.text = currenthealth + "/" + maxhealth.ToString();
        float newcurrenthealth = (float)currenthealth / maxhealth;
        healthslider.value = newcurrenthealth;
    }

}
