/*using UnityEngine;
using System.Collections.Generic;

public class ModelMaterialAssigner : MonoBehaviour
{
    // Array to hold the 7 materials assigned via the Inspector
    public Material[] materialBank;

    // List to keep track of assigned materials
    private List<Material> assignedMaterials = new List<Material>();

    void Start()
    {
        AssignMaterials();
    }

    void AssignMaterials()
    {
        // Get all model GameObjects tagged as "Model"
        GameObject[] models = GameObject.FindGameObjectsWithTag("Model");

        if (models.Length != 9)
        {
            Debug.LogError("Expected 9 models in the scene with the tag 'Model'.");
            return;
        }

        // Dictionary to count how many times each material is assigned
        Dictionary<Material, int> materialCount = new Dictionary<Material, int>();

        foreach (GameObject model in models)
        {
            Material selectedMaterial = null;
            int attempts = 0;

            // Try to select a material that hasn't been assigned more than twice
            do
            {
                selectedMaterial = materialBank[Random.Range(0, materialBank.Length)];
                materialCount.TryGetValue(selectedMaterial, out int count);
                attempts++;

                if (attempts > 100)
                {
                    Debug.LogError("Unable to assign materials without creating a winning condition.");
                    return;
                }
            }
            while (materialCount.ContainsKey(selectedMaterial) && materialCount[selectedMaterial] >= 2);

            // Assign the selected material to the model
            Renderer renderer = model.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = selectedMaterial;
            }
            else
            {
                Debug.LogWarning($"Model '{model.name}' does not have a Renderer component.");
            }

            // Update the material count
            if (materialCount.ContainsKey(selectedMaterial))
            {
                materialCount[selectedMaterial]++;
            }
            else
            {
                materialCount[selectedMaterial] = 1;
            }
        }
    }

}*/


using UnityEngine;
using System.Collections.Generic;

public class ModelMaterialAssigner : MonoBehaviour
{
    [Header("Assign exactly 3 materials here")]
    public Material[] materials; // Assign 3 distinct materials in the Inspector

    [Header("Assign your 9 model GameObjects here")]
    public GameObject[] models; // Assign your 9 model GameObjects in the Inspector

    void Start()
    {
        AssignMaterials();
    }

    void AssignMaterials()
    {
        // Validate inputs
        if (materials.Length != 3)
        {
            Debug.LogError("Please assign exactly 3 materials.");
            return;
        }

        if (models.Length != 9)
        {
            Debug.LogError("Please assign exactly 9 model GameObjects.");
            return;
        }

        // Create a list with each material repeated 3 times
        List<Material> materialPool = new List<Material>();
        foreach (Material mat in materials)
        {
            for (int i = 0; i < 3; i++)
            {
                materialPool.Add(mat);
            }
        }

        // Shuffle the material pool
        Shuffle(materialPool);

        // Assign materials to models
        for (int i = 0; i < models.Length; i++)
        {
            Renderer renderer = models[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materialPool[i];
            }
            else
            {
                Debug.LogWarning($"Model at index {i} does not have a Renderer component.");
            }
        }
    }

    // Fisher-Yates shuffle algorithm
    void Shuffle(List<Material> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Material temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}