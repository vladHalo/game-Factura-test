using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Scripts.Views
{
    public class GameTimeView : MonoBehaviour
    {
        [SerializeField] private Text _timeText, _bestTimeText;
        private float _time, _bestTime;
        [Inject] private GameManager _gameManager;

        private void Start()
        {
            // if (PlayerPrefs.HasKey(Str.BestTime))
            // {
            //     _bestTime = PlayerPrefs.GetFloat(Str.BestTime);
            //     _bestTimeText.text = _bestTime.ToString("##") + " sec";
            // }
        }

        private void Update()
        {
            switch (_gameManager.statusGame)
            {
                case StatusGame.Play:
                    _time += Time.deltaTime;
                    _timeText.text = _time.ToString("##") + " sec";
                    break;
                case StatusGame.Stop:
                    if (_time > _bestTime)
                    {
                        //PlayerPrefs.SetFloat(Str.BestTime, _time);
                        _bestTimeText.text = _time.ToString("##") + " sec";
                    }

                    break;
            }
        }
    }
}