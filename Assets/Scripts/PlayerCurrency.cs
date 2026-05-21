using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    public int gold;

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("Gold: " + gold);
    }
}