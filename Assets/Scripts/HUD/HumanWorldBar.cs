using UnityEngine;
using UnityEngine.UI;
using WorldChange;

public class HumanWorldBar : MonoBehaviour
{
    [SerializeField] GameObject _barHolder;
    [SerializeField] Slider _humanBar;
    [SerializeField] float _curTime;
    bool _countingDown;
    
    // Start is called before the first frame update
    void Start()
    {
        WorldChangeManager.Instance.OnHumanWorldWithTime += OnHumanWorldWithTime;
        WorldChangeManager.Instance.OnNewWorld += OnNewWorld;
    }

    void OnNewWorld(World newworld)
    {
        if(newworld == World.SoulWorld)
            StopCountingDown();
    }

    void OnHumanWorldWithTime(World newworld, float worldtime)
    {
        if (newworld == World.HumanWorld)
            StartCountingDown(worldtime);
    }

    void Update()
    {
        if(_countingDown)
            CountingDown();
    }

    void CountingDown()
    {
        _curTime -= Time.deltaTime;
        _humanBar.value = _curTime;
    }

    void StartCountingDown(float maxTime)
    {
        _humanBar.maxValue = maxTime;
        _humanBar.value = maxTime;
        _curTime = _humanBar.value;
        
        _barHolder.gameObject.SetActive(true);

        _countingDown = true;
    }
    
    void StopCountingDown()
    {
        _countingDown = false;
        _barHolder.gameObject.SetActive(false);
    }
}
