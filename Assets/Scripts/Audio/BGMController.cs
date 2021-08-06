using FMODUnity;
using UnityEngine;

namespace Audio
{
    public class BGMController : MonoBehaviour
    {
        [SerializeField] StudioEventEmitter _bgmEmitter;
        
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            _bgmEmitter.Play();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}