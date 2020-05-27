using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private int level;
    private int maxHP;
    private int hp;
    private int atk;
    private int spd;
    private int dodge;
    private int critical;
    private int skill;
    private int nextEXP;
    private int nowEXP;
    private int kurikoshi;

    private int pwr;

    private bool allowedAction = false;
    private bool isTurned = false;
    private bool nowActive = false;
    private bool mitokorogiriAction = false;
    private bool backAttacking = false;

    private bool defanceMode = false;
    private bool charging = false;
    private bool expDirecting = false;


    public int Level { get => level; set => level = value; }
    public int MaxHP { get => maxHP; set => maxHP = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Atk { get => atk; set => atk = value; }
    public int Spd { get => spd; set => spd = value; }
    public int Dodge { get => dodge; set => dodge = value; }
    public int Critical { get => critical; set => critical = value; }
    public int Skill { get => skill; set => skill = value; }
    public int NextEXP { get => nextEXP; set => nextEXP = value; }
    public int NowEXP { get => nowEXP; set => nowEXP = value; }
    public int Kurikoshi { get => kurikoshi; set => kurikoshi = value; }
    public int Pwr { get => pwr; set => pwr = value; }
    public bool AllowedAction { get => allowedAction; set => allowedAction = value; }
    public bool IsTurned { get => isTurned; set => isTurned = value; }
    public bool NowActive { get => nowActive; set => nowActive = value; }
    public bool MitokorogiriAction { get => mitokorogiriAction; set => mitokorogiriAction = value; }
    public bool BackAttacking { get => backAttacking; set => backAttacking = value; }
    public bool DefanceMode { get => defanceMode; set => defanceMode = value; }
    public bool Charging { get => charging; set => charging = value; }
    public bool ExpDirecting { get => expDirecting; set => expDirecting = value; }

    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public void Init_PlayerParameter()
    {
        this.MaxHP = Level_ParameterManager.playerLevel[this.Level - 1, 1];
        this.Hp = Level_ParameterManager.playerLevel[this.Level - 1, 2];
        this.Atk = Level_ParameterManager.playerLevel[this.Level - 1, 3];
        this.Spd = Level_ParameterManager.playerLevel[this.Level - 1, 4];
        this.Dodge = Level_ParameterManager.playerLevel[this.Level - 1, 5];
        this.Critical = Level_ParameterManager.playerLevel[this.Level - 1, 6];
        this.Skill = Level_ParameterManager.playerLevel[this.Level - 1, 7];
        this.NextEXP = Level_ParameterManager.playerLevel[this.Level - 1, 8];
        this.nowEXP = Level_ParameterManager.playerLevel[this.Level - 1, 9];

        this.Pwr = 0;
    }
}
