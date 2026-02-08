using System.Collections;
using UnityEngine;

public class Player_BloodGuage : MonoBehaviour
{
    [SerializeField] private float maxBlood = 100;
    public float currentBlood { get; private set; }
    [SerializeField] private float bloodDecayRate = 0.1f;
    public BloodGuage_UI bloodGuageUI;

    private UIManager _uiManager; 

    void Start()
    {
        FillGauge(); 
        Debug.Log("Starting blood: " + currentBlood);
        _uiManager = FindFirstObjectByType<UIManager>();
    }

    void Update()
    {
        StartCoroutine(BloodDecay(01));

        if(currentBlood < 1) 
        {
            if(_uiManager == null) 
            {
                _uiManager = FindFirstObjectByType<UIManager>(); 
            }

            if (_uiManager != null)
            {
                _uiManager.ActivateLoseUI();
            }
        }
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

    public void FillGauge() 
    {
        currentBlood = maxBlood;
        bloodGuageUI.SetMaxBlood(maxBlood);
    }

    IEnumerator BloodDecay(float amount)
    {
        // decay blood guage over time
        while(currentBlood > 0)
        {
            currentBlood -= bloodDecayRate;
            //Debug.Log($"Current Blood after decay: {currentBlood}");
            bloodGuageUI.SetBlood(currentBlood);
            yield return new WaitForSeconds(5f);
        }
    }
}