using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] ButtonList;
	private string playerSide;
	private string computerSide;
	public Text gameOverText; 
	int moveCount;

	public bool playerMove;
	public float delay;
	private int value;
	public GameObject restartButton;

	void Awake(){
		gameOverText.text = " ";
		SetGameControllerReferenceOnButtons ();
		playerSide = "x";
		computerSide = "o";
		moveCount = 0;
		restartButton.SetActive (false);
		playerMove = true;
	}

	void Update(){
		if(playerMove == false){
			delay += delay * Time.deltaTime;
			if(delay>=100){
				value = Random.Range (0,8);
				if(ButtonList[value].GetComponentInParent<Button>().interactable==true){
					ButtonList[value].text = GetComputerSide();
					ButtonList [value].GetComponentInParent<Button> ().interactable = false;
					EndTurn ();
				}

			}

		}

	}


	void SetGameControllerReferenceOnButtons(){

		for(int i=0 ; i<ButtonList.Length ; i++){
			ButtonList[i].GetComponentInParent<TTTHandler>().SetGameControllerReference(this);
		}
	}

	public void SetStartingSide(string startingSide){
		playerSide = startingSide;
		if (playerSide == "x") {
			computerSide = "o";
		}
		else {
			computerSide = "x";
		}
	}

	public string GetPlayerSide(){
		return playerSide;
	}
	public string GetComputerSide(){
		return computerSide;
	}
	public void EndTurn(){

		moveCount++;

		if(ButtonList[0].text == playerSide && ButtonList[1].text == playerSide && ButtonList[2].text == playerSide){
			GameOver(playerSide);
		}
		else if(ButtonList[3].text == playerSide && ButtonList[4].text == playerSide && ButtonList[5].text == playerSide){
			GameOver(playerSide);
		}
		else if(ButtonList[6].text == playerSide && ButtonList[7].text == playerSide && ButtonList[8].text == playerSide){
			GameOver(playerSide);
		}
		else if(ButtonList[0].text == playerSide && ButtonList[3].text == playerSide && ButtonList[6].text == playerSide){
			GameOver(playerSide);
		}
		else if(ButtonList[1].text == playerSide && ButtonList[4].text == playerSide && ButtonList[7].text == playerSide){
			GameOver(playerSide);
		}
		else if(ButtonList[2].text == playerSide && ButtonList[5].text == playerSide && ButtonList[8].text == playerSide){
			GameOver(playerSide);
		}
		else if(ButtonList[0].text == playerSide && ButtonList[4].text == playerSide && ButtonList[8].text == playerSide){
			GameOver(playerSide);
		}
		else if(ButtonList[2].text == playerSide && ButtonList[4].text == playerSide && ButtonList[6].text == playerSide){
			GameOver(playerSide);
		}

		if (ButtonList [0].text == computerSide && ButtonList [1].text == computerSide && ButtonList [2].text == computerSide) {
			GameOver (computerSide);
		} else if (ButtonList [3].text == computerSide && ButtonList [4].text == computerSide && ButtonList [5].text == computerSide) {
			GameOver (computerSide);
		} else if (ButtonList [6].text == computerSide && ButtonList [7].text == computerSide && ButtonList [8].text == computerSide) {
			GameOver (computerSide);
		} else if (ButtonList [0].text == computerSide && ButtonList [3].text == computerSide && ButtonList [6].text == computerSide) {
			GameOver (computerSide);
		} else if (ButtonList [1].text == computerSide && ButtonList [4].text == computerSide && ButtonList [7].text == computerSide) {
			GameOver (computerSide);
		} else if (ButtonList [2].text == computerSide && ButtonList [5].text == computerSide && ButtonList [8].text == computerSide) {
			GameOver (computerSide);
		} else if (ButtonList [0].text == computerSide && ButtonList [4].text == computerSide && ButtonList [8].text == computerSide) {
			GameOver (computerSide);
		} else if (ButtonList [2].text == computerSide && ButtonList [4].text == computerSide && ButtonList [6].text == computerSide) {
			GameOver (computerSide);
		} else if (moveCount >= 9) {
			GameOver ("draw");
		} else {
			ChangeSides ();
			delay = 10;
		}
	}

	void GameOver(string winningPlayer){
		SetBoardInteractable (false);
		if (winningPlayer == "draw") {
			SetGameOverText ("Draw!!");
		} 
		else {
			SetGameOverText(winningPlayer + " Wins!");
		}
		restartButton.SetActive (true);

	}

	void ChangeSides(){
		//playerSide = (playerSide == "x") ? "o" : "x";
		playerMove = (playerMove == true) ? false : true;

	}

	void SetGameOverText(string value){
		gameOverText.text = value;
	}

	public void RestartGame(){
		gameOverText.text = " ";
		playerSide = "x";
		moveCount = 0;
		playerMove = true;
		delay = 10;
		SetBoardInteractable (true);

		for(int i=0 ; i<ButtonList.Length ; i++){
			ButtonList [i].text = "";
		}
		restartButton.SetActive (false);

	}

	void SetBoardInteractable(bool toggle){
		for (int i = 0; i < ButtonList.Length; i++) {
			ButtonList [i].GetComponentInParent<Button> ().interactable = toggle;
		}
	}
}
 