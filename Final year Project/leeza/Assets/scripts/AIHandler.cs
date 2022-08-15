using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;


public class AIHandler : MonoBehaviour
{
	public string[] commandList;  //Put commands here from within the inspector(As they are SPOKEN).
	public ConfidenceLevel confidence;

	//-----Audio-----
	public AudioClip[] ac;
	private AudioSource aso;

	protected PhraseRecognizer recognizer;
	protected string cmnd;

	public Text command, response;

    public GameObject NumpadGO;
    private string NumberText;
        
    public GameObject HomeGO;
    private bool HomeBool = true;

    public GameObject StopWatchGO;
    private bool StopWatchBool = false;
    private float counter = 0;

    public GameObject ConverterGO;
    private bool ConverterBool = false;
    public Text Amount;
    public Text Result;
    private string curr1, curr2;
    private bool curr1Listener = true;
    private bool curr2Listener = false;

    public GameObject CalculatorGO;
    private bool CalculatorBool = false;
    private bool OpcodeListener = false;
    private bool Op1Listener = false;
    private bool Op2Listener = false;
    //   private bool SignListener = false;    Not yet ready to handle signed numbers!
    private string op1Text, op2Text;
    private float op1, op2;
    private char sign, opcode;
    public Text Operand1Text;
    public Text Operand2Text;
    public Text OpcodeText;
    public Text AnswerText;
    public GameObject EqualsTo;

    private bool NumberListener = false;
    private float Number;

	private bool welcomeDone = false;

	public GameObject ttt;
	public Button[] tttb;
	public Button restartBtn;

	private void Start()
	{	
		
		aso = GetComponent<AudioSource> ();

		StartCoroutine (WLCM());

		if (commandList != null)
		{
			recognizer = new KeywordRecognizer(commandList, confidence);
			recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
			recognizer.Start();
		}

/*		else if(waso.isPlaying){
			recognizer = new KeywordRecognizer(commandList, confidence);
			recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
			recognizer.Start();
		}
*/
	}

