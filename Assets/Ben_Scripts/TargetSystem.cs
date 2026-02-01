using System.Collections.Generic;
using System.Collections; 
using TMPro;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{

    public List<CharacterData> characterList = new List<CharacterData>();

    [SerializeField] List<CharacterData> tempCharacterList = new List<CharacterData>();

    [SerializeField] private CharacterData hunter = null;
    [SerializeField] private CharacterData victim = null;

    public TextMeshProUGUI messageKilled; 
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ClearData(); 

        // Select the victim
        PickAVictim(tempCharacterList);

        // Select the Hunter
        PickAHunter(tempCharacterList);        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ClearData() 
    {
        tempCharacterList.Clear();
        CopyList();
        hunter = null;
        victim = null;
    }

    private void CopyList() 
    {
        
        for (int i = 0; i < characterList.Count; i++)
        {
            tempCharacterList.Add(characterList[i]); 
          }
        
    }


    private void PickAHunter(List<CharacterData> _charDatas) 
    {
        // This picked a random character, it get stored and then is removed from the list

        int rndIndex = Random.Range(0, _charDatas.Count);

        Debug.Log(rndIndex); 
        CharacterData removedItem = _charDatas[rndIndex];       
        Debug.Log(removedItem.name);
        Events.OnHunterPicked.Publish(hunter);
        hunter = removedItem;          
    }

    private void PickAVictim(List<CharacterData> _charDatas)
    {
        // This picked a random character, it get stored and then is removed from the list

        int rndIndex = Random.Range(0, _charDatas.Count);

        Debug.Log(rndIndex);
        CharacterData removedItem = _charDatas[rndIndex];
        Debug.Log(removedItem.name);

        victim = removedItem;

        _charDatas.RemoveAt(rndIndex);

        PopMurderMessageUp(); 
    }

    private void PopMurderMessageUp() 
    {
        messageKilled.gameObject.SetActive(true);
        messageKilled.text = $"{victim.name} was killed";
        StartCoroutine("RemoveMurderKill"); 
    }

    private IEnumerator RemoveMurderKill() 
    {
        yield return new WaitForSecondsRealtime(5f);
        messageKilled.gameObject.SetActive(false);
    }


}
