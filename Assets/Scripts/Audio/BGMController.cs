using FMODUnity;
using Level;
using UnityEngine;
using WorldChange;

namespace Audio
{
    public class BGMController : MonoBehaviour
    {
        [SerializeField] StudioEventEmitter _emitter;
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            WorldChangeManager.Instance.OnNewWorld += OnNewWorld;
            LevelManager.Instance.OnLevelChange += OnLevelChange;
        }

        void OnLevelChange(string curlevel)
        {
            // throw new System.NotImplementedException();
        }

        void OnNewWorld(World newworld)
        {
            // throw new System.NotImplementedException();
        }
    }
}