//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.NuclearSimulator;
using System.Collections;
using TMPro;
using UnityEngine;
 

namespace PetrusGames
{
    public class GameManager : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private Animator endGameAnim;
        [SerializeField] private AnimationClip anim;
        [SerializeField] private TextMeshPro good;
        [SerializeField] private TextMeshPro bad;
        [SerializeField] private float explosionTime;
        [SerializeField] private ReadyPlayers readyPlayers;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        public static GameManager instance;
        #endregion

        #region PUBLIC FUNCTIONS

        public void StartGame()
        {
            Time.timeScale = 1f;
            GameTimer.instance.StartTime();
        }

        public void EndGame()
        {
            StartCoroutine("End", good);
        }

        public void GameOver()
        {
            SoundManager.Instance.PlaySound("StarTrekEmergency");
            SoundManager.Instance.PlaySound("ExplosionFinal");
            StartCoroutine("End", bad);
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            SetAsSingleton();
            
        }

        private void Start()
        {
            readyPlayers.onPlayerReady += PlayersReadyHandler;
            Time.timeScale = 0f;
        }

        private void PlayersReadyHandler()
        {
            SoundManager.Instance.PlaySound("Song");
            StartGame();
        }

        private void SetAsSingleton()
        {
            if (instance)
                Destroy(this);
            else
                instance = this;
        }

        private IEnumerator End(TextMeshPro text)
        {
            GameOverAnim.instance.ExplosionAnimation();
            yield return new WaitForSeconds(explosionTime);
            endGameAnim.SetTrigger("Play");
            text.gameObject.SetActive(true);
            yield return new WaitForSeconds(anim.length + 0.2f);
            Time.timeScale = 0f;
        }
        #endregion


    }
}
