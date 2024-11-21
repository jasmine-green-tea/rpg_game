using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStatsController : MonoBehaviour
{
    private RectTransform hpBarRect;
    private RectTransform xpBarRect;

    private TMP_Text levelText;
    private TMP_Text powerText;

    private float maxOffsetValue = 4f;
    private float minOffsetValue = 300f - 4f;

    private int hp = 100;
    private int xp = 0;

    private int playerLevel = 1;

    private int xpToNextLevel = 100;
    private int maxHp = 100;

    private int power = 1;

    private int counter = 0;
    [SerializeField]
    private int eventSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        hpBarRect = transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        xpBarRect = transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
        levelText = transform.GetChild(2).GetComponent<TMP_Text>();
        powerText = transform.GetChild(3).GetComponent<TMP_Text>();



        xpBarRect.offsetMax = new Vector2(-minOffsetValue, -4);
        //hpBarRect.offsetMax = new Vector2(-minOffsetValue / 3, -4);

    }

    private void Update()
    {
        counter++;

        if (counter % (500 * eventSpeed) == 0)
            OnXPGained(13);
        if (counter == (1000 * eventSpeed))
        {
            OnDamageTaken(3);
            counter = 0;
        }
    }

    public void OnXPGained(int incomingXp)
    {
        xp += incomingXp;

        
        if (xp >= xpToNextLevel)
        {
            playerLevel++;
            levelText.text = "Level: " + playerLevel.ToString();

            GainPermaPower(1);

            //send event to level up enemies
        }

        xp %= xpToNextLevel;

        int xpToDraw = xp;

        float offsetToSet = ((float)xpToDraw / xpToNextLevel) * (minOffsetValue - maxOffsetValue);

        xpBarRect.offsetMax = new Vector2(-minOffsetValue + offsetToSet, -4);



        //trigger ui xp event
    }

    private void GainPermaPower(int gain)
    {
        power += gain;

        powerText.text = "Power: " + power.ToString();
    }

    public void OnDamageTaken(int damage)
    {
        hp -= damage;

        if (hp < 0)
            hp = 0;

        float offsetToSet = ((float)hp / maxHp) * (minOffsetValue - maxOffsetValue);
        hpBarRect.offsetMax = new Vector2(-minOffsetValue + offsetToSet, -4);

        if (hp == 0)
            Debug.Log("DEAD!!!");
        
    }
}
