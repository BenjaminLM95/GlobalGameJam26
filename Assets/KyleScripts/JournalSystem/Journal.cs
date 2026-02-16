using TMPro;
using UnityEngine;

public class Journal : Singleton<Journal>
{
    private CharacterData character;
    private string hunterName;
    [SerializeField] private GameObject colorRed;
    [SerializeField] private GameObject colorGreen;
    [SerializeField] private GameObject colorBlue;
    [SerializeField] private GameObject holyWater;
    [SerializeField] private GameObject stake;
    [SerializeField] private GameObject garlic;
    [SerializeField] private GameObject male;
    [SerializeField] private GameObject female;
    [SerializeField] private TextMeshProUGUI nameText;
    public CharacterData hunterData;


    public override void Awake()
    {
        base.Awake();
        Events.OnHunterPicked.Add(SetHunterData);
        // Events.OnHunterPicked.Add(SetCharacter);
        Events.TryAddClueToJournal.Add(ActivateClue);
        SetAllInactive();
    }

    private void SetHunterData(CharacterData _hunterData)
    {
        hunterData = _hunterData;
    }

    private void ActivateClue(string name)
    {
        if (!hunterData.keyWords.Contains(name)) return;
        Debug.Log("Clue name in journal is " + name);
        if (colorRed.name == name) colorRed.SetActive(true);
        if (colorGreen.name == name) colorGreen.SetActive(true);
        if (colorBlue.name == name) colorBlue.SetActive(true);
        if (holyWater.name == name) holyWater.SetActive(true);
        if (stake.name == name) stake.SetActive(true);
        if (garlic.name == name) garlic.SetActive(true);
        if (male.name == name) male.SetActive(true);
        if (female.name == name) female.SetActive(true);
    }

    private void SetAllInactive()
    {
        colorRed.gameObject.SetActive(false);
        colorGreen.gameObject.SetActive(false);
        colorBlue.gameObject.SetActive(false);
        holyWater.gameObject.SetActive(false);
        stake.gameObject.SetActive(false);
        garlic.gameObject.SetActive(false);
        female.gameObject.SetActive(false);
        male.gameObject.SetActive(false);
    }
}
