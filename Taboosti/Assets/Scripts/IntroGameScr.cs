using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroGameScr : MonoBehaviour
{
    public GameObject MainMenu, GameSelect, TeamSelect;
    public GameObject Team1, Team2, Team3, Team4;
    public GameObject PlayBtn, SettingsBtn, HowToPlayBtn, CreditsBtn;
    public GameObject WrongColorBtn;
    public GameObject Input1, Input2, Input3, Input4;
    string Team1Name, Team2Name, Team3Name, Team4Name;
    public Toggle[] TogglesRed, TogglesPink, TogglesPurple, TogglesBlue, TogglesBlueLight, TogglesCyan, TogglesGreen, TogglesYellow;   
    public Text PlayerSlTxt, TimerSlTxt, PassSlTxt, WordsSlTxt, RoundsSlTxt;
    public Slider PlayerSlider, TimerSlider, PassSlider, WordsSlider, RoundsSlider;
    public Toggle EasyTog, MediumTog, HardTog;
    public InputField TeamName1, TeamName2, TeamName3, TeamName4;
    public GameMechanicsScr GameMechanicsScr;
    public ToggleGroup toggleGroup1, toggleGroup2, toggleGroup3, toggleGroup4;
    int TongglesOn = 0;
    bool CanStart = true;
    Toggle ToggleTeam1, ToggleTeam2, ToggleTeam3, ToggleTeam4;
    //public Color TeamColor1, TeamColor2, TeamColor3, TeamColor4;
    void Start()
    {
        PlayerSlider.value = 2;
        TimerSlider.value = 60;
        PassSlider.value = 2;
        EasyTog.isOn = true;
        MediumTog.isOn = true;
        HardTog.isOn = true;
        WordsSlider.value = 5; 
        RoundsSlider.value = 3;
        Team1Name = "Ομάδα1";
        Team2Name = "Ομάδα2";
        Team3Name = "Ομάδα3";
        Team4Name = "Ομάδα4";

    }

    void Update()
    {        
        

        //Debug.Log("Team1 = "+ ToggleTeam1 + " Team2 = "+ ToggleTeam2 + " Team3 = "+ ToggleTeam3 + " Team4 = "+ ToggleTeam4);
        //Debug.Log(toggleGroup1.ActiveToggles());    
        //ColorBlock toggletest = TogglesRed[0].GetComponent<Toggle>().colors;

        if(!EasyTog.isOn && !MediumTog.isOn && !HardTog.isOn)
        {
            MediumTog.isOn = true;
        }
        PlayerSlTxt.text = "" + PlayerSlider.value;
        TimerSlTxt.text = "" + TimerSlider.value;
        PassSlTxt.text = "" + PassSlider.value; 
        WordsSlTxt.text = "" + WordsSlider.value;
        RoundsSlTxt.text = "" + RoundsSlider.value; 
    }
    public void ToTeamSelect()
    {    
        GameSelect.SetActive(false);
        TeamSelect.SetActive(true);
        
        Team1.SetActive(true);
        Team2.SetActive(true);

        TeamName1.characterLimit = 20;
        TeamName2.characterLimit = 20;
        if(PlayerSlider.value > 2)
        {
            Team3.SetActive(true);
            TeamName3.characterLimit = 20;
        }
        if(PlayerSlider.value > 3)
        {
            Team4.SetActive(true);
            TeamName4.characterLimit = 20;
        }
    }

    public void PreStartGame()
    {
        for(int i = 0; i < PlayerSlider.value; i++)
        {
            if(TogglesRed[i].isOn)
                TongglesOn++;

            if(TongglesOn >= 2)
                CanStart = false;
        }
        TongglesOn = 0;
        for(int i = 0; i < PlayerSlider.value; i++)
        {
            if(TogglesPink[i].isOn)
                TongglesOn++;

            if(TongglesOn >= 2)
                CanStart = false;
        }
        TongglesOn = 0;
        for(int i = 0; i < PlayerSlider.value; i++)
        {
            if(TogglesPurple[i].isOn)
                TongglesOn++;

            if(TongglesOn >= 2)
                CanStart = false;
        }
        TongglesOn = 0;
        for(int i = 0; i < PlayerSlider.value; i++)
        {
            if(TogglesBlue[i].isOn)
                TongglesOn++;

            if(TongglesOn >= 2)
                CanStart = false;
        }
        TongglesOn = 0;
        for(int i = 0; i < PlayerSlider.value; i++)
        {
            if(TogglesBlueLight[i].isOn)
                TongglesOn++;

            if(TongglesOn >= 2)
                CanStart = false;
        }
        TongglesOn = 0;
        for(int i = 0; i < PlayerSlider.value; i++)
        {
            if(TogglesCyan[i].isOn)
                TongglesOn++;

            if(TongglesOn >= 2)
                CanStart = false;
        }
        TongglesOn = 0;
        for(int i = 0; i < PlayerSlider.value; i++)
        {
            if(TogglesGreen[i].isOn)
                TongglesOn++;

            if(TongglesOn >= 2)
                CanStart = false;
        }
        TongglesOn = 0;
        for(int i = 0; i < PlayerSlider.value; i++)
        {
            if(TogglesYellow[i].isOn)
                TongglesOn++;

            if(TongglesOn >= 2)
                CanStart = false;
        }
        TongglesOn = 0;


        foreach (var toggle in toggleGroup1.ActiveToggles())
        {
            if(toggle.isOn)
            {
                ToggleTeam1 = toggle;
            }            
        }
        foreach (var toggle in toggleGroup2.ActiveToggles())
        {
            if(toggle.isOn)
            {
                ToggleTeam2 = toggle;
            }            
        }
        if(PlayerSlider.value > 2)
        {
            foreach (var toggle in toggleGroup3.ActiveToggles())
            {
                if(toggle.isOn)
                {
                    ToggleTeam3 = toggle;
                }            
            }
        }
        if(PlayerSlider.value > 3)
        {
            foreach (var toggle in toggleGroup4.ActiveToggles())
            {
                if(toggle.isOn)
                {
                    ToggleTeam4 = toggle;
                }            
            }
        }
        
        GameMechanicsScr.TeamColor1 = ToggleTeam1.GetComponent<Toggle>().colors.normalColor;  
        GameMechanicsScr.TeamColor2 = ToggleTeam2.GetComponent<Toggle>().colors.normalColor;  
        if(PlayerSlider.value > 2)
            GameMechanicsScr.TeamColor3 = ToggleTeam3.GetComponent<Toggle>().colors.normalColor;  
        if(PlayerSlider.value > 3)
            GameMechanicsScr.TeamColor4 = ToggleTeam4.GetComponent<Toggle>().colors.normalColor;      

        if(CanStart)
            StartGame(); 
        else
        {
            WrongColorBtn.SetActive(true);
            CanStart = true;
        }
        
    }

    public void StartGame()
    {
        
        GameMechanicsScr.Team1Name = Team1Name;
        GameMechanicsScr.Team2Name = Team2Name;
        GameMechanicsScr.Team3Name = Team3Name;
        GameMechanicsScr.Team4Name = Team4Name;


        GameMechanicsScr.TeamCount = PlayerSlider.value;
        GameMechanicsScr.TimerPick = TimerSlider.value;
        GameMechanicsScr.PassToLosePick = PassSlider.value; 
        GameMechanicsScr.WordsCount = WordsSlider.value;  
        GameMechanicsScr.RoundsCount = RoundsSlider.value;

        if(EasyTog.isOn)
            GameMechanicsScr.EasyCards = true;
        else
            GameMechanicsScr.EasyCards = false;
        if(MediumTog.isOn)
            GameMechanicsScr.MediumCards = true;
        else
            GameMechanicsScr.MediumCards = false;
        if(HardTog.isOn)
            GameMechanicsScr.HardCards = true;
        else
            GameMechanicsScr.HardCards = false;   
        
        SceneManager.LoadScene("MainGame");

    }   

    public void StoreName1()
    {
        Team1Name = Input1.GetComponent<Text>().text;
    }
    public void StoreName2()
    {
        Team2Name = Input2.GetComponent<Text>().text;
        //GameMechanicsScr.Teams.Add(GameMechanicsScr.Teams[1]);
    }
    public void StoreName3()
    {
        Team3Name = Input3.GetComponent<Text>().text;
        //GameMechanicsScr.Teams.Add(GameMechanicsScr.Teams[1]);
    }
    public void StoreName4()
    {
        Team4Name = Input4.GetComponent<Text>().text;
        //GameMechanicsScr.Teams.Add(GameMechanicsScr.Teams[1]);
    }
}
