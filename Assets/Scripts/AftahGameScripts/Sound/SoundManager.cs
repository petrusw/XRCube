//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Abdelfetah Hamra                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Aftah-Games 2019                                                                            | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using UnityEngine;
using UnityEngine.Audio;


namespace AftahGames.NuclearSimulator
{
    public class SoundManager : MonoBehaviour
    {



        #region SERIALIZED FIELDS
        [SerializeField] [Range(1, 10)]
        private float mainVolume = 1f;

        [SerializeField]
        private SoundClips[] soundClips;

        #endregion

        #region PRIVATE FIELDS

        private static SoundManager _instance = new SoundManager();
        
        #endregion

        #region PUBLIC PROPERTIES

        public static SoundManager Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this);

            }

            for (int i = 0; i < soundClips.Length; i++)
            {
                if (soundClips[i].audioSource == null)
                {
                    GameObject gameObject = new GameObject("soundClip_" + i + "_" + soundClips[i].name);
                    gameObject.transform.SetParent(this.transform);
                    soundClips[i].audioSource = gameObject.AddComponent<AudioSource>();
                    soundClips[i].audioSource.outputAudioMixerGroup = soundClips[i].outpup;   
                    soundClips[i].audioSource.clip = soundClips[i].audioClips;
                    soundClips[i].audioSource.playOnAwake = soundClips[i].playOnAwake;
                    soundClips[i].audioSource.pitch = soundClips[i].pitch;
                    soundClips[i].audioSource.loop = soundClips[i].loop;
                    soundClips[i].audioSource.panStereo = soundClips[i].stereoPan;
                    soundClips[i].audioSource.mute = soundClips[i].mute;
                    soundClips[i].audioSource.volume = soundClips[i].volume;

                }

                if (soundClips[i].playOnAwake)
                {
                    soundClips[i].audioSource.playOnAwake = true; ;
                    return;
                }

            }
        }



        public void PlaySound(string name)
        {

            for (int i = 0; i < soundClips.Length; i++)
            {
                if (soundClips[i].name == name)
                {
                    if (!soundClips[i].audioSource.isPlaying)
                    {
                       // soundClips[i].audioSource.volume *= mainVolume;  
                        soundClips[i].audioSource.Play();

                    }
                    return;
                }
            }

            Debug.Log("Sound not found...");

        }



        public void StopSound(string name)
        {

            for (int i = 0; i < soundClips.Length; i++)
            {
                if (soundClips[i].name == name)
                {
                    soundClips[i].audioSource.Stop();
                    return;
                }
            }

            Debug.Log("Sound not found...");

        }
        #endregion



    }


    [System.Serializable]
    public class SoundClips
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC FIELDS

        public string name;

        public AudioSource audioSource;

        public AudioClip audioClips;

        public AudioMixerGroup outpup;

        [Range(0, 1)]
        public float volume = 1f;


        [Range(0, 3)]
        public float pitch = 1f;


        [Range(-1, 1)]
        public float stereoPan = 0f;




        public bool loop = false;
        public bool mute = false;
        public bool playOnAwake = false;




        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS

      
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        #endregion


    }
}
