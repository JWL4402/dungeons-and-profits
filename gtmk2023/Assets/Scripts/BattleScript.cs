using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Party adventurers;
    public Party monsters;

    public Potion holy_water;
    public Potion healing_potion;

    public TextMeshProUGUI dialogue;

    void Start()
    {
        dialogue.text = "The adventure begins.\n";

        monsters.InitializeStats();
        monsters.health = monsters.maxHealth;
        Expedition(2);
    }

    private void Attack(Party attacker, Party target)
    {
        int damage = Mathf.CeilToInt(Random.Range(attacker.damage * 0.85f, attacker.damage * 1.15f));
        damage -= target.defense;
        if (damage < Mathf.CeilToInt(attacker.damage * 0.2f))
        {
            damage = Mathf.CeilToInt(attacker.damage * 0.2f);
        }
        Random.Range(damage * 0.85f, damage * 1.15f);

        dialogue.text += attacker.name + " attacks " + target.name + " for " + damage.ToString() + " damage! " +
            target.name + "'s health drops from " + target.health.ToString() + " to " + Mathf.Clamp(target.health - damage, 0, 999).ToString() + "!\n";

        target.health -= damage;
    }

    void PreBattle()
    {
        monsters.health -= adventurers.bonusDamage;
    }

    void Battle()
    {
        PreBattle();

        List<Party> order = new List<Party>();
        if (monsters.speed > adventurers.speed)
        {
            order.Add(monsters);
            order.Add(adventurers);
        }
        else if (adventurers.speed >= monsters.speed)
        {
            order.Add(adventurers);
            order.Add(monsters);
        }

        while (!(monsters.health <= 0 || adventurers.health <= 0))
        {
            Attack(order[0], order[1]);
            order.Reverse();
        }

        if (adventurers.health <= 0)
        {
            //SceneManager.LoadScene("Title");
        }
    }

    void Expedition(int numBattles)
    {
        for (int i = 0; i < numBattles; i++)
        {
            while ((float) adventurers.maxHealth / (float) adventurers.health < 0.9)
            {
                int amount = 0;
                adventurers.inventory.TryGetValue(holy_water, out amount);

                if (amount == 0) { break; }

                adventurers.health += holy_water.health;
                adventurers.inventory[holy_water]--;
            }
            while ((float)adventurers.maxHealth / (float)adventurers.health < 0.75)
            {
                int amount = 0;
                adventurers.inventory.TryGetValue(healing_potion, out amount);

                if (amount == 0) { break; };
                adventurers.health += healing_potion.health;
                adventurers.inventory[healing_potion]--;
            }
            Battle();
            monsters.Strengthen(1.04f);
            adventurers.gold += Mathf.CeilToInt(10 * Random.Range(monsters.scale * 0.8f, monsters.scale * 1.2f));
        }
        monsters.Strengthen(1.10f);
    }

    public void ReturnToShop()
    {
        if (adventurers.health <= 0) {
            SceneManager.LoadScene("Title");
            return;
        }
        SceneManager.LoadScene("Shop");
    }
}
