//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Abdelfetah Hamra                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Aftah-Games 2019                                                                            | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.HelperLibrary;
using PetrusGames.NuclearPlant.Objects.Elements;
using UnityEngine;


namespace AftahGames.NuclearSimulator
{
    public class GriffeGrab : MonoBehaviour
    {
        private GameObject grabObject;


        [SerializeField] private Animator anim;
        [SerializeField] private Input_Manager inputManager;
        [SerializeField] private Transform grabPos;
        [SerializeField] private float animSpeed = 0.1f;

        private bool isGrabbing = false;

        private float currentAnimState = 0f;
        private float targetAnimState = 0f;

        private void OnEnable()
        {
            inputManager.OnGrabEvent += Input_OnGrabEvent;
            inputManager.OnReleaseGrabEvent += Input_OnReleaseGrabEvent;

        }

        private void Update()
        {
            UpdateAnimState();
        }

        private void UpdateAnimState()
        {
            currentAnimState = Mathf.Lerp(currentAnimState, targetAnimState, animSpeed);
            anim.SetFloat(AnimatorParamHelper.PARAM_GRAB_VELOCITY, currentAnimState);
        }

        private void Input_OnGrabEvent(float obj, bool isGrab)
        {

            //anim.SetFloat(AnimatorParamHelper.PARAM_GRAB_VELOCITY, obj);
            targetAnimState = 1f;

            SoundManager.Instance.StopSound("OpenGrab");
            SoundManager.Instance.PlaySound("CloseGrab");

            if (grabObject != null)
            {


                grabObject.GetComponent<Rigidbody>().isKinematic = true;
                grabObject.GetComponent<ElementIDScript>().IsGrabbed = true;
                grabObject.GetComponent<BoxCollider>().isTrigger = true;
                grabObject.GetComponent<Rigidbody>().useGravity = false;
                grabObject.transform.parent = grabPos.transform;

                isGrabbing = true;
            }
        }

        private void Input_OnReleaseGrabEvent(float obj, bool isRelease)
        {

            //anim.SetFloat(AnimatorParamHelper.PARAM_GRAB_VELOCITY, obj);
            targetAnimState = 0f;

            SoundManager.Instance.StopSound("CloseGrab");
            SoundManager.Instance.PlaySound("OpenGrab");

            isGrabbing = false;

            if (isRelease == true)
            {

                if (grabObject != null)
                {
                    if (grabObject.CompareTag(TagHelper.TAG_GRABABLE_ELEMENT))
                    {

                        grabObject.GetComponent<Rigidbody>().isKinematic = false;
                        grabObject.GetComponent<ElementIDScript>().IsGrabbed = false;
                        grabObject.GetComponent<BoxCollider>().isTrigger = false;
                        grabObject.GetComponent<Rigidbody>().useGravity = true;

                        grabObject.transform.parent = null;

                    }
                }
                grabObject = null;

            }
        }
        private void OnDisable()
        {
            inputManager.OnGrabEvent -= Input_OnGrabEvent;
            inputManager.OnReleaseGrabEvent -= Input_OnReleaseGrabEvent;

        }


        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag(TagHelper.TAG_GRABABLE_ELEMENT) && !isGrabbing)
            {

                grabObject = other.gameObject;

            }

        }


        private void OnTriggerExit(Collider other)
        {

            if (other.gameObject.CompareTag(TagHelper.TAG_GRABABLE_ELEMENT) && !isGrabbing)
            {
                other.GetComponent<Rigidbody>().isKinematic = false;
                other.GetComponent<ElementIDScript>().IsGrabbed = false;
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.GetComponent<Rigidbody>().useGravity = true;

                other.transform.parent = null;
                grabObject = null;

            }
        }




    }
}
