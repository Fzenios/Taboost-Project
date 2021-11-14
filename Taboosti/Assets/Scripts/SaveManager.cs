using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public ExtraDataHere extradatahere;
    public DataForSaving data;
    public void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/GameSave.dat", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();

        DataForSaving data = new DataForSaving(extradatahere);
                
        formatter.Serialize (file, data);
        
        //Debug.Log(extradatahere.Sound);
        Debug.Log("egine to save");

        file.Close();
    }

    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/GameSave.dat", FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();

        DataForSaving data =  formatter.Deserialize(file) as DataForSaving;
        
        Debug.Log("egine to load");
        Debug.Log(extradatahere.dataForSaving.Sound);
        
        file.Close();

    }

}
