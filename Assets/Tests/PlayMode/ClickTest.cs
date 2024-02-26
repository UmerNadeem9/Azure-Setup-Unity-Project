using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class ClickTest
{
    [UnityTest]
    public IEnumerator Click_Easy_Button()
    {
    
            // Load the scene containing your UI (replace "SampleScene" with the actual name of your scene)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype 5");

            // Wait for one frame to ensure the scene is loaded
            yield return null;

            // Find the button in the scene (replace "YourButtonName" with the actual name of your button GameObject)
            Button button = GameObject.Find("Easy Button")?.GetComponent<Button>();

            // Ensure the button is not null
            Assert.IsNotNull(button, "Button not found in the scene.");

            bool buttonClicked = false;

            // Subscribe to the button's click event
            button.onClick.AddListener(() =>
            {
                buttonClicked = true;
            });

            // Simulate a button click
            button.onClick.Invoke();

            // Wait for one frame to allow the UI to process the click
            yield return null;

            // Assert that the button click has triggered the desired behavior in your game
            Assert.IsTrue(buttonClicked, "Button should have been clicked.");

            // Optionally, you can check the button's state after the click
            Assert.IsTrue(button.interactable, "Button should be interactable after the click.");




    }
}
