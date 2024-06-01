using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Door : MonoBehaviour
{
    public InteractionsWithItems interactionsWithItems;
    [SerializeField] private string password = "72248145";
    private string combination = "";
    private int i = 0;
    [SerializeField] private char[] number = new char[8];
    public TMP_Text code;
    [SerializeField] private bool is4WomanPuzzle = false;
    public Phone phone;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    combination = "";

        code.SetText(combination);
        if(combination.Length>password.Length)
        {
            combination = "";
        }
    }

    public void CloseWindow()
    {
        interactionsWithItems.OutFromKeyboard();
        //ResetCombination();
    }

    public void Button1()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '1';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button2()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '2';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button3()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '3';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button4()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '4';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button5()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '5';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button6()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '6';
        combination += number[i];
        i++;
        audioSource.Play();
    }

    public void Button7()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '7';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button8()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '8';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button9()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '9';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button0()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '0';
        combination += number[i];
        i++;
        audioSource.Play();
    }

    public void Enter()
    {
        if (combination.Equals(password) && is4WomanPuzzle==false)
        {
            SceneManager.LoadScene("Credits");
        }
        else if(combination.Equals(password) && is4WomanPuzzle)
        {
            phone.callId++;
            phone.Call(phone.callId);
            combination = "";
            number[0] = ' ';
            CloseWindow();
        }
        else if (!combination.Equals(password))
            ResetCombination();
        audioSource.Play();
    }

    public void ResetCombination()
    {
        if(is4WomanPuzzle==false)
        {
            i = 0;
            combination = "";
            number[0] = ' ';
            number[1] = ' ';
            number[2] = ' ';
            number[3] = ' ';
            number[4] = ' ';
            number[5] = ' ';
            number[6] = ' ';
            number[7] = ' ';
        }
        else if(is4WomanPuzzle==true)
        {
            i = 0;
            combination = "";
            number[0] = ' ';
        }
        audioSource.Play();
    }
}
