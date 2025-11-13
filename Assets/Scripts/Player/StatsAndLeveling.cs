using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class StatsAndLeveling : MonoBehaviour
{
    [SerializeField] int playerHealthMax = 100;
    [SerializeField] float playerHealthCurrent = 75;
    [SerializeField] float XPCurrent = 0;
    [SerializeField] float XPForNextLevel = 4;
    [SerializeField] int level = 1;

    [SerializeField] Image healthBar;
    [SerializeField] Image XPBar;
    [SerializeField] bool XPGain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (XPCurrent >= XPForNextLevel)
        {
            XPCurrent = 0;
            level++;
            float tempValue = Mathf.Pow(level - 1, 1.5f);
            XPForNextLevel = (int)tempValue*8;

            float playerHealthTemp = (int)playerHealthMax * 1.08f;
            playerHealthMax = (int)playerHealthTemp;
            playerHealthCurrent = playerHealthMax;
        }

        if (XPGain)
        {
            XPUP();
        }

        healthBar.fillAmount = Mathf.Clamp01(playerHealthCurrent / playerHealthMax);
        XPBar.fillAmount = Mathf.Clamp01(XPCurrent / XPForNextLevel);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "XP Gain")
        {
            XPGain = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "XP Gain")
        {
            XPGain = false;
        }
    }
    private void XPUP()
    {
        XPCurrent++;
    }
}
