using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMechanicsScr : MonoBehaviour
{
    public CardsTemp Cardstemp;
    public Text MainWord, NoWord1, NoWord2, NoWord3, NoWord4, NoWord5;
    public Text ScoreTxt, TimerTxt, BeforeRoundTxt, RoundTxt;
    public Text TeamScore, GameScore, WinningTeam, WinningKeimeno, TelikoGameScore, WinningTeamSpot1, WinningTeamSpot2, WinningTeamSpot3, WinningTeamSpot4;
    public Text TeamGameScore1, TeamGameScore2, TeamGameScore3, TeamGameScore4, FinalTeamGameScore1, FinalTeamGameScore2, FinalTeamGameScore3, FinalTeamGameScore4;
    public GameObject BeforeRound, Card, AfterRound, Finale;
    public GameObject PassObj, EndOfTimeObj;
    public GameObject NextRoundBtn, LastRoundBtn;
    public int RandomFirstTeam;
    public int Score, WinnerTeams; 
    int TeamToBeActive;
    public float Timer, TimerPick;
    public float PassToLose, PassToLoseLeft, PassToLosePick;
    public bool PreRoundBool, RoundBool, AfterRoundBool;
    public bool EndOfTimeBool, LastRound, RoundsAreOver;
    public int CurrentScore, TeamMaxScore, TeamToWin, TeamsWon;
    public float WordsCount;
    public float TeamCount;
    public float RoundsCount, RoundsSmallCount, RoundsCurrentCount, RoundsTotal;
    public IntroGameScr IntroGameScr;
    public List<CardsTemp> CardDeckAllCards = new List<CardsTemp>();
    public List<CardsTemp> CardDeck = new List<CardsTemp>();
    public List<string> Teams = new List<string>(); 
    public List<int> TeamsScore = new List<int>(); 
    public List<bool> TeamsAct = new List<bool>(); 
    public string Team1Name, Team2Name, Team3Name, Team4Name;
    public Color TeamColor1, TeamColor2, TeamColor3, TeamColor4;
    int EasyCards, MediumCards, HardCards;

    
    void Awake() 
    {
        Teams.Add(Team1Name);
        Teams.Add(Team2Name);
        TeamsAct.Add(false);
        TeamsAct.Add(false);
        TeamsScore.Add(0);
        TeamsScore.Add(0);
        
        if(TeamCount > 2)
        {
            Teams.Add(Team3Name);
            TeamsAct.Add(false);
            TeamsScore.Add(0);
        }
        if(TeamCount > 3)
        {
            Teams.Add(Team4Name); 
            TeamsAct.Add(false);
            TeamsScore.Add(0);
        } 
        
        /*for(int i=0; i<CardDeckEasy.Count; i++)
        {
           CardDeck.Add(CardDeckEasy[i]);
        } 
        for(int i=0; i<CardDeckMed.Count; i++)
        {
           CardDeck.Add(CardDeckMed[i]);
        } 
        for(int i=0; i<CardDeckHard.Count; i++)
        {
           CardDeck.Add(CardDeckHard[i]);
        } */
        
        for(int i=0; i<CardDeckAllCards.Count; i++)
        {
            if(CardDeckAllCards[i].difficulty == CardsTemp.Difficulty.medium)
            {
                CardDeck.Add(CardDeckAllCards[i]);
                MediumCards++;      
            }
            if(CardDeckAllCards[i].difficulty == CardsTemp.Difficulty.easy)
            {
                CardDeck.Add(CardDeckAllCards[i]);
                EasyCards++;      
            }
            if(CardDeckAllCards[i].difficulty == CardsTemp.Difficulty.hard)
            {
                CardDeck.Add(CardDeckAllCards[i]);
                HardCards++;      
            }
           //CarDeck.Add(CardDeckHard[i]);
        }
        Debug.Log("Easy: "+EasyCards + " Medium: "+ MediumCards + " Hard: "+HardCards);

        for(int i=0; i<CardDeck.Count; i++)
        {
           CardsTemp Obj = CardDeck[i];
           int RandomList = Random.Range(0, i);
           CardDeck[i] = CardDeck[RandomList];
           CardDeck[RandomList] = Obj;
        }  

        Cardstemp = CardDeck[0];
        MainWord.text = Cardstemp.MainWord;
        NoWord1.text = Cardstemp.NoWord1;
        NoWord2.text = Cardstemp.NoWord2;
        NoWord3.text = Cardstemp.NoWord3;
        if(WordsCount > 3)
            NoWord4.text = Cardstemp.NoWord4;
        else
            NoWord4.text = "";
        if(WordsCount > 4)
            NoWord5.text = Cardstemp.NoWord5;
        else
            NoWord5.text = "";

        RandomFirstTeam = Random.Range(0, Teams.Count);
        TeamsAct[RandomFirstTeam] = true;

        PreRoundBool = true;
        EndOfTimeBool = false;

    }
    void Start() 
    {
        //PassToLoseLeft = 0;
        PassToLose = PassToLosePick;
        Timer = TimerPick;
        RoundsSmallCount = 1; 
        RoundsCurrentCount = 1;
        RoundsAreOver = false;
        LastRound = false;
        RoundsTotal = TeamCount * RoundsCount;
        WinnerTeams = 0;
        TeamsWon = 0;

    }
    void Update()
    {
        //Debug.Log(RoundsSmallCount);
        if(Input.GetKeyDown(KeyCode.K))
        {

           /* for(int i=0; i<TeamsAct.Count; i++)
            {
                Debug.Log(TeamsAct[i]);
            }*/
            //Debug.Log(RoundsTotal);
        }


        if(PreRoundBool)
        {
            for(int i=0; i<TeamsAct.Count; i++)
            {
                if(TeamsAct[i])
                {
                    BeforeRoundTxt.text = Teams[i];
                    switch (i) 
                    {
                        case 0: BeforeRoundTxt.GetComponent<Text>().color = TeamColor1;
                        break;
                        case 1: BeforeRoundTxt.GetComponent<Text>().color = TeamColor2;
                        break;
                        case 2: BeforeRoundTxt.GetComponent<Text>().color = TeamColor3;
                        break;
                        case 3: BeforeRoundTxt.GetComponent<Text>().color = TeamColor4;
                        break;
                    }                    
                }
            }
            RoundTxt.text = "Γύρος " + RoundsCurrentCount;

        }
        
        if(RoundBool)
        {
            if(Timer > 0)
            {
                Timer -= 1 * Time.deltaTime;
                TimerTxt.text = Timer.ToString("0");
            }
            else
            {
                TimerTxt.text = "Τέλος Χρόνου";
                RoundBool = false;
                //Play Sound
                
                PassObj.SetActive(false);
                EndOfTimeObj.SetActive(true);
                EndOfTimeBool = true;
                //End Turn
            }    
                
            for(int i=0; i<TeamsAct.Count; i++)
            {
                if(TeamsAct[i])
                {
                    ScoreTxt.text = "Πόντους: " + CurrentScore;
                }
            }
        }

        if(AfterRoundBool)
        {
            if(!RoundsAreOver)
            {
                for(int i=0; i<TeamsAct.Count; i++)
                {
                    if(TeamsAct[i])
                    {
                        TeamScore.text = "Η ομάδα " + Teams[i] + " μάζεψε " + CurrentScore + " πόντους";
                        switch (i) 
                        {
                            case 0: TeamScore.GetComponent<Text>().color = TeamColor1;
                            break;
                            case 1: TeamScore.GetComponent<Text>().color = TeamColor2;
                            break;
                            case 2: TeamScore.GetComponent<Text>().color = TeamColor3;
                            break;
                            case 3: TeamScore.GetComponent<Text>().color = TeamColor4;
                            break;
                        }       
                    }
                }
                
                TeamGameScore1.text = Teams[0] + " : " + TeamsScore[0];
                TeamGameScore1.GetComponent<Text>().color = TeamColor1;
                TeamGameScore2.text = Teams[1] + " : " + TeamsScore[1];
                TeamGameScore2.GetComponent<Text>().color = TeamColor2;
                TeamGameScore3.text = " ";
                TeamGameScore4.text = " ";
                
                if(Teams.Count > 2)
                {
                    TeamGameScore3.text = Teams[2] + " : " + TeamsScore[2];
                    TeamGameScore3.GetComponent<Text>().color = TeamColor3;
                    //GameScore.text = Teams[0] + " : " + TeamsScore[0] + "\n" + Teams[1] + " : " + TeamsScore[1] + "\n" + Teams[2] + " : " + TeamsScore[2];   
                }
                if(Teams.Count > 3)
                {
                    TeamGameScore4.text = Teams[3] + " : " + TeamsScore[3];
                    TeamGameScore4.GetComponent<Text>().color = TeamColor4;
                    //GameScore.text = Teams[0] + " : " + TeamsScore[0] + "\n" + Teams[1] + " : " + TeamsScore[1] + "\n" + Teams[2] + " : " + TeamsScore[2]+ "\n" + Teams[3] + " : " + TeamsScore[3];
                }
            }
         }
    }

    public void NextCard()
    {
        CurrentScore += 1;
        
        if(!EndOfTimeBool)
            NewCard();
        else
            EndOfTimeBtn(); 
    }
    public void WrongWord()
    {
        if(CurrentScore>0)
            CurrentScore -= 1;

        if(!EndOfTimeBool)
            NewCard();
        else
            EndOfTimeBtn(); 
    }
    public void Pass()
    { 
        if(CurrentScore>0)
        {
            if(PassToLoseLeft >= PassToLose)
                CurrentScore -= 1;
            else
                PassToLoseLeft++;
        }
    
        if(!EndOfTimeBool)
            NewCard();
        else
            EndOfTimeBtn(); 
    }
    public void StartFromPreRound()
    {
        BeforeRound.SetActive(false);
        Card.SetActive(true);
        PreRoundBool = false;
        RoundBool = true;
    }
    public void ExitGame()
    {
        PreRoundBool = false;
        RoundBool = false;
        AfterRoundBool = false;
        SceneManager.LoadScene("IntroGame");
    }
    public void EndOfTimeBtn()
    {
        if(RoundsSmallCount < TeamCount)
            RoundsSmallCount++; 
        else
        {
            if(RoundsCurrentCount < RoundsCount)
            {
                RoundsCurrentCount++;
                RoundsSmallCount = 1;
            }
            else
            {
                RoundsAreOver = true;
            }
        }  
        RoundsTotal--;  
        if(RoundsCurrentCount == RoundsCount)
            LastRound = true;
        

        if(RoundsTotal > 0)
            GoToAfterRound();
        else
            GoToEndOfGame();
    }
    public void GoToAfterRound()
    {
        PassObj.SetActive(true);
        EndOfTimeObj.SetActive(false);
        RoundBool = false;
        AfterRoundBool = true;
        for(int i=0; i<TeamsAct.Count; i++)
            {
                if(TeamsAct[i])
                {
                    TeamsScore[i] += CurrentScore;
                }
            }

        EndOfTimeBool = false;
        PassToLoseLeft = 0;
        Timer = TimerPick;

        if(LastRound)
        {
            LastRoundBtn.SetActive(true);
            NextRoundBtn.SetActive(false);
        }
        
        Card.SetActive(false);
        AfterRound.SetActive(true);
    }

    public void GoToBeforeRound()
    {
        AfterRoundBool = false;
        PreRoundBool = true;
        
        for(int i=0; i<TeamsAct.Count; i++)
            {
                if(TeamsAct[i])
                {
                    TeamsAct[i] = false;
                    TeamToBeActive = i;
                }
            }
        if(TeamToBeActive < TeamsAct.Count-1)
            TeamsAct[TeamToBeActive+1] = true;
        else
            TeamsAct[0] = true;

        CurrentScore = 0;

        AfterRound.SetActive(false);
        BeforeRound.SetActive(true);
    }

    void NewCard()
    {
        CardDeck.Remove(CardDeck[0]);

        Cardstemp = CardDeck[0];
        MainWord.text = Cardstemp.MainWord;
        NoWord1.text = Cardstemp.NoWord1;
        NoWord2.text = Cardstemp.NoWord2;
        NoWord3.text = Cardstemp.NoWord3;
        if(WordsCount > 3)
            NoWord4.text = Cardstemp.NoWord4;
        else
            NoWord4.text = "";
        if(WordsCount > 4)
            NoWord5.text = Cardstemp.NoWord5;
        else
            NoWord5.text = "";
    }
    public void GoToEndOfGame()
    {        
        PassObj.SetActive(true);
        EndOfTimeObj.SetActive(false);
        RoundBool = false;
        AfterRoundBool = true;
        
        WinningTeamSpot1.text = "";
        WinningTeamSpot2.text = "";
        WinningTeamSpot3.text = "";
        WinningTeamSpot4.text = "";

        for(int i=0; i<TeamsAct.Count; i++)
            {
                if(TeamsAct[i])
                {
                    TeamsScore[i] += CurrentScore;
                }
            }
        
        if(Teams.Count == 2)
            {
                TeamMaxScore = Mathf.Max(TeamsScore[0], TeamsScore[1]);
            }
        if(Teams.Count == 3)
            {
                TeamMaxScore = Mathf.Max(TeamsScore[0], TeamsScore[1],TeamsScore[2]);   
            }
        if(Teams.Count == 4)
            {
                TeamMaxScore = Mathf.Max(TeamsScore[0], TeamsScore[1],TeamsScore[2],TeamsScore[3]);
            }
        for(int i=0; i<TeamsAct.Count; i++)
            {
                if(TeamsScore[i] == TeamMaxScore)
                {
                    TeamToWin = i; 
                    WinnerTeams ++;
                }
            }
        FinalTeamGameScore1.text = Teams[0] + " : " + TeamsScore[0];
        FinalTeamGameScore1.GetComponent<Text>().color = TeamColor1;
        FinalTeamGameScore2.text = Teams[1] + " : " + TeamsScore[1];
        FinalTeamGameScore2.GetComponent<Text>().color = TeamColor2;
        FinalTeamGameScore3.text = " ";
        FinalTeamGameScore4.text = " ";
        
        if(Teams.Count > 2)
        {
            FinalTeamGameScore3.text = Teams[2] + " : " + TeamsScore[2];
            FinalTeamGameScore3.GetComponent<Text>().color = TeamColor3;
            //GameScore.text = Teams[0] + " : " + TeamsScore[0] + "\n" + Teams[1] + " : " + TeamsScore[1] + "\n" + Teams[2] + " : " + TeamsScore[2];   
        }
        if(Teams.Count > 3)
        {
            FinalTeamGameScore4.text = Teams[3] + " : " + TeamsScore[3];
            FinalTeamGameScore4.GetComponent<Text>().color = TeamColor4;
            //GameScore.text = Teams[0] + " : " + TeamsScore[0] + "\n" + Teams[1] + " : " + TeamsScore[1] + "\n" + Teams[2] + " : " + TeamsScore[2]+ "\n" + Teams[3] + " : " + TeamsScore[3];
        }

        if(WinnerTeams<2)
        {
            WinningKeimeno.text = "Οι Taboosth νικητές είναι οι"; 
            WinningTeam.text = Teams[TeamToWin];   

        switch (TeamToWin) 
        {
            case 0: WinningTeam.GetComponent<Text>().color = TeamColor1;
            break;
            case 1: WinningTeam.GetComponent<Text>().color = TeamColor2;
            break;
            case 2: WinningTeam.GetComponent<Text>().color = TeamColor3;
            break;
            case 3: WinningTeam.GetComponent<Text>().color = TeamColor4;
            break;
        }       
                      
        }
        else
        {
            WinningKeimeno.text = "Οι Taboosth νικητές με ισοπαλία είναι οι"; 

            for(int i=0; i<TeamsAct.Count; i++)
            {
                if(TeamsScore[i] == TeamMaxScore)
                {
                    TeamsWon++;
                    switch (TeamsWon) 
                    {   
                        case 1: WinningTeamSpot1.text = Teams[i];
                            switch (i) 
                            {
                                case 0: WinningTeamSpot1.GetComponent<Text>().color = TeamColor1;
                                break;
                                case 1: WinningTeamSpot1.GetComponent<Text>().color = TeamColor2;
                                break;
                                case 2: WinningTeamSpot1.GetComponent<Text>().color = TeamColor3;
                                break;
                                case 3: WinningTeamSpot1.GetComponent<Text>().color = TeamColor4;
                                break;
                            }       
                        break;
                        case 2: WinningTeamSpot2.text = Teams[i];
                            switch (i) 
                                {
                                    case 0: WinningTeamSpot2.GetComponent<Text>().color = TeamColor1;
                                    break;
                                    case 1: WinningTeamSpot2.GetComponent<Text>().color = TeamColor2;
                                    break;
                                    case 2: WinningTeamSpot2.GetComponent<Text>().color = TeamColor3;
                                    break;
                                    case 3: WinningTeamSpot2.GetComponent<Text>().color = TeamColor4;
                                    break;
                                }    
                        break;
                        case 3: WinningTeamSpot3.text = Teams[i];
                            switch (i) 
                            {
                                case 0: WinningTeamSpot3.GetComponent<Text>().color = TeamColor1;
                                break;
                                case 1: WinningTeamSpot3.GetComponent<Text>().color = TeamColor2;
                                break;
                                case 2: WinningTeamSpot3.GetComponent<Text>().color = TeamColor3;
                                break;
                                case 3: WinningTeamSpot3.GetComponent<Text>().color = TeamColor4;
                                break;
                            }    
                        break;
                        case 4: WinningTeamSpot4.text = Teams[i];
                            switch (i) 
                            {
                                case 0: WinningTeamSpot4.GetComponent<Text>().color = TeamColor1;
                                break;
                                case 1: WinningTeamSpot4.GetComponent<Text>().color = TeamColor2;
                                break;
                                case 2: WinningTeamSpot4.GetComponent<Text>().color = TeamColor3;
                                break;
                                case 3: WinningTeamSpot4.GetComponent<Text>().color = TeamColor4;
                                break;
                            }    
                        break;
                    }
                }
            }
        }
            

        EndOfTimeBool = false;
        PassToLoseLeft = 0;
        Timer = TimerPick;

        NextRoundBtn.SetActive(false);
        Card.SetActive(false);
        Finale.SetActive(true);

    }
    
}
