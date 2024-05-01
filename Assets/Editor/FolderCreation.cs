using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FolderCreation : MonoBehaviour
{

    public bool IncludeResourceFolder = false;
    public bool UseNamespace = false;
    private string SFGUID;
    public List<string> nsFolders = new List<string>();
    public List<string> folders = new List<string>() { "Scenes", "Scripts", "Animation", "Audio", "Materials", "Meshes", "Prefabs", "Artwork", "Textures", "Sprites" };
    [MenuItem("Edit/Create Project Folders...")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Create Project Folders", typeof(FolderCreation), "Create");
    }

    //Called when the window first appears
    void OnEnable()
    {

    }
    //Create button click
    void OnWizardCreate()
    {

        //create all the folders required in a project
        //primary and sub folders
        foreach (string folder in folders)
        {
            string guid = AssetDatabase.CreateFolder("Assets", folder);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
            if (folder == "Scripts")
                SFGUID = newFolderPath;
        }

        AssetDatabase.Refresh();
        if (UseNamespace == true)
        {
            foreach (string nsf in nsFolders)
            {
                //AssetDatabase.Contain
                string guid = AssetDatabase.CreateFolder("Assets/Scripts", nsf);
                string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

            }
        }
    }
    //Runs whenever something changes in the editor window...
    void OnWizardUpdate()
    {
        if (IncludeResourceFolder == true && !folders.Contains("Resources"))
            folders.Add("Resources");
        if (IncludeResourceFolder == false && folders.Contains("Resources"))
            folders.Remove("Resources");

        if (UseNamespace == true)
            addNamespaceFolders();
        if (UseNamespace == false)
            removeNamespceFolders();

    }
    void addNamespaceFolders()
    {


        if (!nsFolders.Contains("Interfaces"))
            nsFolders.Add("Interfaces");

        if (!nsFolders.Contains("Classes"))
            nsFolders.Add("Classes");


        if (!nsFolders.Contains("States"))
            nsFolders.Add("States");

        // (nsFolders);
    }

    void removeNamespceFolders()
    {
        if (nsFolders.Count > 0) nsFolders.Clear();
    }
}
