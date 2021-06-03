using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static LevelManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public static LevelManager GetInstance()
    {
        return _instance;
    }

    #region Score
    private void Start()
    {
        textSize = scoreText.fontSize;
    }

    [SerializeField] private TMPro.TMP_Text scoreText;
    [SerializeField] private float textAnimationLength;

    private float textSize;
    private float scoreAnimationTimer = 0;
    private int score = 0;

    private float SizeFromTimer(float x)
    {
        return textSize + x * (textAnimationLength - x) * textSize*2*4 / textAnimationLength / textAnimationLength;
    }
    public void RaiseScore()
    {
        score++;
        scoreText.text = $"{score}";
        scoreAnimationTimer = textAnimationLength;
    }

    private void Update()
    {
        scoreText.fontSize = SizeFromTimer(scoreAnimationTimer);
        scoreAnimationTimer = Mathf.Max(0, scoreAnimationTimer - Time.deltaTime);
    }
    #endregion

    [SerializeField] private Rigidbody carRb;

    [SerializeField] private GameObject losePanel;

    [SerializeField] InputManager inputManager;
    public void Lose()
    {
        carRb.velocity = Vector3.zero;
        carRb.isKinematic = true;
        losePanel.SetActive(true);
        inputManager.enabled = false;
    }

    [SerializeField] private GameObject winPanel;
    public void Win()
    {
        carRb.velocity = Vector3.zero;
        winPanel.SetActive(true);
        inputManager.enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
