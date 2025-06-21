using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; //Reference untuk slider di volume setting

    void Start(){
        if(!PlayerPrefs.HasKey("BGMVolume")){ //Check apa ada PlayerPrefs/Save sudah dibuat/ada
            PlayerPrefs.SetFloat("BGMVolume", 0.2f); //Set value volume pada awal start
            Load();
        }
        else{ //Set value volume dari save terakhir
            Load();
        }
    }

    public void ChangeVolume(){ //Method untuk ganti volume value
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load(){ //Method untuk ambil value dari PlayerPrefs
        volumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
    }

    public void Save(){ //Method untuk save value ke PlayerPrefs
        PlayerPrefs.SetFloat("BGMVolume", volumeSlider.value);
    }
}

/*
    using UnityEngine.UI reference untuk edit UI 
    PlayerPrefs fitur untuk menyimpan variabel
    HasKey = Method untuk checking PlayerPrefs
    GetFloat = Method untuk ambil value yang tersimpan
    SetFloat = Method untuk menyimpan value ke PlayerPrefs
*/

