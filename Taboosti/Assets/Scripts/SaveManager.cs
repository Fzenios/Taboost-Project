using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public ExtraDataHere extraDataHere;
    public void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/GameSaveeeeee.dat", FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();
                
        formatter.Serialize (file, extraDataHere.dataForSaving);
        
        Debug.Log("egine to save");

        file.Close();
    }

    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/GameSaveeeeee.dat", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();

        extraDataHere.dataForSaving = (ExtraDataHere.DataForSaving)formatter.Deserialize(file);
        
        Debug.Log("egine to load");

        file.Close();
    }

}
