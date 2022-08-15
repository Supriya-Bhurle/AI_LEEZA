using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class AI2Handler : MonoBehaviour
{

    public string[] commandList2;
    public ConfidenceLevel confidence;
    //protected PhraseRecognizer recognizer;
    protected string cmnd;
    public Text command, response;

    //===Dicktation===
    DictationRecognizer _dictationRecognizer;

    //================
    private string strng;

    private void Awake()
    {
        _dictationRecognizer = new DictationRecognizer();

        _dictationRecognizer.DictationHypothesis += _dictationRecognizer_DictationHypothesis;

        _dictationRecognizer.DictationResult += _dictationRecognizer_DictationResult;

        _dictationRecognizer.DictationComplete += _dictationRecognizer_DictationComplete;

        _dictationRecognizer.Start();
    }

    void _dictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        _dictationRecognizer.Stop();
    }

    void _dictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        response.text = text;
        command.text = ". . .";
        strng = text;
    }

    void _dictationRecognizer_DictationHypothesis(string text)
    {
        command.text = ". . .";
    }

    private void Start()
    {
        /*		
                if (commandList2 != null){
                    recognizer = new KeywordRecognizer (commandList2, confidence);
                    recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
                    recognizer.Start ();
                }
                _dictationRecognizer.Start ();
        */
    }
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        cmnd = args.text;
    }
    private void Update()
    {
        if (strng == "close")
        {
            command.text = " You : Quit Writer";
            Invoke("ChangeScene", 3f);
            cmnd = "";
        }
    }
    /*	private void OnApplicationQuit(){
            if (recognizer != null && recognizer.IsRunning)
            {
                recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
                recognizer.Stop();
            }
        }
    */
    void ChangeScene()
    {
        _dictationRecognizer.Stop();
        SceneManager.LoadScene("scene1");
    }


}
