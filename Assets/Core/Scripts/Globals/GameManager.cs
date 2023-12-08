using Cinemachine;
using Core.Scripts.Factories;
using Core.Scripts.States.Car;
using Core.Scripts.Store;
using Core.Scripts.Views;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("StartButton")] [SerializeField]
    private Button _startBtn;

    [Header("Store")] public StoreLogic storeLogic;
    public Upgrade upgrade;

    [Space] [Header("Level")] [SerializeField]
    private int level;

    [SerializeField] private int levelText;
    [SerializeField] private int[] _indexBots;
    [SerializeField] private float[] _widthWays;

    public Text levelTextUI;

    [SerializeField] private ActionPanelManager _actionPanelManager;
    [SerializeField] private CinemachineVirtualCamera _gameCamera;

    public CarStateManager carStateManager;
    public FactoryCoin factoryCoin;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(Str.Level))
        {
            levelText = PlayerPrefs.GetInt(Str.Level);
            levelTextUI.text = $"Lvl {levelText + 1}";
            level = levelText;
            if (levelText >= _widthWays.Length)
            {
                level = Random.Range(0, _widthWays.Length);
            }
        }
    }

    private void Start()
    {
        _startBtn.onClick.AddListener(() =>
        {
            _gameCamera.Priority = 100;
            carStateManager.SetState(carStateManager.shotState);
        });
    }

    private void OnDestroy()
    {
        _startBtn.onClick.RemoveAllListeners();
    }

    public void SetHP()
    {
        carStateManager.hp.hp++;
        carStateManager.hp.healthBar.SetMaxHealth(carStateManager.hp.hp);
    }

    public float GetWidthWay() => _widthWays[level];

    public float GetIndexBot() => _indexBots[level];

    public void Win()
    {
        Time.timeScale = 0;
        level++;
        levelText++;

        PlayerPrefs.SetInt(Str.Level, levelText);
        _actionPanelManager.OpenPanels(0);
    }
}