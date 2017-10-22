using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration : MonoBehaviour
{
    public LootTable current;
    
    float maxPoint = 0.0f;

    float randomPoint;

    public ItemAsset chosenItem;

    void Start()
    {
        for (int i = 0; i < current.dropChance.Count - 1; i++) //sprawdzanie maksymalnego punktu na wylosowanie jakiegokolwiek itemeka
        {
            maxPoint += current.dropChance[i];
            Debug.Log(current.dropChance[i]);
        }

        current.dropChance[current.dropChance.Count - 1] = 1.0f - maxPoint; // upewnianie się że ostatnie miejsce tabeli dropChance jest dopełnieniem sumy szans na drop itemków do 1

        randomPoint = Random.Range(0.0f, 1.0f); //losowanie punktu od 0 do 1

        if (randomPoint > maxPoint) chosenItem = null; //sprawdzanie czy wylosowany punkt da jakis itemek czy nie i ustawianie null jesli nie da
        else //jeśli da (czyli jesli wylosowany punkt jest ponizej max punktu dajacego itemek
        {
            for (int i = 0; i < current.dropChance.Count; i++)
            {
                randomPoint -= current.dropChance[i]; 
                if (randomPoint <= 0) //odejmowanie poszczególnych progów prawdopodobienistwa i sprawdzanie czy różnica przekroczyła wylosowany punkt
                {
                    chosenItem = current.lootTable[i]; //jesli tak to ten aktualny próg jest wylosowanym itemkiem, przerywamy odejmowanie
                    break;
                }
            }
        }
        if(chosenItem!=null)
        Instantiate(chosenItem.overworldPrefab, gameObject.transform.position, Quaternion.identity); //tworzymy obiekt o ile ma byc stworzony
    }
}