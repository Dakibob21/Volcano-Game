using System.Collections;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LavaDetection : MonoBehaviour
{
    public GameObject lava;
    public GameObject player;
    private Distance distanceType;
    private float distance;
    private int maxHP = 1000;
    private int currentHP;
    public TMP_Text hpText;
    public TMP_Text degreesText;
    public float currentDegrees = 35f;
    public float maxDegrees = 45f;
    private bool isCooldown = false;
    private enum Distance
    {
        Space,
        XYPlane
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        currentDegrees = 35f;
        maxDegrees = 45f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (distanceType)
        {
            case Distance.Space:
                distance = CalculateDistanceInSpace();
                break;
            case Distance.XYPlane:
                distance = CalculateDistanceXYPlane();
                break;
        }

        if (distance <= 2)
        {
            HeatUp(1);
            LavaClose();

        }
        if (distance > 2)
        {
            LavaGone();
        }
        if (distance < 1)
        {
            LavaHit();
        }
    }

    private float CalculateDistanceInSpace()
    {
        return Vector3.Distance(lava.transform.position, player.transform.position);

    }

    private float CalculateDistanceXYPlane()
    {
        Vector2 v1 = new Vector2(lava.transform.position.x, lava.transform.position.y);
        Vector2 v2 = new Vector2(player.transform.position.x, player.transform.position.y);
        return Vector2.Distance(v1, v2);
    }
    void LavaClose()
    {
       
    }

    void LavaGone()
    {
        
    }
    void LavaHit()
    {
        TakeDamage(1);
        
    }


    public void TakeDamage(int amount)
    {
        if (amount < 0)
            return;
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPDisplay();

        if (currentHP <= 0)
        {
            Debug.Log("You Died");
        }
    }

    public void HeatUp(float amount)
    {
        currentDegrees = Mathf.Clamp(currentDegrees + amount, currentDegrees, maxDegrees);
        UpdateDegreeDisplay();
    }

    private void UpdateDegreeDisplay()
    {
        if (degreesText != null)
        {
            degreesText.text = $"Degrees: {currentDegrees}/{maxDegrees}";
        }
    }
    private void UpdateHPDisplay()
    {
        if (hpText != null)
        {
            hpText.text = $"HP: {currentHP}/{maxHP}";
        }
    }

}
