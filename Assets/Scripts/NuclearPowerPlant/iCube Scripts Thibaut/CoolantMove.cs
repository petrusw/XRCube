using AftahGames.NuclearSimulator;
using PetrusGames.NuclearPlant.Managers.Data;
using UnityEngine;

namespace ThibautPetit
{
    //Abonner GetPauseInput à l'input Manager
    public class CoolantMove : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private PlayerAbility playerAbility;
        [SerializeField] private Animator anim;
        [SerializeField] private float animMaxSpeed;
        [SerializeField] private float smoothTime;
        [SerializeField] private Transform teleportPos;
        [SerializeField] private bool movingLeft = true;
        #endregion

        #region PRIVATE FIELDS
        private float coolantSpeed;
        private bool isMoving = true;
        private float currentAnimSpeed = 1f;
        private float targetAnimSpeed = 1f;
        private float currentVelocity = 1f;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Start()
        {
            coolantSpeed = DataManager.Instance.CoolantSpeed;
            SoundManager.Instance.PlaySound("FanOnMovement");

        }

        private void OnEnable()
        {
            playerAbility.OnCoolerEvent += CoolerEventHandler;
        }

        private void OnDisable()
        {
            playerAbility.OnCoolerEvent -= CoolerEventHandler;
        }

        private void CoolerEventHandler(bool obj)
        {

            Pause();

        }

        private void Pause()
        {
            isMoving = !isMoving;

            if (isMoving == false)
            {
                SoundManager.Instance.StopSound("FanOnMovement");
                SoundManager.Instance.PlaySound("PauseFan");
                targetAnimSpeed = animMaxSpeed;
            }
            else
            {
                SoundManager.Instance.PlaySound("FanOnMovement");
                SoundManager.Instance.StopSound("PauseFan");
                targetAnimSpeed = 1f;
            }
        }

        void Update()
        {
            if (isMoving)
                Move();

            UpdateAnimSpeed();
        }

        private void UpdateAnimSpeed()
        {
            currentAnimSpeed = Mathf.SmoothDamp(currentAnimSpeed, targetAnimSpeed, ref currentVelocity, smoothTime);
            anim.speed = currentAnimSpeed;
        }

        private void Move()
        {
            gameObject.transform.Translate((movingLeft ? Vector3.left : Vector3.right) * coolantSpeed * Time.deltaTime);
            SoundManager.Instance.PlaySound("FanOnMovement");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MaxRange"))
            {
                transform.position = new Vector3(teleportPos.position.x, transform.position.y, transform.position.z);
            }
        }


        #endregion
    }
}
