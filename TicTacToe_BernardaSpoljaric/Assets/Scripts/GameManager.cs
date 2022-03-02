using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Main Menu Panel:")]
    public InputField playerOneInput;
    public InputField playerTwoInput;
    public Slider volumeSlider;

    [Header("Game Panel:")]
    public Text playerOneName;
    public Text playerTwoName;
    public Text playerOneScore;
    public Text playerTwoScore;
    public Text movesText;

    [Header("Game over panel")]
    public GameObject gameOverPanel;

    [Header("Array polja za x i o:")]
    public Text[] fieldList;

    [Header("Other (X i O):")]
    public string side;
    public int moves = 1;

    public AudioSource assTheme;
    public AudioSource assClick;
    public AudioSource assWin;

    private void Start()
    {
        assTheme.Play();

        gameOverPanel.SetActive(false);
        side = "X";
        moves = 1;

        for (int i = 0; i < fieldList.Length; i++)
        {
            fieldList[i].text = "";
            fieldList[i].GetComponentInParent<Button>().interactable = true;
        }

        playerOneScore.text = PlayerPrefs.GetInt("scoreOne").ToString();
        playerTwoScore.text = PlayerPrefs.GetInt("scoreTwo").ToString();
        playerOneName.text = PlayerPrefs.GetString("playerOne");
        playerTwoName.text = PlayerPrefs.GetString("playerTwo");

        movesText.text = "MOVES: " + moves;
    }

    public void ChangeSide()
    {
        if (side == "X")
        {
            side = "O";
        }
        else
        {
            side = "X";
        }
        movesText.text = "MOVES: " + moves;
    }

    public void EndGame()
    {
        if (fieldList[0].text == side && fieldList[1].text == side && fieldList[2].text == side)
        {
            CheckWin();
        }
        else if (fieldList[3].text == side && fieldList[4].text == side && fieldList[5].text == side)
        {
            CheckWin();
        }
        else if (fieldList[6].text == side && fieldList[7].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if(fieldList[0].text == side && fieldList[3].text == side && fieldList[6].text == side)
        {
            CheckWin();
        }
        else if(fieldList[1].text == side && fieldList[4].text == side && fieldList[7].text == side)
        {
            CheckWin();
        }
        else if(fieldList[2].text == side && fieldList[5].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if(fieldList[0].text == side && fieldList[4].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if(fieldList[2].text == side && fieldList[4].text == side && fieldList[6].text == side)
        {
            CheckWin();
        }
        else if (moves > 9)
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "TIE!";
        }


        ChangeSide();
    }

    void CheckWin()
    {
        gameOverPanel.SetActive(true);
        if(side == "X")
        {
            assTheme.Stop();
            assWin.Play();
            
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = playerOneName.text + " WINS";
            PlayerPrefs.SetInt("scoreOne", PlayerPrefs.GetInt("scoreOne") + 1);
        }
        else if(side == "O")
        {
            assTheme.Stop();
            assWin.Play();

            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = playerTwoName.text + " WINS";
            PlayerPrefs.SetInt("scoreTwo", PlayerPrefs.GetInt("scoreTwo") + 1);
        }

    }

    public void SetUpNames()
    {
        if (playerOneInput.text != "" && playerOneInput.text != "")
        {
            playerOneName.text = playerOneInput.text;
            playerTwoName.text = playerTwoInput.text;

            PlayerPrefs.SetString("playerOne", playerOneName.text);
            PlayerPrefs.SetString("playerTwo", playerTwoName.text);
        }
    }

    public void ResetGame()
    {
        Start();
    }

    public void ChangeVolume()
    {
        assTheme.volume = volumeSlider.value;
        assClick.volume = volumeSlider.value;
        assWin.volume = volumeSlider.value;
    }

}
