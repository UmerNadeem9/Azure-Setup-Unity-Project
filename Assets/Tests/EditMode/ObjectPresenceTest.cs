
using NUnit.Framework;
using UnityEngine;


public class ObjectPresenceTest
{
    
    [Test]
    public void Find_Easy_Button()
    {
        GameObject buttonGameObject = GameObject.Find("Easy Button");
        Assert.IsNotNull(buttonGameObject, "Easy Buton is present");

    }
}