	private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		cmnd = args.text;
		//command.text = "You : " + cmnd;
	}
	  
	private void Update()
	{
		if (!aso.isPlaying && welcomeDone) {
			if (HomeBool) {
				if (cmnd == "IntroduceYourself") {
					command.text = " You : Introduce Yourself";
					response.text = "I'm Leeza. Your virtual assistant";
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (1));
				}
				if (cmnd == "HiLeeza") {
					command.text = " You : Hi Leeza";
					response.text = "Hello, nice to meet you";
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (0));
				}
				if (cmnd == "YouAreAmazing") {
					command.text = " You : You are amazing";
					response.text = "Thank you so much";
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (6));
				}
				if (cmnd == "WhoDevelopedYou") {
					command.text = " You : Who developed you";
					response.text = "I was created by 4 students of G H Raisoni Institute of Engg. and Technology";
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (4));
				}
				if (cmnd == "WhoIsYourTeacherIncharge") {
					command.text = " You : Who is your teacher incharge";
					response.text = "I was developed under the guidance of Rohini Joshi Ma'am";
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (2));
				}
				if (cmnd == "CanYouNameYourDevelopers") {
					command.text = " You : Can you name your developers?";
					response.text = "Sakshi,Buddharatna and Supriya";
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (3));
				}
				if (cmnd == "WhatIsTheTime") {
					command.text = " You : What is the time?";
					response.text = System.DateTime.Now.ToShortTimeString ();
					cmnd = "";
				}
				if (cmnd == "OpenTicTacToe") {
					if(!ttt.activeInHierarchy){
						command.text = " You : Open Tic Tac Toe";
						ttt.SetActive (true);	
					}

					cmnd = "";
				}
				if (cmnd == "CloseTicTacToe") {
					if(ttt.activeInHierarchy){
						command.text = " You : Close Tic Tac Toe";
						ttt.SetActive (false);	
					}
					cmnd = "";
				}
				if (cmnd == "Quit") {
					command.text = " You : Quit";
					response.text = "Bye Bye!";
					Invoke ("QuitApp" , 3f);
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (3));
				}
				if (cmnd == "OpenWriter") {
					command.text = " You : Open Writer";
                    cmnd = "";
                    recognizer.Stop();
                    recognizer.Dispose();
                    PhraseRecognitionSystem.Shutdown();
                    SceneManager.LoadScene("scene2");
				}

				//===TTTgameCommands===
				if(ttt.activeInHierarchy){
					if (cmnd == "T1") {
						command.text = " You : T1";
						tttb [0].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "T2") {
						command.text = " You : T2";
						tttb [1].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "T3") {
						command.text = " You : T3";
						tttb [2].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "T4") {
						command.text = " You : T4";
						tttb [3].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "T5") {
						command.text = " You : T5";
						tttb [4].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "T6") {
						command.text = " You : T6";
						tttb [5].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "T7") {
						command.text = " You : T7";
						tttb [6].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "T8") {
						command.text = " You : T8";
						tttb [7].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "T9") {
						command.text = " You : T9";
						tttb [8].GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
					if (cmnd == "Restart") {
						command.text = " You : Restart";
						restartBtn.GetComponent<Button>().onClick.Invoke();
						cmnd = "";
					}
									
				}
				//========TTT^=============

				//All heavy audio files below------------------

				if (cmnd == "PlaySomethingJustLikeThis") {
					command.text = " You : Play Something Just Like This";
					response.text = "Now Playing";
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (7));
				}
				if (cmnd == "PlayEverythingIsAwesome") {
					command.text = " You : Play Everything Is Awesome";
					response.text = "Now Playing";
					cmnd = "";
					//AudioSupplier (1);
					StartCoroutine (AudioSupplier (8));
				}

				//All heavy audio files above------------------
	            
				if (cmnd == "Clear") {
					command.text = "You : Clear";
					response.text = "";
					cmnd = "";
				}

				if (cmnd == "StopWatch") {
					StopWatchMode ();
					command.text = "You : StopWatch";
					response.text = "StopWatch";
					cmnd = "";
				}

				if (cmnd == "Convert") {
					ConverterMode ();
					command.text = "You : Convert";
					response.text = "";
					cmnd = "";
				}

				if (cmnd == "Calculator") {
					CalculatorMode ();
					command.text = "You : Calculator";
					response.text = "";
					cmnd = "";
				}
			}

			if (StopWatchBool) {
				if (cmnd == "Start") {
					command.text = "You : Start";
					response.text = counter.ToString ("0.00");
					float f = Time.deltaTime;
					counter += f;
					//cmnd = "";    You will regret de-commenting this line! 
				}

				if (cmnd == "Stop") {
					command.text = "You : Stop";
					response.text = counter.ToString ("0.00");
					cmnd = "";
				}

				if (cmnd == "Set") {
					command.text = "You : Reset";
					counter = 0;
					response.text = counter.ToString ("0.00");
					cmnd = "";
				}

				if (cmnd == "Home") {
					HomeMode ();
					command.text = "You : Home";
					response.text = "";
					cmnd = "";
				}
			}

			if (ConverterBool) {

				if (cmnd == "Rupees") {
					command.text = "Rupees";
					NumberListener = false;
					Number = float.Parse (Amount.text);

					if (curr2Listener == true) {
						curr2Listener = false;
						curr2 = cmnd;
						Exchange ();
					}
					if (curr1Listener == true) {
						curr1Listener = false;
						curr1 = cmnd;
						curr2Listener = true;
					}
					cmnd = "";
				}

				if (cmnd == "Dollars") {
					command.text = "Dollars";
					NumberListener = false;
					Number = float.Parse (Amount.text);
					if (curr2Listener == true) {
						curr2Listener = false;
						curr2 = cmnd;
						Exchange ();
					}
					if (curr1Listener == true) {
						curr1Listener = false;
						curr1 = cmnd;
						curr2Listener = true;
					}
					cmnd = "";
				}

				if (cmnd == "Euros") {
					command.text = "Euros";
					NumberListener = false;
					Number = float.Parse (Amount.text);
					if (curr2Listener == true) {
						curr2Listener = false;
						curr2 = cmnd;
						Exchange ();
					}
					if (curr1Listener == true) {
						curr1Listener = false;
						curr1 = cmnd;
						curr2Listener = true;
					}
					cmnd = "";
				}

				if (cmnd == "Home") {
					cmnd = "";
					HomeMode ();
					command.text = "You : Home";
					response.text = "";
					Result.text = "";
					NumberText = "";
					curr1Listener = true;
					curr2Listener = false;
					NumberListener = false;
				}

				if (cmnd == "Set") {
					command.text = "You : Reset";
					NumberText = "";
					Result.text = "";
					curr1Listener = true;
					curr2Listener = false;
					NumberListener = false;
					ConverterMode ();
					cmnd = "";
				}

			}

			if (CalculatorBool) {
				if (Op2Listener == true) {
					op2Text = NumberText;
					Operand2Text.text = op2Text;

					if (cmnd == "Equals") {
						Op2Listener = false;
						op2 = float.Parse (op2Text);
						Calculate (op1, op2, opcode);
						cmnd = "";
						EqualsTo.SetActive (true);
					}
				}

				if (Op1Listener == true) {
					op1Text = NumberText;
					Operand1Text.text = op1Text;

					if (cmnd == "Plus" || cmnd == "Minus" || cmnd == "Multiply" || cmnd == "Divide") {
						Op1Listener = false;
						Op2Listener = true;
						op1 = float.Parse (op1Text);
						NumberText = "";
						// cmnd = "";
					}
				}

				if (cmnd == "Home") {
					cmnd = "";
					HomeMode ();
					command.text = "You : Home";
					response.text = "";
					NumberText = "";
					NumberListener = false;
				}

				if (cmnd == "Set") {
					command.text = "You : Reset";
					NumberText = "";
					NumberListener = false;
					CalculatorMode ();
					cmnd = "";
				}
			}

			if (OpcodeListener/* || SignListener*/) {
				if (cmnd == "Plus") {
					command.text = "+";
					cmnd = "";
					OpcodeListener = false;
					/*   if (SignListener)
	                    sign = "+";
	                else*/
					opcode = '+';
				}

				if (cmnd == "Minus") {
					command.text = "-";
					cmnd = "";
					OpcodeListener = false;
					/*  if (SignListener)
	                      sign = "-";
	                  else*/
					opcode = '-';
				}

				if (cmnd == "Multiply"/* && SignListener == false*/) {
					command.text = "x";
					cmnd = "";
					OpcodeListener = false;
					opcode = 'x';
				}

				if (cmnd == "Divide"/* && SignListener == false*/) {
					command.text = "÷";
					cmnd = "";
					OpcodeListener = false;
					opcode = '÷';
				}
	            
				if (CalculatorBool) {
					OpcodeText.text = System.Convert.ToString (opcode); 
				}
			}

			if (NumberListener) {
				if (cmnd == "0") {
					command.text = "0";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "1") {
					command.text = "1"; 
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "2") {
					command.text = "2";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "3") {
					command.text = "3";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "4") {
					command.text = "4";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "5") {
					command.text = "5";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "6") {
					command.text = "6";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "7") {
					command.text = "7";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "8") {
					command.text = "8";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "9") {
					command.text = "9";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (cmnd == "Point") {
					command.text = ".";
					cmnd = "";
					NumberText = NumberText + command.text;
				}

				if (ConverterBool) {
					Amount.text = NumberText;
				}
			}

		}

		else {
		//If song is playing then stop it

			if (cmnd == "Stop" && welcomeDone) {
				command.text = " You : Stop";
				response.text = "Stopped";
				aso.Stop ();
				cmnd = "";
				//AudioSupplier (1);
				//StartCoroutine (AudioSongSupplier (7));
			}
		
		}


    }

    public void Exchange() {
        float x;

        x = ExchangeRate(curr1, curr2) * Number;
        Result.text = System.Convert.ToString(x);
        command.text = "Converted! Amount = " + x;
    }

    public float ExchangeRate(string c1, string c2) {

        float er = 0f;

        if (c1 == "Rupees") {
            if (c2 == "Rupees")
                er = 1f;
            if (c2 == "Dollars")
                er = 0.013f;
            if (c2 == "Euros")
                er = 0.012f;
        }
        else if (c1 == "Dollars")
        {
            if (c2 == "Rupees")
                er = 76.23f;
            if (c2 == "Dollars")
                er = 1f;
            if (c2 == "Euros")
                er = 0.88f;
        }
        else if (c1 == "Euros")
        {
            if (c2 == "Rupees")
                er = 86.40f;
            if (c2 == "Dollars")
                er = 1.13f;
            if (c2 == "Euros")
                er = 1f;
        }
        
        return er;
    }

    public void Calculate(float a, float b, char o)
    {
        float Answer;

        switch (o)
        {
            case '+': Answer = a + b; break;
            case '-': Answer = a - b; break;
            case 'x': Answer = a * b; break;
            case '÷': Answer = a / b; break;
            default : Answer = 0f; break;
        }

        AnswerText.text = System.Convert.ToString(Answer);

        command.text = "Calculated! Answer = " + Answer;
    }

    public void StopWatchMode()
    {
        HomeBool = false;
        StopWatchBool = true;
        StopWatchGO.SetActive(true);
        HomeGO.SetActive(false);
        counter = 0;
    }

    public void ConverterMode()
    {
        HomeBool = false;
        ConverterBool = true;
        NumpadGO.SetActive(true);
        NumberListener = true;
        ConverterGO.SetActive(true);
        HomeGO.SetActive(false);
    }

    public void CalculatorMode()
    {
        HomeBool = false;
        Operand1Text.text = "";
        Operand2Text.text = "";
        OpcodeText.text = "";
        AnswerText.text = "";
        opcode = ' ';
        EqualsTo.SetActive(false);
        CalculatorBool = true;
        NumpadGO.SetActive(true);
       // SignListener = true;
        NumberListener = true;
        OpcodeListener = true;
        Op1Listener = true;
        Op2Listener = false;
        CalculatorGO.SetActive(true);
        HomeGO.SetActive(false);
    }

    public void HomeMode()
    {
        StopWatchBool = false;
        ConverterBool = false;
        CalculatorBool = false;
        StopWatchGO.SetActive(false);
        ConverterGO.SetActive(false);
        CalculatorGO.SetActive(false);
        NumpadGO.SetActive(false);
        HomeGO.SetActive(true);
        HomeBool = true;
        NumberListener = true;
    }

    public void buttons(string oo)
    {
        cmnd = oo;
    }

	public void QuitApp(){
		Application.Quit ();	
	}

    private void OnApplicationQuit()
	{
		if (recognizer != null && recognizer.IsRunning)
		{
			recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
			recognizer.Stop();
		}
	}

	IEnumerator AudioSupplier(int i){

		yield return new WaitForSeconds (0.5f);// parameter = delay time

		aso.clip = ac [i];
		aso.Play ();
	}

	IEnumerator WLCM(){
		response.text = "[   W E L C O M E   ]";
		yield return new WaitForSeconds (1f);
		command.text = "Initializing...Please wait";
		yield return new WaitForSeconds (1f);
		command.text = "Ready...";
		welcomeDone = true;
	}

	//===TEST===
	//REMOVE IT LATR

	//==========
}

/*-------------<NOTES>--------------
 * +RANDOM NUMBER GENERATOR+
 * Var = System.Convert.ToInt32(Random.Range(1f, 10f));
 * 
 * +TIME DISPLAY+
 * SomeText.text = System.DateTime.Now.ToShortTimeString();
 * 
*/