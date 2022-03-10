using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public Transform player;

    void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerXPosition", player.position.x);
        PlayerPrefs.SetFloat("PlayerYPosition", player.position.y);
        PlayerPrefs.SetFloat("PlayerZPosition", player.position.z);
        PlayerPrefs.Save();
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("PlayerXPosition"))
        {
            var x = PlayerPrefs.GetFloat("PlayerXPosition");
            var y = PlayerPrefs.GetFloat("PlayerYPosition");
            var z = PlayerPrefs.GetFloat("PlayerZPosition");

            player.gameObject.GetComponent<CharacterController>().enabled = false;
            player.position = new Vector3(x, y, z);
            player.gameObject.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }

    void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnSaveButton_Pressed()
    {
        SaveGame();
    }

    public void OnLoadButton_Pressed()
    {
        LoadGame();
    }

}
