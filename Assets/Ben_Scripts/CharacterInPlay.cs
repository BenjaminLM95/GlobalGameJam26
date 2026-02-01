using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CharacterInPlay : MonoBehaviour
{
    private TargetSystem targetSystem;

    //[SerializeField] private List<Participant> participants = new List<Participant>();

    public List<GameObject> participants = new List<GameObject>();

     

    private void Awake()
    {
        targetSystem = FindFirstObjectByType<TargetSystem>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }      

    public void DisactivateTarget() 
    {
        Debug.Log("Find Victim");
        if(targetSystem.GetVictimName() != null)
        {
            RemoveParticipant(targetSystem.GetVictimName());
            Debug.Log("Victim Disactivated"); 
        }
    }

    public void RemoveParticipant(string killerName) 
    {
        for(int i = 0; i < participants.Count; i++) 
        {
            string currentParticipantName = participants[i].GetComponent<InteractableCharacter>().GetParticipantName();              

            if(currentParticipantName == targetSystem.GetVictimName()) 
            {
                participants[i].SetActive(false); 
            }
        }
    }


    [System.Serializable]
    public struct Participant 
    {
        GameObject participantObj;
        string participantName;
    }

}
