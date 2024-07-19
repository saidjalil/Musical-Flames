using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PatternController : MonoBehaviour
{
    public List<int> _patternList = new List<int>();
    public List<int> _playerInputList = new List<int>();
    public List<Button> _candles = new List<Button>();

    private int _defaultPatternSize = 5;
    private int _currentPatternSize;

    public int CurrentPatternSize // to access the score
    {
        get { return _currentPatternSize; }
        set { _currentPatternSize = value;}
    }

    private void OnEnable()
    {
        GameEvents.OnGeneratePatternEvent += OnGeneratePatternEventHandler;
        GameEvents.OnGameRestartEvent += OnRestartGameEventHandler;

    }
    private void OnDisable()
    {
        GameEvents.OnGeneratePatternEvent -= OnGeneratePatternEventHandler;
        GameEvents.OnGameRestartEvent -= OnRestartGameEventHandler;

    }
    private void Start()
    {
        // adding the buttons to a list

        Button[] allCandles = gameObject.GetComponentsInChildren<Button>();
        if(allCandles == null)
        return;
        foreach (Button candle in allCandles){
        _candles.Add(candle);
        }
        AddButtonIndex();
        _currentPatternSize = _defaultPatternSize;
        HandleInteraction(false);
    }

    private void OnRestartGameEventHandler() // In case of losing, the try again button restarts the game
    {
        _currentPatternSize = _defaultPatternSize;
        _patternList.Clear();
        HandleInteraction(false);
    }

    private void IncreasePatternSize() // In case of winning, the game increases the pattern
    {
        _currentPatternSize++;
        EnlargePattern();
        StartCoroutine(ShowPattern());
    }
    private void OnGeneratePatternEventHandler() // For generating a pattern
    {
        _patternList.Clear();
        for(int i = 0; i < _currentPatternSize; i++)
        {
            EnlargePattern();
        }
        StartCoroutine(ShowPattern());
    }
    private IEnumerator ShowPattern() // Showcasing the pattern
    {
        HandleInteraction(false);
        yield return new WaitForSeconds(1);
        if(_patternList.Count == 0)
        yield return null;
        foreach(int i in _patternList)
        {
            yield return StartCoroutine(_candles[i].GetComponent<CandleController>().LitCandle());
        }

        HandleInteraction(true);
    }
    // IF WIN THEN ADD ONE MORE TO CURRENT PATTERN SIZE
    private void EnlargePattern()
    {
        int litetCandle = Random.Range(0,_candles.Count);
        _patternList.Add(litetCandle);
    }

    private void HandleInteraction(bool interact) // For enabling/disabling the buttons when needed
    {
        foreach(Button candle in _candles)
        {
            candle.GetComponent<Button>().interactable = interact;
        }
    }

    private void AddButtonIndex() // Indexing the buttons
    {
        for(int i = 0; i < _candles.Count; i++)
        {
        int x = i;
         _candles[i].onClick.AddListener(delegate {GetInput(x); });
        }
    }

    private void GetInput(int playerInput) // Getting the player input
    {
        _playerInputList.Add(playerInput);
        StartCoroutine(_candles[playerInput].GetComponent<CandleController>().LitCandle());
        Compare();
    }   

    private void Compare() // Check for pattern is same as the input
    {
        for(int i = 0; i < _playerInputList.Count; i++)
        {
            if(!(_patternList[i] ==  _playerInputList[i]))
            {
                UIEvents.RaiseOnRestartMenuEvent(CurrentPatternSize);
                _playerInputList.Clear();
                break;
            }
            if(_playerInputList.Count == _currentPatternSize)
            {
                IncreasePatternSize();
                GetComponent<AudioSource>().Play();
                _playerInputList.Clear();
            }
        }
        

    }

    
}
