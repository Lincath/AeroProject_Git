using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;


namespace WeLoveAero
{
    public class Course_Manager : MonoBehaviour
    {
        #region Variables
        [Header("Manager Properties")]
        public List<Course> tracks = new List<Course>();
        public Airplane_Controller airplaneController;

        [Header("Manager Events")]
        public UnityEvent OnCompletedRace = new UnityEvent();
        #endregion



        #region Basics Methods
        // Use this for initialization
        private void Start()
        {
            FindTracks();
            InitializeTracks();

            StartTrack(0);
        }

        private void Update()
        {

        }
        #endregion



        #region Custom Methods
        public void StartTrack(int trackID)
        {
            if (trackID >= 0 && trackID < tracks.Count)
            {
                for(int i = 0; i < tracks.Count; i++)
                {
                    if(i != trackID)
                    {
                        tracks[i].gameObject.SetActive(false);
                    }

                    tracks[trackID].gameObject.SetActive(true);
                    tracks[trackID].StartTrack();
                }
            }
        }

        void FindTracks()
        {
            tracks.Clear();
            tracks = GetComponentsInChildren<Course>(true).ToList<Course>();
        }

        void InitializeTracks()
        {
            if(tracks.Count > 0)
            {
                foreach(Course track in tracks)
                {
                    track.OnCompletedTrack.AddListener(CompletedTrack);
                }
            }
        }

        void CompletedTrack()
        {
            Debug.Log("Completed Track!");

            if(airplaneController)
            {
                StartCoroutine("WaitForLanding");
            }
        }

        /*
        IEnumerator WaitForLanding()
        {
            while(airplaneController.State != AirplaneState.LANDED)
            {
                yield return null;
            }

            Debug.Log("Completed Race!");
            if (OnCompletedRace != null)
            {
                OnCompletedRace.Invoke();
            }
        }
        */
        #endregion
    }
}
