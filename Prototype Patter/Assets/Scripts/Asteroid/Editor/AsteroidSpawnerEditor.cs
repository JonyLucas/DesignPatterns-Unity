using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(AsteroidSpawner))]
public class AsteroidSpawnerEditor : Editor {

    private string path;
    private string localPath;
    private string fileName;


    private void OnEnable() {
        path = Application.dataPath + "/Prefabs/Asteroids";
        localPath = "/Assets/Prefabs/Asteroids/";
        fileName = "Asteroid_" + System.DateTime.Now.Ticks.ToString();

    }

    public override void OnInspectorGUI() {
        AsteroidSpawner spawner = (AsteroidSpawner) target;
        DrawDefaultInspector();

        if(GUILayout.Button("Create Asteroid")) {
            spawner.CreateAsteroid();
        }

        if(GUILayout.Button("Save Asteroid")) {
            System.IO.Directory.CreateDirectory(path);

            Mesh mesh = spawner.asteroidObject.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, localPath + mesh.name + ".asset");
            AssetDatabase.SaveAssets();

            PrefabUtility.SaveAsPrefabAsset(spawner.asteroidObject, localPath + fileName + ".prefab");

        }

    }


}
