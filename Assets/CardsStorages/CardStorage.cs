using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName = "Card")]

public class CardStorage : ScriptableObject
{
    public string _storageNameOfCard;
    public Sprite _storageSpriteOfCard;
    public string _storageChangeAbility;
    public Abilities _abilities;


}
