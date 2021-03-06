﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Talent_Tree;

    [SerializeField] private Button Btn_Paw;
    [SerializeField] private Button Btn_Bullet;
    [SerializeField] private Button Btn_Gun;
    [SerializeField] private Button Btn_Nuclear;
    [SerializeField] private Button Btn_Gear;
    [SerializeField] private Button Btn_Cross;
    [SerializeField] private Button Btn_Egg;
    [SerializeField] private Text SkillPoints;
    [SerializeField] private Text Skill_Alert;
    [SerializeField] private Text Grenade_Counter;

    public PlayerController player;
    public GameObject gren1;
    public GameObject gren2;
    public GameObject gren3;
    

    private bool tier1, tier2, tier3, tier4, tier5;
    public 
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        tier1 = false;
        tier2 = false;
        tier3 = false;
        tier4 = false;
        tier5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        SkillPoints.text = "Skill Points: "+player.skillPoints+"";
        if (player.skillPoints > 0)
        {
            Skill_Alert.text = "You have " + player.skillPoints + " skill points\nPress Tab to Open Skill Tree";
            Skill_Alert.gameObject.SetActive(true);
        }
        else
            Skill_Alert.gameObject.SetActive(false);
        Grenade_Counter.text = "Grenades: "+player.grenadeCount+"";
    }
    //First Tier
    public void pawButton()
    {
        if (tier1 == false && player.skillPoints > 0)
        {
            print("Paw Button");
            player.moveSpeed = 13;
            tier1 = true;
            GameObject button = GameObject.Find("Paw_Button");
            Btn_Paw.image.color = Color.yellow;
            player.skillPoints--;

        }
        else
            print("Not allowed Button");
    }
    //Second Tier
    public void bulletButton()
    {
        if (tier1 == true && tier2 == false && player.skillPoints > 0)
        {
            print("BulletButton");
            tier2 = true;
            player.bulletSpeedMod += .4f;
            if (player.gun != null)
                player.gun.bulletSpeed *= player.bulletSpeedMod;
            Btn_Bullet.image.color = Color.yellow;
            player.skillPoints--;
        }
        else
            print("Not allowed Button");
    }
    public void gunButton()
    {
        if (tier1 == true && tier2 == false && player.skillPoints > 0)
        {
            print("Gun Button");
            tier2 = true;
            player.fireRateMod *= .8f;
            if(player.gun != null)
                player.gun.fireRate *= player.fireRateMod;
            Btn_Gun.image.color = Color.yellow;
            player.skillPoints--;
        }
        else
            print("Not allowed Button");
    }
    //Third Tier
    public void nuclearButton()
    {
        if (tier2 == true && tier3 == false && player.skillPoints > 0)
        {
            print("Nuke Button");
            tier3 = true;
            player.grenadeType = gren2;
            Btn_Nuclear.image.color = Color.yellow;
            player.skillPoints--;
        }
        else
            print("Not allowed Button");
    }
    //Fourth Tier
    public void gearButton()
    {
        if (tier3 == true && tier4 == false && player.skillPoints > 0)
        {
            print("Gear Button");
            tier4 = true;
            player.fireRateMod *= .8f;
            if (player.gun != null)
                player.gun.fireRate *= player.fireRateMod;
            Btn_Gear.image.color = Color.yellow;
            player.skillPoints--;
        }
        else
            print("Not allowed Button");
    }
    public void crosshairButton()
    {
        if (tier3 == true && tier4 == false && player.skillPoints > 0)
        {
            print("cross Button");
            tier4 = true;
            player.bulletSpeedMod += .3f;
            if (player.gun != null)
                player.gun.bulletSpeed *= player.bulletSpeedMod;
            Btn_Cross.image.color = Color.yellow;
            player.skillPoints--;
        }
        else
            print("Not allowed Button");
    }
    //Fifth Tier
    public void eggButton()
    {
        if (tier4 == true && tier5 == false && player.skillPoints > 0)
        {
            print("EGG Button");
            tier5 = true;
            player.grenadeType = gren3;
            Btn_Egg.image.color = Color.yellow;
            player.skillPoints--;
        }
        else
            print("Not allowed Button");
    }
}
