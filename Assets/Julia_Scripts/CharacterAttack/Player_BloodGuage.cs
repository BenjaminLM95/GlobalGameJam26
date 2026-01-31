using System.Collections;
using UnityEngine;

public class Player_BloodGuage : MonoBehaviour
{
    [SerializeField] private float maxBlood = 100;
    public float currentBlood { get; private set; }
    [SerializeField] private float bloodDecayRate = 0.1f;
    public BloodGuage_UI bloodGuageUI;


    void Start()
    {
        currentBlood = maxBlood;
        bloodGuageUI.SetMaxBlood(maxBlood);
        Debug.Log("Starting blood: " + currentBlood);
    }

    void Update()
    {
        StartCoroutine(BloodDecay(01));
    }

    public void GetBlood(int amount)
    {
        currentBlood += amount;
        if(currentBlood > maxBlood)
        {
            currentBlood = maxBlood;
        }
        //Debug.Log($"Got blood! Current Blood: {currentBlood}");
        bloodGuageUI.SetBlood(currentBlood);
    }

    IEnumerator BloodDecay(float amount)
    {
        // decay blood guage over time
        while(currentBlood > 0)
        {
            currentBlood -= bloodDecayRate;
            Debug.Log($"Current Blood after decay: {currentBlood}");
            bloodGuageUI.SetBlood(currentBlood);
            yield return new WaitForSeconds(5f);
        }
    }
}