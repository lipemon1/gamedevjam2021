using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WorldChange;

public class SoulsBalls : MonoBehaviour
{
    [SerializeField] List<Image> _soulsBalls = new List<Image>();
    
    // Start is called before the first frame update
    void Start()
    {
        SoulsCollectorManager.Instance.OnSoulCollected += OnSoulCollected;
    }

    void OnSoulCollected(int currentsoul)
    {
        foreach (Image image in _soulsBalls)
            image.gameObject.SetActive(false);
        
        int soulsNeeded = WorldChangeManager.Instance.GetSoulsNeededToWorldChange();
        int amount = currentsoul / soulsNeeded;
        if (amount > _soulsBalls.Count)
        {
            foreach (Image image in _soulsBalls)
                image.gameObject.SetActive(true);
        }
        else if (amount < _soulsBalls.Count)
        {
            for (int i = 0; i < amount; i++)
            {
                _soulsBalls[i].gameObject.SetActive(true);
            }
        }
    }
}
