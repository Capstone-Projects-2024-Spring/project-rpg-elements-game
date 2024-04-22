using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class PlayerStats: NetworkBehaviour {

    //Assignments for the player's stats.
    public StatsConfig statsConfig;
    public GameObject statPanel;
    public CharacterStat Strength;
    public CharacterStat Speed;
    public CharacterStat Health;
    public CharacterStat CurrentHealth;

    private float lerpTimer;
    public float chipSpeed = 2f;

    private float healTimer = 0f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI statValues;
    //public TextMeshProUGUI levelText;
  

    //Basically on start, assigned these values to the ones in the config
    public void Awake()
    {
        Strength = new CharacterStat(statsConfig.baseStrength);
        Speed = new CharacterStat(statsConfig.baseSpeed);
        Health = new CharacterStat(statsConfig.baseHealth);
        CurrentHealth = new CharacterStat(statsConfig.baseHealth);
    }

    //Subscribes to the event in which level increases.
    private void OnEnable()
    {
    if (Level.Instance != null)
        {
            Debug.Log("Subscribed to Level");
            Level.LevelStatUp += HandleLevelUp;
        }
        else
        {
            Debug.LogError("Subscription failed. Instance or event is null.");
            //This is for the level manager,  if you're not using it in your level, feel free to ignore!
        }
    }
    
    //Unsubscribes when disabled.
    private void OnDisable()
    {
        Debug.Log("Unsubscribed");
        Level.LevelStatUp -= HandleLevelUp;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            //CheckStats();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //AddSpeed();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenStatUI();
        }
        healTimer -= Time.deltaTime;
        if (CurrentHealth.Value < Health.Value && healTimer <= 0f)
        {
            if(CurrentHealth.Value + (int)(CurrentHealth.Value *.10) > Health.Value){
                heal((int)(Health.Value - CurrentHealth.Value));
            } else{
                heal((int)(Health.Value *.10));
            }
            
            healTimer = 5f;
        }
        UpdateHealthUI();
        statValues.text = Health.Value.ToString() + "\n" + Strength.Value.ToString() + "\n" + Speed.Value.ToString();
    }
    public void CheckStats()
    {
        print("Speed is " + Speed.Value);
    }
    public void AddSpeed()
    {
        Speed.IncreaseStat(2);
    }
    public void takeDamage(int damageTaken)
    {
        CurrentHealth.DecreaseStat(damageTaken);
        lerpTimer = 0f;
        print("Player [" + this.gameObject.name + "] took [" + damageTaken + "] damage and is now at [" + CurrentHealth.Value + "] health.");
        if (Health.Value <= 0)
        {
            die();
        }
    }
    public void heal(int amountHealed)
    {
        CurrentHealth.IncreaseStat(amountHealed);
        lerpTimer = 0f;
        print("Player [" + this.gameObject.name + "] healed [" + amountHealed + "] damage and is now at [" + CurrentHealth.Value + "] health.");
    }
    public void die()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        print(this.gameObject.name + " is dead");
    }

    //Currently passes the level (although not actually necessary)
    //Might be useful if you want to adjust stat gains by level or usch
    private void HandleLevelUp(int level)
    {
        //levelText.text = level.ToString();
        Debug.Log("Current player level is: " + level);
        int maxIncrease = 10; //Adjust this to change maximum stat growth
        float old; //Just used for debugging

        //Gets a random value, evaluate y via the curve and then increment
        float v = Random.Range(0f, 1f);                                                                 //Essentially choose a random value
        old = Speed.Value;                                                                              //Correspond value to the curve, then multiply to get value
        Speed.IncreaseStat(Mathf.RoundToInt(statsConfig.speedCurve.Evaluate(v)* maxIncrease));          
        Debug.Log("Speed: " + old + "->" + Speed.Value);

        old = Health.Value;
        v = Random.Range(0f, 1f);
        Health.IncreaseStat(Mathf.RoundToInt(statsConfig.healthCurve.Evaluate(v)* maxIncrease));
        Debug.Log("Health: " + old + "->" + Health.Value);
        Debug.Log("CurrentHealth: " + CurrentHealth.Value);
 

        old = Strength.Value;
        v = Random.Range(0f, 1f);
        Strength.IncreaseStat(Mathf.RoundToInt(statsConfig.strengthCurve.Evaluate(v)* maxIncrease));
        Debug.Log("Strength: " + old + "->" + Strength.Value);
    }

    public void UpdateHealthUI()
    {
        //Local values for the images fill value
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = CurrentHealth.Value / Health.Value;

        if(fillB > hFraction){  //On Health Decrease
            frontHealthBar.fillAmount = hFraction;  //Fill decreases to this %
            backHealthBar.color = Color.red;        //Sets the follow bar to red
            lerpTimer += Time.deltaTime;            //Creates lerp to ease into new health from old
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if(fillF < hFraction){  //On Health Increase
            backHealthBar.fillAmount = hFraction;   //Fill increases to this % (note that its back this time)
            backHealthBar.color = Color.green;      //changes to green
            lerpTimer += Time.deltaTime;            //Lerp to ease into new health from old
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }

        healthText.text = Mathf.RoundToInt(CurrentHealth.Value) + "/" + Mathf.RoundToInt(Health.Value);
    }

    public void OpenStatUI()
    {
        statPanel.SetActive(!statPanel.activeSelf);
    }

}