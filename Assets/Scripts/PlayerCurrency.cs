using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    public int gold;

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("Gold: " + gold);
    }

    public bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true;
        }

        Debug.Log("Not enough gold");
        return false;
    }
}