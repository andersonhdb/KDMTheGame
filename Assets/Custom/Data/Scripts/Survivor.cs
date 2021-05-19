using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Survivor
{
    /*
     * Raw Data
     */
    //Descriptive
    private string name;
    private string nickname;
    private string familyName;
    private bool isMale;

    //resources
    private int survival;

    //stats
    private int movement;
    private int strength;
    private int accuracy;
    private int evasion;
    private int luck;
    private int speed;

    //Temporary modifiers
    private int movMod;
    private int strMod;
    private int accMod;
    private int evaMod;
    private int lckMod;
    private int spdMod;

    //experience & thresholds:
    private int experience;
    private int proficiencyLevel;
    private int courage;
    private int understanding;

    //private WeaponProficiency weaponProficiency
    private bool isKnockedDown;

    //hit points
    private int insanity;
    private int headHP;
    private int armsHP;
    private int bodyHP;
    private int waistHP;
    private int legsHP;

    private int bleedingPoints;
    private int bleedingLimit;

    //Fighting Arts
    private FightingArt[] fightingArts = new FightingArt[3];
    private Disorder[] disorders = new Disorder[3];

    private List<AbilitiesAndIpairments> abilitiesAndIpairments;

    //Methods
    //Constructors
    public Survivor()
    {
        name = "";
        nickname = "";
        familyName = "";
        isMale = false;
        survival = 0;
        
        movement = 5;
        strength = 0;
        accuracy = 0;
        evasion = 0;
        luck = 0;
        speed = 0;

        movMod = 0;
        strMod = 0;
        accMod = 0;
        evaMod = 0;
        lckMod = 0;
        spdMod = 0;

        experience = 0;
        proficiencyLevel = 0;
        courage = 0;
        understanding = 0;

        isKnockedDown = false;

        insanity = 1;
        headHP = 1;
        armsHP = 2;
        bodyHP = 2;
        waistHP = 2;
        legsHP = 2;

        bleedingPoints = 0;
        bleedingLimit = 5;
    }

    public Survivor(string name, bool isMale)
    {
        this.name = name;
        nickname = "";
        familyName = "";
        this.isMale = isMale;
        if(name != string.Empty)
        {
            survival = 1;
        }
        else
        {
            survival = 0;
        }

        movement = 5;
        strength = 0;
        accuracy = 0;
        evasion = 0;
        luck = 0;
        speed = 0;

        movMod = 0;
        strMod = 0;
        accMod = 0;
        evaMod = 0;
        lckMod = 0;
        spdMod = 0;

        experience = 0;
        proficiencyLevel = 0;
        courage = 0;
        understanding = 0;

        isKnockedDown = false;

        insanity = 1;
        headHP = 1;
        armsHP = 2;
        bodyHP = 2;
        waistHP = 2;
        legsHP = 2;

        bleedingPoints = 0;
        bleedingLimit = 5;
    }

    public Survivor(string name, bool isMale, int movement, int strength, int accuracy, int evasion, int luck, int speed)
    {
        this.name = name;
        nickname = "";
        familyName = "";
        this.isMale = isMale;
        if (name != string.Empty)
        {
            survival = 1;
        }
        else
        {
            survival = 0;
        }

        this.movement = movement;
        this.strength = strength;
        this.accuracy = accuracy;
        this.evasion = evasion;
        this.luck = luck;
        this.speed = speed;

        movMod = 0;
        strMod = 0;
        accMod = 0;
        evaMod = 0;
        lckMod = 0;
        spdMod = 0;

        experience = 0;
        proficiencyLevel = 0;
        courage = 0;
        understanding = 0;

        isKnockedDown = false;

        insanity = 1;
        headHP = 1;
        armsHP = 2;
        bodyHP = 2;
        waistHP = 2;
        legsHP = 2;

        bleedingPoints = 0;
        bleedingLimit = 5;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetFamilyName(string familyName)
    {
        this.familyName = familyName;
    }

    public void SetNickname(string nickName)
    {
        this.nickname = nickName;
    }

    public string GetFullName()
    {
        if(nickname!= string.Empty)
        {
            return name + ", " + nickname + ", " + familyName;
        }
        return name + familyName;
    }

    public string GetName()
    {
        return name;
    }

    public void ClearMods()
    {
        movMod = 0;
        strMod = 0;
        accMod = 0;
        evaMod = 0;
        lckMod = 0;
        spdMod = 0;
    }

    public void UpdateMovement(int value)
    {
        this.movement += value;
        if (movement < 0)
        {
            movement = 0;
        }
    }

    public void UpdateStrength(int value)
    {
        this.strength += value;
        if (strength < 0)
        {
            strength = 0;
        }
    }

    public void UpdateAccuray(int value)
    {
        this.accuracy +=value;
        if (accuracy < 0)
        {
            accuracy = 0;
        }
    }

    public void UpdateLuck(int value)
    {
        this.luck += value;
        if(this.luck < 0)
        {
            luck = 0;
        }
    }

    public void UpdateSpeed(int value)
    {
        this.speed += value;
        if (this.speed < 0)
        {
            speed = 0;
        }
    }

    public void HealAllInjuries()
    {
        if (this.insanity == 0)
        {
            insanity = 1;
        }
        if (this.headHP == 0)
        {
            headHP = 1;
        }
        if (this.armsHP < 2)
        {
            armsHP = 2;
        }
        if (this.bodyHP < 2)
        {
            bodyHP = 2;
        }
        if (this.waistHP < 2)
        {
            waistHP = 2;
        }
        if(this.legsHP < 2)
        {
            legsHP = 2;
        }
        bleedingPoints = 0;
    }

    public void HitInsanity()
    {
        insanity--;
        if (insanity < 0)
        {
            insanity = 0;
            //Insanity Table
        }
    }

    public void HitHead()
    {
        headHP--;
        if(headHP == 0)
        {
            KnockDown();
        }
        else if (headHP < 0)
        {
            headHP = 0;
            //Head Injury Table
        }
    }

    public void HitArms()
    {
        armsHP--;
        if(armsHP == 0)
        {
            KnockDown();
        }
        else if(armsHP < 0)
        {
            armsHP = 0;
            //arms Inkury Table
        }
    }

    public void HitBody()
    {
        bodyHP--;
        if (bodyHP == 0)
        {
            KnockDown();
        }else if (bodyHP < 0)
        {
            bodyHP = 0;
            //Body Injury Table
        }
    }

    public void HitWaist()
    {
        waistHP--;
        if(waistHP == 0)
        {
            KnockDown();
        }else if (waistHP < 0)
        {
            waistHP = 0;
            //Waist Injury Table
        }
    }

    public void HitLegs()
    {
        legsHP--;
        if (legsHP == 0)
        {
            KnockDown();
        }else if (legsHP < 0)
        {
            legsHP = 0;
            //legs Injury Table
        }
    }

    public bool IsKnockedDown()
    {
        return this.isKnockedDown;
    }

    public void KnockDown()
    {
        isKnockedDown = true;
    }

    public void StandUp()
    {
        isKnockedDown = false;
    }

}

[System.Serializable]
public class FightingArt:ScriptableObject
{

}

[System.Serializable]
public class Disorder:ScriptableObject
{

}

[System.Serializable]
public class AbilitiesAndIpairments:ScriptableObject
{

}

